namespace CARTER.Models.Teams
{
    public class TeamUpdateRequest
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? AgeId { get; set; }
        public int? SubdivisionId { get; set; }
        public int? ChampionshipId { get; set; }
        public int? PoolId { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
