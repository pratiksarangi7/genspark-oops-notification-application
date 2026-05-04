namespace NotificationProject.Models
{
    internal class Notification
    {
        public string Message { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
        public Notification(string message)
        {
            Message = message;
            SentDate = DateTime.Now;
        }
    }
}