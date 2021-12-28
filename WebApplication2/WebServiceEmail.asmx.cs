using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace WebApplication2
{
    /// <summary>
    /// Summary description for WebServiceEmail
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceEmail : System.Web.Services.WebService
    {
        //אימייל
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        //פעולה השולחת מייל למנהל העמוד
        public void sendEmail(string from, string to, string subject, string body, string password, string email)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                var basicCredential = new NetworkCredential(from, password);
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress(from);

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;
                    smtpClient.EnableSsl = true;
                    message.From = fromAddress;
                    message.Subject = subject;
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = body;
                    message.To.Add(to);

                    try
                    {
                        smtpClient.Send(message);
                    }
                    catch (Exception ex)
                    {
                        //Error, could not send the message
                        //Response.Write(ex.Message);
                        
                    }
                    ans(email);
                }
            }
        }

        
        public void ans(string to)
        {
            //פעולה המחזירה לשולח מייל שאומר שפנייתו בטיפול
            using (SmtpClient smtpClient = new SmtpClient())
            {
                var basicCredential = new NetworkCredential("bricksbraker@gmail.com", "shira1310");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress("bricksbraker@gmail.com");

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;
                    smtpClient.EnableSsl = true;
                    message.From = fromAddress;
                    message.Subject = "Bricks Braker";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = "Your message was received and will be forwarded to the appropriate";
                    message.To.Add(to);

                    try
                    {
                        smtpClient.Send(message);
                    }
                    catch (Exception ex)
                    {
                        //Error, could not send the message
                        //Response.Write(ex.Message);

                    }
                }
            }
        }
    }
}
