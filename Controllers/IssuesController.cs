using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAptApi.Models;
using SmartAptApi.Services;

namespace SmartAptApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _service;
        public IssueController(IIssueService service) => _service = service;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));
        [HttpPost] public async Task<IActionResult> Create([FromBody] Issue issue) => Ok(await _service.Create(issue));
        [HttpPut("{id}/status")] public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status) => Ok(await _service.UpdateStatus(id, status));
    }
}
