namespace AdnacedAuthTips.Services
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(string from , string email);
    }
}
