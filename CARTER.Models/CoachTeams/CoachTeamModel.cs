using CARTER.Models.Coaches;
using CARTER.Models.Teams;
using System;
using System.Text.Json.Serialization;

namespace CARTER.Models.CoachTeams
{
    public class CoachTeamModel
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid? CoachId { get; set; }
        [JsonIgnore]
        public CoachModel Coach { get; set; }
        [JsonIgnore]
        public Guid? TeamId { get; set; }
        //[JsonIgnore]
        public TeamModel Team { get; set; }
        public bool IsOwner { get; set; }
    }
}
