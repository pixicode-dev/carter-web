using CARTER.Models.Categories;
using CARTER.Models.Common;
using CARTER.Models.HashTags;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.Common
{
    public class CommonApiClient : BaseApiClient, ICommonApiClient
    {

        public CommonApiClient(
                IHttpClientFactory httpClientFactory,
                IHttpContextAccessor httpContextAccessor,
                IOptions<ApiSettingModel> apiSettings) : base(httpClientFactory, httpContextAccessor, apiSettings)
        {
        }
        public async Task<ApiResult<PagedResult<CategoryModel>>> GetCategories(PagingRequestBase request)
        {
            var result = await GetAsync<ApiResult<PagedResult<CategoryModel>>>(
                $"/api/common/categories?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&Search={request.Search}");

            return result;
        }
        public async Task<ApiResult<string>> UploadFile(FileUploadRequest request)
        {
            try
            {
                return await PostByFormAsync<ApiResult<string>, FileUploadRequest>($"/api/common/uploadfile", request);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<ApiResult<PagedResult<TagModel>>> GetTags(PagingRequestBase request)
        {
            var result = await GetAsync<ApiResult<PagedResult<TagModel>>>(
                $"/api/common/tags?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&Search={request.Search}");

            return result;
        }


    }
}
