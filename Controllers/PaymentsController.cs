using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAptApi.Models;
using SmartAptApi.Services;

namespace SmartAptApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;
        public PaymentController(IPaymentService service) => _service = service;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());
        [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));
        [HttpPost] public async Task<IActionResult> Create([FromBody] Payment payment) => Ok(await _service.Create(payment));
    }
}
