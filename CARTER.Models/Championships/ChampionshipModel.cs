using CARTER.Models.Teams;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CARTER.Models.Championships
{
    public class ChampionshipModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<TeamModel> Teams { get; set; }
    }
}
