using Microsoft.AspNetCore.Mvc;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;
using Online_Shop_API.DAL.Enums;

namespace Online_Shop_API.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _orderService.GetAllAsync();
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = customers;
            ViewBag.Statuses = System.Enum.GetValues(typeof(Status));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderDto dto)
        {
            if (ModelState.IsValid)
            {
                await _orderService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = customers;
            ViewBag.Statuses = System.Enum.GetValues(typeof(Status));
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _orderService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = customers;
            ViewBag.Statuses = System.Enum.GetValues(typeof(Status));
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, OrderDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _orderService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = customers;
            ViewBag.Statuses = System.Enum.GetValues(typeof(Status));
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _orderService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _orderService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
