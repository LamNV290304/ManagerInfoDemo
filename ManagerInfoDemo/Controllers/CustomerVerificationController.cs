using ManagerInfoDemo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagerInfoDemo.Controllers
{
    public class CustomerVerificationController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerVerificationController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Verify(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
            {
                return View("VerificationResult", false);
            }

            var success = _customerService.VerifyCustomer(email, token);
            return View("VerificationResult", success);
        }
    }
}
