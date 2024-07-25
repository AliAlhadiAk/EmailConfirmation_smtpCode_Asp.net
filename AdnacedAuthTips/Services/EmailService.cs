
using System.Net.Mail;
using System.Net;

namespace AdnacedAuthTips.Services
{
    public class EmailService : IEmailService
    {
        public Task<bool> SendEmailAsync(string from ,string email,string subject, string body)
        {
          

            
            string recipientEmail = email;

            
            string smtpServer = "smtp.office365.com";
            int smtpPort = 587; 

            try
            {
                // Create SMTP client and configure credentials
                using (var client = new System.Net.Mail.SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true; // Enable SSL/TLS
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    string link = "https://localhost:7189/swagger/index.html";

                    // Create email message
                    using (var message = new MailMessage(senderEmail, recipientEmail))
                    {
                        message.Subject = "Email Confirmation";
                        message.Body = $"{code}";
                        message.IsBodyHtml = false;

                        // Send email
                        client.Send(message);


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email. Error message: {ex.Message}");

            }
        }
    }
}
}
