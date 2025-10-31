using System.ComponentModel.DataAnnotations;

namespace ManagerInfoDemo.Requests
{
    public class ForgotPassRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
