namespace CARTER.Models.Players.Levels
{
    public class PlayerLevelModel
    {
        public int Id { get; set; }
        public PlayerLevelCategoryModel Category { get; set; }
        public int Level { get; set; }
        public int LevelPoint { get; set; }
        public int ExperiencePoint { get; set; }
    }
}
