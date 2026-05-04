using NotificationProject.Interfaces;
using NotificationProject.Models;

namespace NotificationProject.Services
{
    internal class SmsNotification : INotificationSender
    {
        public void Send(User user, Notification notification)
        {
            // check if phone number of the user exists, if yes share
            if (string.IsNullOrEmpty(user.PhoneNumber))
            {
                Console.WriteLine($"No phone number for {user.Name}.");
                return;
            }
            Console.WriteLine($"SMS sent to ${user.PhoneNumber}. Message is: ${notification.Message}");
        }

    }
}