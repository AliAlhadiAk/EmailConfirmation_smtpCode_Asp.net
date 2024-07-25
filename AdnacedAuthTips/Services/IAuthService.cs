using AdnacedAuthTips.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace AdnacedAuthTips.Services
{
    public interface IAuthService
    {
        public Task<bool> LoginAsync();
        public Task<bool> RegisterAsync(RegisterDTO dto);
        public Task<bool> ConfirmEmailAsync();
        public Task<bool> TwoFactorAuth();
    }
}
