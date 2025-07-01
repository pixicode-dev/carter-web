using CARTER.Models.Common;
using CARTER.Models.Notifications;
using CARTER.Models.System.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.User
{
    public interface IUserApiClient
    {
        Task<ApiResult<LoginResponse>> Authenticate(LoginRequest request);
        Task<ApiResult<string>> ChangePasswordAsync(ChangePasswordRequest request);
        Task<ApiResult<bool>> ChangeUserStatus(ChangeStatusRequest request);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<ApiResult<List<AppUserExportModel>>> ExportUsersAsync();
        Task<ApiResult<AppUserModel>> GetMyProfile();
        Task<ApiResult<PagedResult<AppUserModel>>> GetUsersAsync(AppUserPagingRequest request);
        Task<ApiResult<string>> UpdateMyProfileAsync(AppUserUpdateRequest request);
        Task<ApiResult<string>> UpdateNotificationSettings(NotificationSettingModel request);
    }
}
