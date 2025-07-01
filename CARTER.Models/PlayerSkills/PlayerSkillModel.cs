using CARTER.Models.Players;
using CARTER.Models.Skills;
using System;
using System.Text.Json.Serialization;

namespace CARTER.Models.PlayerSkills
{
    public class PlayerSkillModel
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Guid PlayerId { get; set; }
        public PlayerModel Player { get; set; }
        [JsonIgnore]
        public int SkillId { get; set; }
        public SkillModel Skill { get; set; }
        public int SkillPoint { get; set; } // Transfer from Experience Point
    }
}
