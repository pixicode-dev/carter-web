using System;

namespace CARTER.Models.Players.PlayerPositionPlayers
{
    public class PlayerPositionUpdateRequest
    {
        //public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public int PlayerPositionId { get; set; }
    }
}
