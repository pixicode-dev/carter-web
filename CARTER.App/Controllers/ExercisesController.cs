using CARTER.ApiIntegration.Common;
using CARTER.ApiIntegration.Exercises;
using CARTER.App.Models;
using CARTER.Models.Categories;
using CARTER.Models.Common;
using CARTER.Models.Exercises;
using CARTER.Models.HashTags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARTER.App.Controllers
{
    public class ExercisesController : BaseController
    {
        private readonly IExerciseApiClient _exerciseApiClient;
        private readonly ICommonApiClient _commonApiClient;
        private static ApiResult<List<TypeModel>> _types;
        private static ApiResult<List<StatusModel>> _statuses;
        private static ApiResult<PagedResult<CategoryModel>> _categories;
        private static ApiResult<PagedResult<TagModel>> _tags;

        public ExercisesController(IExerciseApiClient exerciseApiClient, ICommonApiClient commonApiClient)
        {
            _exerciseApiClient = exerciseApiClient;
            _commonApiClient = commonApiClient;
        }

        //[Breadcrumb(FromAction = "Index", Title = "Exer")]
        [Breadcrumb("Exercises")]
        public async Task<IActionResult> Index()
        {
            _categories = await _commonApiClient.GetCategories(new PagingRequestBase());
            _types = await _exerciseApiClient.GetExerciseTypes();
            _statuses = await _exerciseApiClient.GetExerciseStatuses();

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetExercises(DataTableRequest querry)
        {
            //int count = 0;
            //int total_count = 0;
            var order = querry?.order?.First();
            var orderBy = querry?.columns[order?.column ?? 0]?.name;


            var result = await _exerciseApiClient.GetExercisesAsync(new ExercisePagingRequest
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

        public async Task<ActionResult> AddExercise()
        {
            _tags = await _commonApiClient.GetTags(new PagingRequestBase());
            ExerciseCreateRequest exercise = new ExerciseCreateRequest();
            exercise.Types = _types.Data;
            exercise.Categories = _categories.Data.Items;
            exercise.Statuses = _statuses.Data;
            exercise.Tags = _tags.Data.Items;
            return PartialView("_AddExercise", exercise);
        }


        [HttpPost]
        public async Task<ActionResult> AddExercise(ExerciseCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                _tags = await _commonApiClient.GetTags(new PagingRequestBase());
                request.Types = _types.Data;
                request.Statuses = _statuses.Data;
                request.Tags = _tags.Data.Items;
                request.Categories = _categories.Data.Items;
                return PartialView("_AddExercise", request);
            }
            var result = await _exerciseApiClient.AddExercise(request);

            return Json(result);
        }

        public async Task<ActionResult> EditExercise(Guid exerciseId)
        {
            _tags = await _commonApiClient.GetTags(new PagingRequestBase());
            var apiResult = await _exerciseApiClient.GetExerciseAsync(exerciseId);
            var exerciseUpdateRequest = new ExerciseUpdateRequest
            {
                Id = apiResult.Data.Id,
                Title = apiResult.Data.Title,
                Objectives = apiResult.Data.Objectives,
                Evolution = apiResult.Data.Evolution,
                Tacticalboards = apiResult.Data.Tacticalboards.Select(t => t.Url).ToList(),
                Instruction = apiResult.Data.Instruction,
                TagNames = apiResult.Data.HashTags.Select(ht => ht.Tag.Name).ToList(),
                StatusId = apiResult.Data.Status.Id,
                CategoryNames = apiResult.Data.Categories.Select(c => c.Value).ToList(),
                TypeNames = apiResult.Data.Types.Select(c => c.Value).ToList(),
                Types = _types.Data,
                Statuses = _statuses.Data,
                Tags = _tags.Data.Items,
                Categories = _categories.Data.Items
            };
            return PartialView("_EditExercise", exerciseUpdateRequest);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateExercise(ExerciseUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                _tags = await _commonApiClient.GetTags(new PagingRequestBase());
                request.Types = _types.Data;
                request.Categories = _categories.Data.Items;
                request.Statuses = _statuses.Data;
                request.Tags = _tags.Data.Items;
                return PartialView("_EditExercise", request);
            }
            var result = await _exerciseApiClient.UpdateExercise(request.Id, request);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteExercise(Guid exerciseId)
        {
            var result = await _exerciseApiClient.DeleteExercise(exerciseId);
            return Json(new { success = result });
        }

        [HttpPost]
        public async Task<ActionResult> UploadTacticalBoard(IFormFile file)
        {
            var result = await _commonApiClient.UploadFile(new FileUploadRequest { File = file });
            return Json(new
            {
                success = result.Success,
                data = result.Data
            });
        }
    }
}
