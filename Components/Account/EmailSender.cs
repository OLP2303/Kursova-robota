using BlazorApp2.Components.Account.Pages.Manage;
using BlazorApp2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlazorApp2.Components.Account
{
    // Remove the "else if (EmailSender is IdentityNoOpEmailSender)" block from RegisterConfirmation.razor after updating with a real implementation.
    //internal sealed class IdentityNoOpEmailSender : IEmailSender<ApplicationUser>
    //{
    //    private readonly IEmailSender emailSender = new NoOpEmailSender();

    //    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
    //        emailSender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");

    //    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
    //        emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

    //    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
    //        emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
    //}
    public class EmailSender : IEmailSender<ApplicationUser>
    {
        private readonly string smtpHost = "smtp.gmail.com"; // SMTP-сервер Gmail (або інший)
        private readonly string smtpUser = "dmito.palagitskiy@gmail.com"; // Ваша електронна пошта (відправник)
        private readonly string smtpPass = "tmoc ucjz lkzo cduq"; // Пароль від вашої пошти (можна використовувати App Password для Gmail)

        // Відправлення підтвердження email
        public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            using (var client = new SmtpClient(smtpHost))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUser),
                    Subject = "Confirm your email",
                    Body = confirmationLink,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);
            }
        }

        private readonly IEmailSender emailSender = new NoOpEmailSender();
       

        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            using (var client = new SmtpClient(smtpHost))
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUser),
                    Subject = "Підтвердьте зміну паролю",
                    Body = resetLink,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);
            }
        }

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
            emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
    }
}
