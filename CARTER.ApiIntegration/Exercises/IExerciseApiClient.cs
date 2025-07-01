using CARTER.Models.Common;
using CARTER.Models.Exercises;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.Exercises
{
    public interface IExerciseApiClient
    {
        Task<ApiResult<ExerciseModel>> AddExercise(ExerciseCreateRequest request);
        Task<bool> DeleteExercise(Guid exerciseId);

        Task<ApiResult<ExerciseModel>> GetExerciseAsync(Guid exerciseId);
        Task<ApiResult<PagedResult<ExerciseModel>>> GetExercisesAsync(ExercisePagingRequest request);
        Task<ApiResult<List<StatusModel>>> GetExerciseStatuses();
        Task<ApiResult<List<TypeModel>>> GetExerciseTypes();

        Task<ApiResult<ExerciseModel>> UpdateExercise(Guid exerciseId, ExerciseUpdateRequest request);
    }
}
