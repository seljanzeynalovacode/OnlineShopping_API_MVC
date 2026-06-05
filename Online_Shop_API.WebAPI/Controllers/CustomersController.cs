using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services;
using Online_Shop_API.BLL.Services.Interfaces;

namespace Online_Shop_API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto dto)
        {
            await _customerService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _customerService.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }

    }
}
