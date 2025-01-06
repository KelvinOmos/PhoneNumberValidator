using Microsoft.AspNetCore.Mvc;
using PhoneNumber.Application.Interfaces;

namespace PhoneNumber.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IPhoneNumberService _service;

        public PhoneNumberController(IPhoneNumberService service)
        {
            _service = service;
        }

        [HttpGet("validate-phone/{phoneNumber}")]
        public async Task<IActionResult> ValidatePhoneNumber(string phoneNumber)
        {
            var result = await _service.ValidatePhoneNumber(phoneNumber);
            return Ok(result);
        }
    }
}
