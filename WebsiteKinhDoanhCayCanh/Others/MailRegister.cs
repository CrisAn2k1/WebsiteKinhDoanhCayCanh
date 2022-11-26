using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace WebsiteKinhDoanhCayCanh.Others
{
    public class MailRegister
    {
        public static bool SendMail(string SenderEmail, string Subject, string Message, bool IsBodyHtml = false)
        {
            bool status = false;
            try
            {
                string smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
                string smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                string FormEmailId = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
                string Password = ConfigurationManager.AppSettings["FromEmailPassWord"].ToString();
                var EmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FormEmailId, EmailDisplayName);
                mailMessage.Subject = Subject;
                mailMessage.Body = Message;
                mailMessage.IsBodyHtml = IsBodyHtml;
                mailMessage.To.Add(new MailAddress(SenderEmail));

                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpHost;
                smtp.EnableSsl = true;

                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = mailMessage.From.Address;
                networkCredential.Password = Password;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = Convert.ToInt32(smtpPort);
                smtp.Send(mailMessage);
                status = true;
                return status;
            }
            catch (Exception e)
            {
                return status;
            }
        }
    }
}