using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAptApi.Models;
using SmartAptApi.Services;

namespace SmartAptApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _service;
        public TenantController(ITenantService service) => _service = service;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));
        [HttpPost] public async Task<IActionResult> Create([FromBody] Tenant tenant) => Ok(await _service.Create(tenant));
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] Tenant tenant) => Ok(await _service.Update(id, tenant));
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) => Ok(await _service.Delete(id));
    }
}
