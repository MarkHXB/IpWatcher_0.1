using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace IpWatcher_0._1
{
    class Program
    {
        static void Main(string[] args)
        {
           SendMail();
        }
        
        private static string Ip()
        {
            string ip = new WebClient().DownloadString("xxxxxxx");
            return ip;
        }
        private static void SendMail()
        {
            string ip = Ip();

            var toAddress = new MailAddress("xxxxx@gmail.com", "xxxxx");
            var fromAddress = toAddress;

            const string fromPassword = "xxxxxx";
            const string subject = "IpWatcher";
            string body = $"Your ip has changed!\nTo this:\n {ip}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
