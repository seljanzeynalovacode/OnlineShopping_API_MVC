using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;

namespace Online_Shop_API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderDto dto)
        {
            await _orderService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _orderService.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);
            return NoContent();

        }

        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddItem(int orderId, OrderDetailDto itemDto)
        {
            var result = await _orderService.AddItemToOrderAsync(orderId, itemDto);

            if (!result)
            {
                // Əgər service false qaytarıbsa, deməli ya stok çatmayıb, ya da ID səhvdir
                return BadRequest(new { message = "Məhsul əlavə edilə bilmədi. Stok yetərsiz ola bilər və ya ID-lər yanlışdır." });
            }

            return Ok(new { message = "Məhsul sifarişə uğurla əlavə edildi." });
        }
        [HttpDelete("{orderId}/items/{orderDetailId}")]
        public async Task<IActionResult> RemoveItem(int orderId, int orderDetailId)
        {
            var result = await _orderService.RemoveItemFromOrderAsync(orderId, orderDetailId);

            if (!result)
            {
                return NotFound(new { message = "Sifariş detalı tapılmadı və ya bu sifarişə aid deyil." });
            }

            return NoContent();
        }
    }
}
