using CARTER.Models.Players.Levels;
using System;

namespace CARTER.Models.Players
{
    public class PlayerBaseModel
    {
        public Guid Id { get; set; }
        public string LicenseNumber { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public string MotherPhoneNumber { get; set; }
        public string FatherPhoneNumber { get; set; }

        public int WorkPoint { get; set; }
        public PlayerLevelModel PlayerLevel { get; set; }

        //public ICollection<PlayerImproveSkillModel> PlayerImproveSkills { get; set; }
        //public ICollection<PlayerPositionModel> PlayerPositions { get; set; }
        //public ICollection<PlayerSkillModel> PlayerSkills { get; set; }
    }
}
