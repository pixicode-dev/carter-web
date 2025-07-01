using Microsoft.AspNetCore.Http;

namespace CARTER.Models.Clubs
{
    public class ClubUpdateRequest
    {
        public string ClubName { get; set; }
        public string ClubAddress { get; set; }
        public string Description { get; set; }

        public IFormFile ClubPicture { get; set; }
        #region Correspondent info
        public string CorrespondentFirstName { get; set; }
        public string CorrespondentLastName { get; set; }
        public string CorrespondentPhoneNumber { get; set; }
        #endregion

        #region President info
        public string PresidentFirstName { get; set; }
        public string PresidentLastName { get; set; }
        public string PresidentPhoneNumber { get; set; }
        #endregion
    }
}
