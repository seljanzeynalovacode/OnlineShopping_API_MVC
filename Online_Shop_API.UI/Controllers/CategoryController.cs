using Microsoft.AspNetCore.Mvc;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;

namespace Online_Shop_API.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _categoryService.GetAllAsync();
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _categoryService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _categoryService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _categoryService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
