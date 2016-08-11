using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

namespace dipndipInventory.Helpers
{
    public class Email
    {
        public void sendMail(string _toaddr, string _sub, string _content)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try
            {
                m.From = new MailAddress("focusinfotechmyd@gmail.com", "Focus Infotech");
                m.To.Add(new MailAddress(_toaddr, _toaddr));
                m.Subject = _sub;
                m.IsBodyHtml = true;
                m.Body = _content;

                //FileStream fs = new FileStream("C:\\test.pdf", FileMode.Open, FileAccess.Read);
                //Attachment a = new Attachment(fs, "test.pdf", MediaTypeNames.Application.Octet);
                //m.Attachments.Add(a);

                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new System.Net.NetworkCredential("focusinfotechmyd@gmail.com","Mayyanad1");
                sc.EnableSsl = true;
                
                sc.Send(m);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }
}
