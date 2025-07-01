using CARTER.Models.Players.PlayerPositions;
using System;
using System.Text.Json.Serialization;

namespace CARTER.Models.Players.PlayerPositionPlayers
{
    public class PlayerPositionModel
    {
        //public Guid Id { get; set; }

        public Guid PlayerId { get; set; }
        [JsonIgnore]
        public PlayerModel Player { get; set; }
        [JsonIgnore]
        public int PositionId { get; set; }
        public PositionModel Position { get; set; }
    }
}
