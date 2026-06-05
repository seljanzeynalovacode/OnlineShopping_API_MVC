using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;
using Online_Shop_API.DAL.Entities;

namespace Online_Shop_API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var details = await _orderDetailService.GetAllAsync();
            return Ok(details);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var detail = await _orderDetailService.GetByIdAsync(id);
            if (detail == null)
                return NotFound();
            return Ok(detail);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderDetailDto dto)
        {
            await _orderDetailService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDetailDto dto)
        {
            if (id != dto.Id)
                return BadRequest();
            await _orderDetailService.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderDetailService.DeleteAsync(id);
            return NoContent();
        }
    }
}
