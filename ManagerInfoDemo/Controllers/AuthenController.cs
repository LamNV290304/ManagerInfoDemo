using ManagerInfoDemo.Filter;
using ManagerInfoDemo.Models;
using ManagerInfoDemo.Requests;
using ManagerInfoDemo.Services.Interface;
using ManagerInfoDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ManagerInfoDemo.Controllers
{
    public class AuthenController : Controller
    {
        private readonly IAuthenService _authenService;
        private readonly IEmailService _emailService;
        private readonly IStaffService _staffService;

        public AuthenController(IAuthenService authenService, IEmailService emailService, IStaffService staffService)
        {
            _authenService = authenService;
            _emailService = emailService;
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserRequest loginUser)
        {
            Staff user = _authenService.DoLogin(loginUser);

            if (user.Username.IsNullOrEmpty())
            {
                TempData["Error"] = "Sai tài khoản hoặc mật khẩu";
                return View(loginUser);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Email", user.Email);

            return RedirectToAction("Home", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPassRequest model)
        {
            var user = _staffService.GetUserByEmail(model.Email);
            if (user == null)
            {
                TempData["Error"] = "Email is not exist!";
                return View(model);
            }

            var token = _authenService.SaveToken(model.Email);
            var resetLink = Url.Action("ResetPassword", "Authen", new { email = model.Email, token }, Request.Scheme);

            await _emailService.SendEmailAsync(model.Email, resetLink);

            return RedirectToAction("SendMailSuccess");
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            var user = _staffService.GetUserByEmail(email);
            if (user == null)
            {
                TempData["Error"] = "Email is not exist!";
                return RedirectToAction("ForgotPassword");
            }

            bool isValidToken = _authenService.VerifyToken(email, token);
            if (isValidToken == false)
            {
                TempData["Error"] = "Link is expried or something happen!";
                return RedirectToAction("ForgotPassword");
            }


            return View(new ResetPassRequest { Email = email });
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPassRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = _staffService.GetUserByEmail(model.Email);

                bool isSuccess = _authenService.DoResetPassword(model.Email, model.Password);
                if (isSuccess)
                {
                    TempData["Success"] = "Reset password successfully!";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Error"] = "Something went wrong!";
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SendMailSuccess()
        {
            return View();
        }

        [SessionAuthorize]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Authen");
        }
    }
}
