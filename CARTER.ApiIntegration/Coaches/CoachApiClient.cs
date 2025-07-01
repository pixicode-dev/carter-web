using CARTER.Models.Coaches;
using CARTER.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.Coaches
{
    public class CoachApiClient : BaseApiClient, ICoachApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CoachApiClient(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ApiSettingModel> apiSettings
            ) : base(httpClientFactory, httpContextAccessor, apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<PagedResult<CoachModel>>> GetCoachesAsync(CoachPagingRequest request)
        {
            var result = await GetAsync<ApiResult<PagedResult<CoachModel>>>(
                $"/api/coaches?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");

            return result;
        }
    }
}
