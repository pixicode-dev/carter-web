using CARTER.Models.Coaches;
using CARTER.Models.Common;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.Coaches
{
    public interface ICoachApiClient
    {
        Task<ApiResult<PagedResult<CoachModel>>> GetCoachesAsync(CoachPagingRequest request);
    }
}
