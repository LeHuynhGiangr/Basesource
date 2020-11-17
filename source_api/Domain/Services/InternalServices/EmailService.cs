using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.InternalServices
{
    public interface IInternalEmailService
    {
        void Setting();
        void Send(string To, string content);
    }
    public class EmailService : IInternalEmailService
    {
        //async void SendEmail(string mailAddress, string content)
        //{

        //    var client = new System.Net.Mail.SmtpClient("smtp.example.com", 111);
        //    client.UseDefaultCredentials = false;
        //    client.EnableSsl = true;
        //    client.Port = 587;
        //    client.Host = "smtp.gmail.com";

        //    client.Credentials = new System.Net.NetworkCredential("cauviewchome3@gmail.com", "cqxouerrcxzbnxdv");

        //    var mailMessage = new System.Net.Mail.MailMessage();
        //    mailMessage.From = new System.Net.Mail.MailAddress("cauviewchome3@gmail.com");

        //    mailMessage.To.Add(mailAddress);

        //    if (!string.IsNullOrEmpty(mailAddress))
        //    {
        //        mailMessage.CC.Add(mailAddress);
        //    }

        //    mailMessage.Body = content;

        //    mailMessage.Subject = "Confirm Email Social Network";

        //    mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        //    mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

        //    await client.SendMailAsync(mailMessage);
        //}
        public void Send(string To, string content)
        {
            throw new NotImplementedException();
        }

        public void Setting()
        {
            throw new NotImplementedException();
        }
    }
}
