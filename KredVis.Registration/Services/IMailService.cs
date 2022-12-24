using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KredVis.Registration.Services
{
    public interface IMailService
    {
        Task<bool> SendEmailAsync(string receiverEmail, string subject, string content);
    }
   
    public class MailService : IMailService
    { 
        public async Task<bool> SendEmailAsync(string receiverEmail, string subject, string content)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.To.Add(receiverEmail);
                    mail.From = new MailAddress("srisaisarath@kyrostechnologies.com", "Kyrostechnologies", Encoding.UTF8);
                    mail.Subject = subject;
                    mail.Body = content;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("srisaisarath@kyrostechnologies.com", "S@$i@2512");
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        await smtp.SendMailAsync(mail);
                        return true;
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

