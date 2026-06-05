using Microsoft.AspNetCore.Mvc;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;

namespace Online_Shop_API.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _customerService.GetAllAsync();
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto dto)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _customerService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _customerService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _customerService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _customerService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
