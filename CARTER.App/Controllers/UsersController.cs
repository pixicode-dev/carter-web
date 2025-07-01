using CARTER.ApiIntegration.Common;
using CARTER.ApiIntegration.Stripe;
using CARTER.ApiIntegration.User;
using CARTER.App.Models;
using CARTER.Models.Common;
using CARTER.Models.Notifications;
using CARTER.Models.System.Users;
using ClosedXML.Excel;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CARTER.App.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IStripeApiClient _stripeApiClient;
        private readonly ICommonApiClient _commonApiClient;

        public UsersController(IUserApiClient userApiClient, IStripeApiClient stripeApiClient, ICommonApiClient commonApiClient)
        {
            _userApiClient = userApiClient;
            _stripeApiClient = stripeApiClient;
            _commonApiClient = commonApiClient;
        }
        [Breadcrumb("Users")]
        public IActionResult Index()
        {
            return View();
        }
        [Breadcrumb("Profile")]
        public IActionResult Profile()
        {
            return View();
        }

        public async Task<IActionResult> GetProfile()
        {
            return Json(new
            {
                userResponse = await _userApiClient.GetMyProfile(),
                coachesResponse = await _userApiClient.GetUsersAsync(new AppUserPagingRequest
                {
                    Role = "Coach",
                    PageIndex = 1,
                    PageSize = 0,
                }),
                directorsResponse = await _userApiClient.GetUsersAsync(new AppUserPagingRequest
                {
                    Role = "Director",
                    PageIndex = 1,
                    PageSize = 0,
                }),
                playersResponse = await _userApiClient.GetUsersAsync(new AppUserPagingRequest
                {
                    Role = "Player",
                    PageIndex = 1,
                    PageSize = 0,
                })
            });
        }
        public IActionResult ChangePassword()
        {
            return PartialView("_ChangePassword");
        }
        public async Task<IActionResult> EditProfile()
        {
            var userResponse = await _userApiClient.GetMyProfile();
            var model = new AdminUpdateRequest
            {
                Avatar = userResponse.Data.Avatar,
                FirstName = userResponse.Data.FirstName,
                LastName = userResponse.Data.LastName,
                PhoneNumber = userResponse.Data.PhoneNumber,
                Email = userResponse.Data.Email,
                Location = new LocationModel
                {
                    Address = userResponse.Data.Location.Address,
                    Latitude = userResponse.Data.Location.Latitude,
                    Longitude = userResponse.Data.Location.Longitude,
                    City = userResponse.Data.Location.City,
                    Country = userResponse.Data.Location.Country,
                    CountryCode = userResponse.Data.Location.CountryCode,
                    PostalCode = userResponse.Data.Location.PostalCode
                }
            };
            return PartialView("_EditProfile", model);
        }

        [HttpPost]
        public async Task<ActionResult> EditProfile(AdminUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_EditProfile", model);
            }

            if (model.AvatarFile != null)
            {
                var uploadAvatarResult = await _commonApiClient.UploadFile(new FileUploadRequest { File = model.AvatarFile });
                if (uploadAvatarResult.Success)
                {
                    model.Avatar = uploadAvatarResult.Data;
                }
            }

            var result = await _userApiClient.UpdateMyProfileAsync(model);
            if (!result.Success)
            {
                return PartialView("_EditProfile", model);
            }
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            var result = await _userApiClient.DeleteUserAsync(userId);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequest model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_ChangePassword", model);
            }
            var result = await _userApiClient.ChangePasswordAsync(model);
            if (!result.Success)
            {
                //if (result.Message == "INCORRECT_PASSWORD")
                //{
                //    ModelState.AddModelError("CurrentPassword", "Current password incorrect.");
                //}
                ModelState.AddModelError("CurrentPassword", "Current password incorrect.");
                return PartialView("_ChangePassword", model);
            }

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> GetUsers(DataTableRequest querry)
        {
            //int count = 0;
            //int total_count = 0;
            var order = querry?.order?.First();
            var orderBy = order == null ? null : querry?.columns[order.column]?.name;
            var result = await _userApiClient.GetUsersAsync(new AppUserPagingRequest
            {
                PageIndex = (querry.start / querry.length) + 1,
                PageSize = querry.length,
                Search = querry.search.value,
                OrderBy = orderBy,
                OrderDir = order?.dir ?? "asc"
            });

            return Json(new
            {
                draw = querry.draw,
                success = true,
                data = result.Data.Items,
                recordsTotal = result.Data.TotalRecords,
                recordsTotalAll = result.Data.TotalRecords,
                recordsFiltered = result.Data.TotalRecords,
            });
        }

        public async Task<IActionResult> ExportToCsv()
        {
            var usersResponse = await _userApiClient.ExportUsersAsync();
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(usersResponse.Data);
                    }
                }
                var result = new FileContentResult(memoryStream.ToArray(), "text/csv")
                {
                    FileDownloadName = "Cater_AppUsers.csv",
                };
                return result;
            }    
           
        }
        public async Task<IActionResult> ExportToExcel()
        {
            var usersResponse = await _userApiClient.ExportUsersAsync();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                var dataTable = worksheet.FirstCell().InsertTable<AppUserExportModel>(usersResponse.Data, "AppUsers", true);

                worksheet.ColumnsUsed().AdjustToContents();
                //worksheet.SheetView.FreezeRows(1);

                //var dataTable = worksheet.RangeUsed().CreateTable("AppUsers");
                dataTable.AutoFilter.IsEnabled = true;
                dataTable.ShowAutoFilter = true;
                dataTable.Theme = XLTableTheme.TableStyleMedium4;

                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var contentDisposition = new System.Net.Mime.ContentDisposition
                    {
                        FileName = "Cater_AppUsers.xlsx",
                        Inline = false,
                    };
                    Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                }
            }

            //var headerRow = worksheet.Row(1);
            //headerRow.Cell(1).Value = "FirstName";
            //headerRow.Cell(2).Value = "LastName";
            //headerRow.Cell(3).Value = "Email";
            //headerRow.Cell(4).Value = "PhoneNumber";
            //headerRow.Cell(5).Value = "Role";

            //var dataRows = usersResponse.Data.Select((item, index) =>
            //{
            //    var row = worksheet.Row(index + 2); 
            //    row.Cell(1).Value = item.FirstName;
            //    row.Cell(2).Value = item.LastName;
            //    row.Cell(3).Value = item.Email;
            //    row.Cell(4).Value = item.PhoneNumber;
            //    row.Cell(5).Value = item.Role;

            //    //var color = index % 2 == 0 ? XLColor.LightBlue : XLColor.LightGreen;
            //    //row.Style.Fill.BackgroundColor = color;

            //    return row;
            //}).ToList();

        }
        public async Task<ActionResult> GetPaymentLinks(Guid appUserId)
        {
            var paymentLinks = await _stripeApiClient.GetPaymentLinks(appUserId);
            return PartialView("_PaymentLinks", paymentLinks.Data);
        }

        [HttpPost]
        public async Task<ActionResult> SendPaymentLinks(Guid appUserId)
        {
            var result = await _stripeApiClient.SendPaymentLinks(appUserId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeUserStatus(Guid appUserId, bool isActive)
        {
            var request = new ChangeStatusRequest
            {
                AppUserId = appUserId,
                IsActive = isActive
            };
            var result = await _userApiClient.ChangeUserStatus(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateNotificationSettings(NotificationSettingModel request)
        {
            var result = await _userApiClient.UpdateNotificationSettings(request);
            return Ok(result);
        }

    }
}
