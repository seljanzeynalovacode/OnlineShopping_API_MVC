using Microsoft.AspNetCore.Mvc;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;

namespace Online_Shop_API.UI.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderDetailController(IOrderDetailService orderDetailService, IOrderService orderService, IProductService productService)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var models = await _orderDetailService.GetAllAsync();
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var orders = await _orderService.GetAllAsync();
            var products = await _productService.GetAllAsync();
            ViewBag.Orders = orders;
            ViewBag.Products = products;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderDetailDto dto)
        {
            if (ModelState.IsValid)
            {
                await _orderDetailService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            var orders = await _orderService.GetAllAsync();
            var products = await _productService.GetAllAsync();
            ViewBag.Orders = orders;
            ViewBag.Products = products;
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _orderDetailService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var orders = await _orderService.GetAllAsync();
            var products = await _productService.GetAllAsync();
            ViewBag.Orders = orders;
            ViewBag.Products = products;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, OrderDetailDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _orderDetailService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            var orders = await _orderService.GetAllAsync();
            var products = await _productService.GetAllAsync();
            ViewBag.Orders = orders;
            ViewBag.Products = products;
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _orderDetailService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderDetailService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _orderDetailService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
