using AdnacedAuthTips.AppDbContext;
using AdnacedAuthTips.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AdnacedAuthTips.Services
{
    public class AuthService:IAuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly JwtAuthentication _jwt;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AuthService> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public readonly IConfiguration Configuration;
        private readonly IEmailService _emailService 
        public AuthService(AppDbContext appDbContext,IEmailService emailservice, JwtAuthentication jwt, UserManager<IdentityUser> userManager, ILogger<AuthService> logger, RoleManager<IdentityRole> roleManager, IConfiguration configurationManager)
        {
            _appDbContext = appDbContext;
            _jwt = jwt;
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
            configurationManager = Configuration;
            emailservice = _emailService

        }

        public Task<bool> LoginAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(RegisterDTO dto)
        {
            bool response;
            var checkEmail = await _userManager.FindByEmailAsync(dto.Email);
            if (checkEmail != null)
            {
                return response = false;
            }

            var account = new IdentityUser
            {
                Email = dto.Email,
                UserName = dto.UserName,

            };

            var checkPass = await _userManager.CreateAsync(account, dto.Password);

            if (!checkPass.Succeeded)
            {
                var errors = string.Join(", ", checkPass.Errors.Select(e => e.Description));
                response = false;
            }

            var code = _userManager.GenerateEmailConfirmationTokenAsync(account);
            _emailService.SendEmailAsync("",dto.Email, "EmailConfirmation",code);
            response = true;


            if (dto.Email == "alialhadiabokhalil@gmail.com")
            {
                var roleResult = await _userManager.AddToRoleAsync(account, UserROLES.Admin);
                if (!roleResult.Succeeded)
                {
                    var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    response = false;
                }
            }
            else
            {
                var roleResult = await _userManager.AddToRoleAsync(account, UserROLES.User);
                if (!roleResult.Succeeded)
                {
                    var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    response = false;
                }
            }

        }


        public async Task<bool> ConfirmEmailAsync(string?email , string? code)
        {
              if(code is null || email is null)
              {

                 return false;

              }

            var user = _userManager.FindByEmailAsync(email);
            if(user is null)
            {
                return false;
            }

            var isVerified = _userManager.ConfirmEmailAsync(user,code);

            if(isVerified.Succeeded)
            {
                return true;
            }
          


        }

        public Task<bool> TwoFactorAuth()
        {
            throw new NotImplementedException();
        }
    }
}
    }
