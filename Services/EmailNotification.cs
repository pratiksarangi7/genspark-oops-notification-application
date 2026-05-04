using NotificationProject.Interfaces;
using NotificationProject.Models;
using System;
using System.Net;
using System.Net.Mail;
namespace NotificationProject.Services
{
    internal class EmailNotification : INotificationSender
    {
        private readonly string _senderEmail;
        private readonly string _appPassword;

        public EmailNotification()
        {
            // getting gmail and password from system environment variables: 
            _senderEmail = Environment.GetEnvironmentVariable("GMAIL_ADDRESS")??"";
            _appPassword = Environment.GetEnvironmentVariable("GMAIL_APP_PASSWORD")??"";

            if (string.IsNullOrEmpty(_senderEmail) || string.IsNullOrEmpty(_appPassword))
            {
                Console.WriteLine("Credentials not found :-(");
            }
        }

        public void Send(User user, Notification notification)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                Console.WriteLine($"Failed: No email address there for {user.Name}.");
                return;
            }

            if (string.IsNullOrEmpty(_senderEmail) || string.IsNullOrEmpty(_appPassword))
            {
                Console.WriteLine("Failed: Cannot send email. Missing sender credentials.");
                return;
            }

            try
            {
                // Configure the Gmail SMTP Client
                using var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(_senderEmail, _appPassword),
                    EnableSsl = true,
                };

                // Construct the email message
                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(_senderEmail, "Notification Service"),
                    Subject = "New System Notification",
                    Body = $"{notification.Message}\nSent: {notification.SentDate}",
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(user.Email);

                // Send the email
                smtpClient.Send(mailMessage);
                Console.WriteLine($"Success!! sent email to {user.Email} at {notification.SentDate}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email to {user.Email}. Error: {ex.Message}");
            }
        }
    }
}