using CARTER.Models.Common;
using CARTER.Models.Exercises;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CARTER.ApiIntegration.Exercises
{
    public class ExerciseApiClient : BaseApiClient, IExerciseApiClient
    {
        public ExerciseApiClient(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ApiSettingModel> apiSettings
            ) : base(httpClientFactory, httpContextAccessor, apiSettings)
        {
        }
        public async Task<ApiResult<ExerciseModel>> GetExerciseAsync(Guid exerciseId)
        {
            var result = await GetAsync<ApiResult<ExerciseModel>>(
                $"/api/exercises/{exerciseId}");

            return result;
        }




        public async Task<ApiResult<List<TypeModel>>> GetExerciseTypes()
        {
            var result = await GetAsync<ApiResult<List<TypeModel>>>(
                $"/api/exercises/types");
            result.Data = result.Data.Where(d => d.Id != 0).ToList();
            return result;
        }
        public async Task<ApiResult<List<StatusModel>>> GetExerciseStatuses()
        {
            var result = await GetAsync<ApiResult<List<StatusModel>>>(
                $"/api/exercises/statuses");

            return result;
        }


        public async Task<ApiResult<PagedResult<ExerciseModel>>> GetExercisesAsync(ExercisePagingRequest request)
        {
            var result = await GetAsync<ApiResult<PagedResult<ExerciseModel>>>(
                $"/api/exercises?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&Search={request.Search}" +
                $"&OrderBy={request.OrderBy}" +
                $"&OrderDir={request.OrderDir}");

            return result;
        }
        public async Task<ApiResult<ExerciseModel>> AddExercise(ExerciseCreateRequest request)
        {
            try
            {
                return await PostByBodyAsync<ApiResult<ExerciseModel>, ExerciseCreateRequest>($"/api/exercises", request);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<ApiResult<ExerciseModel>> UpdateExercise(Guid exerciseId, ExerciseUpdateRequest request)
        {
            try
            {
                return await PutByBodyAsync<ApiResult<ExerciseModel>, ExerciseUpdateRequest>($"/api/exercises/{exerciseId}", request);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<bool> DeleteExercise(Guid exerciseId)
        {
            try
            {
                return await DeleteAsync($"/api/exercises/{exerciseId}");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //public async Task<ApiResult<ExerciseModel>> AddExcerciseAsync(ExerciseCreateRequest request)
        //{
        //    var result = await AddExcerciseAsync<ApiResult<PagedResult<ExerciseModel>>>(
        //         $"/api/exercises?pageIndex={request.PageIndex}" +
        //         $"&pageSize={request.PageSize}" +
        //         $"&Title={request.Title}" +
        //         $"&Description={request.Description}" +
        //         $"&Objectives={request.Objectives}" +
        //         $"&Instruction={request.Instruction}" +
        //         $"&Evolution={request.Evolution}");
        //}
    }
}
