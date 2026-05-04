using NotificationProject.Models;

namespace NotificationProject.Interfaces
{
    internal interface INotificationSender
    {
        void Send(User user, Notification notification);
    }
}