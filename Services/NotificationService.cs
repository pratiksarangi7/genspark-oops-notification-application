using NotificationProject.Interfaces;
using NotificationProject.Models;

namespace NotificationProject.Services
{
    internal class NotificationService
    {
        public void NotifyUser(User u, Notification n, INotificationSender sender)
        {
            sender.Send(u, n);
        }
    }
}