using System;

namespace CARTER.Models.TeamPlayers
{
    public class TeamPlayerCreateRequest
    {
        public Guid? PlayerId { get; set; }
        public Guid? TeamId { get; set; }
    }
}
