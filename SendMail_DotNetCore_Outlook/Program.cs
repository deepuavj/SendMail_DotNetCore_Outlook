using System;
using System.Net.Mail;

namespace SendMail_DotNetCore_Outlook
{
    class Program
    {
        static void Main(string[] args)
        {
            string from = "*****@hotmail.com";
            Console.WriteLine("Enter email id :");
            var email = Console.ReadLine();
            Console.WriteLine("Enter email subject :");
            var subject = Console.ReadLine();
            Console.WriteLine("Enter email body :");
            var body = Console.ReadLine();

            try {
                Console.Clear();
                Console.WriteLine("Sending............");
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credential = new System.Net.NetworkCredential(from,"***password***");
                client.EnableSsl = true;
                client.Credentials = credential;
                MailMessage message = new MailMessage(from,email);
                message.Subject = subject;
                message.Body ="<h1>"+ body + "/<h1>";
                message.IsBodyHtml = true;
                client.Send(message);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Email sent successfully!!!");
                
            }
            catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email sent failed!!!");
                Console.WriteLine(e);
            }
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
