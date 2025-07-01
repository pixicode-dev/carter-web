using CARTER.Models.Coaches.Skills;
using CARTER.Models.SkillCategories;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CARTER.Models.Skills
{
    public class SkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public int SkillCategoryId { get; set; }
        [JsonIgnore]
        public SkillCategoryModel SkillCategory { get; set; }
        public int SkillPoint { get; set; }
        [JsonIgnore]
        public ICollection<CoachSkillModel> CoachSkills { get; set; }

        //public double Percentage { get; set; }
    }
}
