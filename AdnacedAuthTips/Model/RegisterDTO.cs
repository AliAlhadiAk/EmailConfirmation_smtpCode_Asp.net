using System.ComponentModel.DataAnnotations;

namespace AdnacedAuthTips.Model
{
    public class RegisterDTO
    {
        [Required]
        public string UserName {  get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

    }
}
