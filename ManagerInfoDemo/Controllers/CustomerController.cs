using System;
using ManagerInfoDemo.Filter;
using ManagerInfoDemo.Models;
using ManagerInfoDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ManagerInfoDemo.Controllers
{
    [SessionAuthorize]
    public class CustomerController : Controller
    {
        private const int DefaultPageSize = 10;

        private readonly ICustomerService _customerService;
        private readonly IEmailService _emailService;

        public CustomerController(ICustomerService customerService, IEmailService emailService)
        {
            _customerService = customerService;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customers = _customerService.GetPaged(pageSize: DefaultPageSize);
            return View(customers);
        }

        [HttpGet]
        public IActionResult List(string? keyword, bool? isVerify, int page = 1)
        {
            var customers = _customerService.GetPaged(keyword, isVerify, page, DefaultPageSize);
            return PartialView("_CustomerTable", customers);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                return PartialView("_CustomerForm", new Customer());
            }

            var customer = _customerService.GetById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return PartialView("_CustomerForm", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                ModelState.AddModelError(nameof(Customer.FullName), "Vui lòng nhập họ tên.");
            }

            if (!ModelState.IsValid)
            {
                return PartialView("_CustomerForm", customer);
            }

            if (customer.Id == 0)
            {
                customer.CreatedBy = HttpContext.Session.GetInt32("UserId");
                _customerService.Create(customer, out var verificationToken);
                if (!string.IsNullOrWhiteSpace(customer.Email) && !string.IsNullOrEmpty(verificationToken))
                {
                    var verifyLink = Url.Action(
                        "Verify",
                        "CustomerVerification",
                        new { email = customer.Email, token = verificationToken },
                        Request.Scheme);

                    if (!string.IsNullOrWhiteSpace(verifyLink))
                    {
                        await _emailService.SendCustomerVerificationEmailAsync(customer.Email!, verifyLink);
                    }
                }
            }
            else
            {
                var updated = _customerService.Update(customer);
                if (!updated)
                {
                    return NotFound();
                }
            }

            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var deleted = _customerService.Delete(id);
            if (!deleted)
            {
                return Json(new { success = false, message = "Khách hàng không tồn tại." });
            }

            return Json(new { success = true });
        }
    }
}
