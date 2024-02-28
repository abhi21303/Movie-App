using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace MovieWebApp.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string fname,string lname,string email,string phone,string message)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("abhipatidar21303@gnail.com","anp@21303"),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("abhipatidar21303@gmail.com.com"),
                Subject = "Support Request",
                Body = $"First Name: {fname}\nLast Name: {lname}\nEmail: {email}\nPhone: {phone}\nMessage: {message}"
            };

            mailMessage.To.Add("abhipatel21303@gmail.com"); // Email address B

            smtpClient.Send(mailMessage);

            return RedirectToAction("Home");
        }
            
        }
}
