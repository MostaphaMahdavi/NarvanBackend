using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace Narvan.Services.Commons.MailSenders
{
    public class SendEmail
    {
    
       

        public static void Send(string to,string subject,string body,
            string smtp,
            string sendMail,
            string title,
            int port,
            string emailPassword)
        {
           
            
            
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtp);
            mail.From = new MailAddress(sendMail,title);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = port;
            SmtpServer.Credentials = new System.Net.NetworkCredential(sendMail, emailPassword);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}