using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace BusinessLogic.Helper
{
    public class MailLogic
    {
        public async void Send(string email, string subject, string mess)
        {
            //labwork15kafis@gmail.com
            MailAddress from = new MailAddress("science.magazine.dip@gmail.com", "Научный журнал");
            //MailAddress from = new MailAddress("travelagensy.ivansusanin@gmail.com");

            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to);
            //Тема сообщения
            message.Subject = subject; //"Регистрация в научном журнале";
            //Текст сообщения
            message.Body = mess;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");//, 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("science.magazine.dip@gmail.com", "Shetinina2000!");
            await smtp.SendMailAsync(message);
        }
    }
}
