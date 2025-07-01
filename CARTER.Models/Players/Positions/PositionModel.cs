using CARTER.Models.Players.PlayerPositionPlayers;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CARTER.Models.Players.PlayerPositions
{
    public class PositionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<PlayerPositionModel> PlayerPositions { get; set; }
    }
}
