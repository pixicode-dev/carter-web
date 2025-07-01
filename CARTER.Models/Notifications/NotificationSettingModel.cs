namespace CARTER.Models.Notifications
{
    public class NotificationSettingModel
    {
        public string DeviceToken { get; set; }
        public string LanguageCode { get; set; }
        public string DeviceOS { get; set; }
        public string Timezone { get; set; }
        public bool? NotificationStatus { get; set; }
    }
}
