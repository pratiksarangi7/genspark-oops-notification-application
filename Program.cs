using NotificationProject.Interfaces;
using NotificationProject.Models;
using NotificationProject.Services;

namespace NotificationProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationService notifService = new();
            INotificationSender emailChannel = new EmailNotification();
            INotificationSender smsChannel = new SmsNotification();
            List<User> users = [];
            while (true)
            {
                Console.WriteLine("1: Create new user");
                Console.WriteLine("2: Send Email");
                Console.WriteLine("3: Send SMS");
                Console.WriteLine("4: Exit");
                Console.Write("Select option: ");
                string choice = Console.ReadLine() ?? "";
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine() ?? "";
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine() ?? "";
                        Console.Write("Enter Phone Number: ");
                        string phone = Console.ReadLine() ?? "";

                        users.Add(new User(name, email, phone));
                        Console.WriteLine("User created successfully.");
                        break;
                    case "2":
                        if (users.Count == 0)
                        {
                            Console.WriteLine("No users available. Please create user first.");
                            break;
                        }

                        Console.Write($"Enter user index: ");
                        if (int.TryParse(Console.ReadLine(), out int emailIndex) && emailIndex >= 0 && emailIndex < users.Count)
                        {
                            Console.Write("Enter email message: ");
                            string emailMsg = Console.ReadLine()??"";
                            notifService.NotifyUser(users[emailIndex], new Notification(emailMsg), emailChannel);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "3":
                        if (users.Count == 0)
                        {
                            Console.WriteLine("No users available. Please create user");
                            break;
                        }

                        Console.Write($"Enter user index: ");
                        if (int.TryParse(Console.ReadLine(), out int smsIndex) && smsIndex >= 0 && smsIndex < users.Count)
                        {
                            Console.Write("Enter SMS message: ");
                            string smsMsg = Console.ReadLine()??"";
                            notifService.NotifyUser(users[smsIndex], new Notification(smsMsg), smsChannel);
                        }
                        else
                        {
                            Console.WriteLine("Invalid user index.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Exiting program!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}