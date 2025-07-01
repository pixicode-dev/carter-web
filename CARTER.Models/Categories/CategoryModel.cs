using CARTER.Models.Common;
using CARTER.Models.Exercises;
using CARTER.Models.Teams;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CARTER.Models.Categories
{
    public class CategoryModel : ItemModel
    {
        [JsonIgnore]
        public ICollection<TeamModel> Teams { get; set; }
        [JsonIgnore]
        public ICollection<ExerciseModel> Exercises { get; set; }
    }
}
