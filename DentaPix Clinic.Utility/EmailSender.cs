using Microsoft.AspNetCore.Identity.UI.Services;

namespace DentaPix_Clinic.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Not Working as of May 30, 2022, ​​Google no longer supports the use of third-party apps or devices which ask you to sign in to your Google Account using only your username and password.

            //var emailToSend = new MimeMessage();
            //emailToSend.From.Add(MailboxAddress.Parse("dentapix@clinic.com"));
            //emailToSend.To.Add(MailboxAddress.Parse(email));
            //emailToSend.Subject = subject;
            //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            ////send email
            //using (var emailClient = new SmtpClient())
            //{
            //    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //    emailClient.Authenticate("myemail@gmail.com", "myPassword");
            //    emailClient.Send(emailToSend);
            //    emailClient.Disconnect(true);
            //}
            return Task.CompletedTask;
        }
    }
}