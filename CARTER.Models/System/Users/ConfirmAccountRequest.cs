namespace CARTER.Models.System.Users
{
    public class ConfirmAccountRequest
    {
        public string Email { get; set; }
        public string VerificationCode { get; set; }
    }
}
