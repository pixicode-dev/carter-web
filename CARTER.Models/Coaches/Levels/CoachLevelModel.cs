namespace CARTER.Models.Coaches.Levels
{
    public class CoachLevelModel
    {
        public int Id { get; set; }
        public CoachLevelCategoryModel Category { get; set; }
        public int Level { get; set; }
        public int LevelPoint { get; set; }
        public int ExperiencePoint { get; set; }
    }
}
