using CARTER.Models.Common;
using CARTER.Models.Skills;
using System;
using System.Text.Json.Serialization;

namespace CARTER.Models.Coaches.Skills
{
    public class CoachSkillModel : BaseModel
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Guid CoachId { get; set; }
        public CoachModel Coach { get; set; }
        [JsonIgnore]
        public int SkillId { get; set; }
        public SkillModel Skill { get; set; }
        public int SkillPoint { get; set; } // Transfer from Experience Point

    }
}
