using CARTER.Models.Common;
using CARTER.Models.Players;
using CARTER.Models.Teams;
using System;
using System.Text.Json.Serialization;

namespace CARTER.Models.TeamPlayers
{
    public class TeamPlayerModel : BaseModel
    {
        //public Guid Id { get; set; }

        public Guid? PlayerId { get; set; }
        [JsonIgnore]
        public PlayerModel Player { get; set; }
        public Guid? TeamId { get; set; }
        [JsonIgnore]
        public TeamModel Team { get; set; }
    }
}
