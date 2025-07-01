using System;

namespace CARTER.Models.Players.PlayerPositionPlayers
{
    public class PlayerPositionCreateRequest
    {
        public Guid PlayerId { get; set; }
        public int PositionId { get; set; }
    }
}
