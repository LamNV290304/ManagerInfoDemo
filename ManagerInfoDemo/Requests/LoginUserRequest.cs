using System.ComponentModel.DataAnnotations;

namespace ManagerInfoDemo.Requests
{
    public class LoginUserRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
    }
}
