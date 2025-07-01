namespace CARTER.Models.Clubs
{
    public class ClubCreateRequest
    {
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

    }
}
