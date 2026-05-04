using NotificationProject.Interfaces;
using NotificationProject.Models;

namespace NotificationProject.Services
{
    internal class EmailNotification : INotificationSender
    {
        public void Send(User user, Notification notification)
        {
            // check if email exists first, if no, return
            if (string.IsNullOrEmpty(user.Email))
            {
                Console.WriteLine($"No email address for {user.Name}.");
                return;
            }
            Console.WriteLine($"Email sent to {user.Email}. Message is: {notification.Message}");
        }

    }
}