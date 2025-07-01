using CARTER.Models.Categories;
using CARTER.Models.Common;
using CARTER.Models.HashTags;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.Common
{
    public interface ICommonApiClient
    {
        Task<ApiResult<PagedResult<CategoryModel>>> GetCategories(PagingRequestBase request);
        Task<ApiResult<string>> UploadFile(FileUploadRequest request);
        Task<ApiResult<PagedResult<TagModel>>> GetTags(PagingRequestBase request);
    }
}
