using CARTER.Models.Common;
using CARTER.Models.Notifications;
using CARTER.Models.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.User
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {

        public UserApiClient(
                IHttpClientFactory httpClientFactory,
                IHttpContextAccessor httpContextAccessor,
                IOptions<ApiSettingModel> apiSettings) : base(httpClientFactory, httpContextAccessor, apiSettings)
        {

        }

        public async Task<ApiResult<LoginResponse>> Authenticate(LoginRequest request)
        {
            return await PostByBodyAsync<ApiResult<LoginResponse>, LoginRequest>($"/api/users/signin", request);
        }
        public async Task<ApiResult<PagedResult<AppUserModel>>> GetUsersAsync(AppUserPagingRequest request)
        {
            return await GetAsync<ApiResult<PagedResult<AppUserModel>>>(
                $"/api/users?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&Search={request.Search}" +
                $"&Role={request.Role}" +
                $"&OrderBy={request.OrderBy}" +
                $"&OrderDir={request.OrderDir}");

        }

        public async Task<ApiResult<List<AppUserExportModel>>> ExportUsersAsync()
        {
            return await GetAsync<ApiResult<List<AppUserExportModel>>>($"/api/users/export");
        }

        public async Task<ApiResult<bool>> ChangeUserStatus(ChangeStatusRequest request)
        {
            return await PostByBodyAsync<ApiResult<bool>, ChangeStatusRequest>($"/api/users/status", request);
        }

        public async Task<ApiResult<string>> UpdateNotificationSettings(NotificationSettingModel request)
        {
            return await PutByBodyAsync<ApiResult<string>, NotificationSettingModel>($"/api/notifications/me/settings", request);
        }

        public async Task<ApiResult<string>> ChangePasswordAsync(ChangePasswordRequest request)
        {
            return await PostByBodyAsync<ApiResult<string>, ChangePasswordRequest>($"/api/users/passwords/change", request);
        }
        public async Task<ApiResult<string>> UpdateMyProfileAsync(AppUserUpdateRequest request)
        {
            return await PostByBodyAsync<ApiResult<string>, AppUserUpdateRequest>($"/api/users/me", request);
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await DeleteAsync($"/api/users/{userId}");
        }


        public async Task<ApiResult<AppUserModel>> GetMyProfile()
        {
            var result = await GetAsync<ApiResult<AppUserModel>>(
                $"/api/users/me");
            return result;
        }
    }
}
