using Microsoft.AspNetCore.Mvc;
using Restaurant.Shared.Domain;

namespace Restaurant.Shared.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBaseController<T, TCommand, TDto> : ControllerBase where T : BaseEntity where TCommand : class where TDto : class
    {
        private readonly IBaseService<T, TDto> _service;

        public MyBaseController(IBaseService<T, TDto> service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetListAsync();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var menuItem = await _service.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _service.AddAsync(command);
            return CreatedAtAction(nameof(GetAll), command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TCommand command)
        {
            if (command == null)
            {
                return BadRequest("Güncellenecek kayıt boş gönderilemez!.");
            }
            await _service.UpdateAsync(id, command);
            return Ok("Güncelleme işlemi başarılı.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok("Silme işlemi başarılı.");
        }
    }
}
