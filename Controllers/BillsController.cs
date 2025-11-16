using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAptApi.Models;
using SmartAptApi.Services;

namespace SmartAptApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _service;
        public BillController(IBillService service) => _service = service;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));
        [HttpPost] public async Task<IActionResult> Create([FromBody] Bill bill) => Ok(await _service.Create(bill));
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Bill bill) => Ok(await _service.Update(id, bill));
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) => Ok(await _service.Delete(id));
    }
}
