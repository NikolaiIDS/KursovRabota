using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.ViewModels.UserVMs
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}
