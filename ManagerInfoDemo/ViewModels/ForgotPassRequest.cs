using System.ComponentModel.DataAnnotations;

namespace ManagerInfoDemo.ViewModels
{
    public class ForgotPassRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
