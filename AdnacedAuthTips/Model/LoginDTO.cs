using System.ComponentModel.DataAnnotations;

namespace AdnacedAuthTips.Model
{
    public class LoginDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
