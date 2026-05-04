using NotificationProject.Interfaces;
using NotificationProject.Models;
using NotificationProject.Services;

namespace NotificationProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creating users
            User u1=new("Pratik", "sarangipratik7@gmail.com", "9989898989");
            User u2=new("Sarangi", "psarangi@presidio.com", "1212121212");
            
            // creating the notifications
            Notification notifEmail=new("ABCDEFG Via email");
            Notification notifPhone=new("HIJKLMNOP Via phone");
            
            // creating the notification service
            NotificationService notifService=new(); 
            
            //creating the message channels-> these are used to send the messages through the service
            INotificationSender emailChannel=new EmailNotification();
            INotificationSender smsChannel=new SmsNotification();

            // calling the messaging services: 
            notifService.NotifyUser(u1, notifEmail, emailChannel);
            notifService.NotifyUser(u2, notifPhone, smsChannel);
        }
    }
}