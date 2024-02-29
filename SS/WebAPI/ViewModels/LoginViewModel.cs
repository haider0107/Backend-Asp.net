using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public String? UserName { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
