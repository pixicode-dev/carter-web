using CARTER.Models.Skills;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CARTER.Models.SkillCategories
{
    public class SkillCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Role { get; set; }
        public ICollection<SkillModel> Skills { get; set; }
    }
}
