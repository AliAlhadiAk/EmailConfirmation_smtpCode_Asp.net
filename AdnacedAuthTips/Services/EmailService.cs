
using System.Net.Mail;
using System.Net;

namespace AdnacedAuthTips.Services
{
    public class EmailService : IEmailService
    {
        public Task<bool> SendEmailAsync(string from ,string email,string subject, string body)
        {
            string senderEmail = "alialhadiabokhalil@outlook.com"; // Replace with your Outlook email address
            string senderPassword = "Asp.net_c#123"; // Replace with your Outlook email password

            // Recipient's email address
            string recipientEmail = email;

            // Outlook SMTP server address and port
            string smtpServer = "smtp.office365.com";
            int smtpPort = 587; // Outlook SMTP port (TLS)

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
                        message.Subject = "Forgot Reset Password using al5aaaaaaaaaaaal smtp !!!!!!";
                        message.Body = $"To reset your password please click on the link below {link} ";
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
