using CARTER.Models.Categories;
using CARTER.Models.Championships;
using CARTER.Models.Clubs;
using CARTER.Models.CoachTeams;
using CARTER.Models.Pools;
using CARTER.Models.Subdivisions;
using CARTER.Models.TeamInvitations;
using CARTER.Models.TeamPlayers;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CARTER.Models.Teams
{
    public class TeamModel /*: BaseModel*/
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public ClubModel Club { get; set; }
        [JsonIgnore]
        public ICollection<CoachTeamModel> CoachTeams { get; set; }
        [JsonIgnore]
        public ICollection<TeamPlayerModel> TeamPlayers { get; set; }
        [JsonIgnore]
        public ICollection<TeamInvitationModel> TeamInvitations { get; set; }
        public CategoryModel Age { get; set; }
        public ChampionshipModel Championship { get; set; }
        public SubdivisionModel Subdivision { get; set; }
        public PoolModel Pool { get; set; }
    }
}
