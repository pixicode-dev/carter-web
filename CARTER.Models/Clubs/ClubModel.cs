using CARTER.Models.Common;
using System;

namespace CARTER.Models.Clubs
{
    public class ClubModel : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        #region President info
        public string PresidentFirstName { get; set; }
        public string PresidentLastName { get; set; }
        public string PresidentPhoneNumber { get; set; }
        #endregion

        #region Correspondent info
        public string CorrespondentFirstName { get; set; }
        public string CorrespondentLastName { get; set; }
        public string CorrespondentPhoneNumber { get; set; }
        #endregion
        public int NumberOfCoaches { get; set; }
        public int NumberOfTeams { get; set; }
        public int NumberOfPlayers { get; set; }

    }
}
