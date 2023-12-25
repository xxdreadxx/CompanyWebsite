using System.Net.Mail;
using System.Net;

namespace CompanyWeb.Models
{
    public class Email
    {
        public static string Address = "mailnhcsatech@gmail.com"; //Địa chỉ email của bạn
        public static string Password = "satech@123"; //Mật khẩu ứng dụng

        public void Send(string sendTo, string subject, string message)
        {
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(Address, Password);
                smtp.Send(Address, sendTo, subject, message);
            }
        }
    }
}
