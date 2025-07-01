using CARTER.Models.ClubCoaches;
using CARTER.Models.Coaches.Levels;
using CARTER.Models.Coaches.Skills;
using CARTER.Models.CoachTeams;
using CARTER.Models.Skills;
using System;
using System.Collections.Generic;

namespace CARTER.Models.Coaches
{
    public class CoachBaseModel
    {
        public Guid Id { get; set; }
        public int CoachPoint { get; set; }
        public CoachLevelModel CoachLevel { get; set; }
        public int ExperiencePoint { get; set; }
        public int ExperiencePointAvailable { get; set; }
        public ICollection<SkillModel> Skills { get; set; }
        public ICollection<ClubCoachModel> ClubCoaches { get; set; }
        public ICollection<CoachTeamModel> CoachTeams { get; set; }
        public ICollection<CoachSkillModel> CoachSkills { get; set; }
    }
}
