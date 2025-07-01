using CARTER.Models.Categories;
using CARTER.Models.HashTags;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CARTER.Models.Exercises
{
    public class ExerciseCreateRequest
    {
        [Required]
        public string Title { get; set; }
        public List<string> TagNames { get; set; }
        public string Objectives { get; set; }
        public string Instruction { get; set; }
        public string Evolution { get; set; }
        public List<string> Tacticalboards { get; set; }
        public List<string> TypeNames { get; set; }
        public List<string> CategoryNames { get; set; }
        public int StatusId { get; set; }
        #region Select lists
        public List<TypeModel> Types { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public List<StatusModel> Statuses { get; set; }
        public List<TagModel> Tags { get; set; }
        #endregion


    }
}
