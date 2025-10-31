using System;
using ManagerInfoDemo.Filter;
using ManagerInfoDemo.Models;
using ManagerInfoDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagerInfoDemo.Controllers
{
    [SessionAuthorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customers = _customerService.GetAll();
            return View(customers);
        }

        [HttpGet]
        public IActionResult List(string? keyword, bool? isVerify)
        {
            var customers = _customerService.GetAll(keyword, isVerify);
            return PartialView("_CustomerTableRows", customers);
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
        public IActionResult Upsert(Customer customer)
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
                customer.CreatedAt = DateTime.Now;
                customer.CreatedBy = HttpContext.Session.GetInt32("UserId");
                _customerService.Create(customer);
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
