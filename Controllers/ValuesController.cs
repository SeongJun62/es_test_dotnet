using EnsolTest.Dtos;
using EnsolTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnsolTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;
        private readonly SendService _sendService;

        public SampleController(ILogger<SampleController> logger, SendService sendService)
        {
            _logger = logger;
            _sendService = sendService;
        }

        [HttpPost("log")]
        public IActionResult ReceiveSample([FromBody] ImportClearanceReceive request)
        {
            _logger.LogInformation(
                "Received Sample: {@SampleRequestDto}", request);

            return Ok(request);
        }

        [HttpPost("sync")]
        public IActionResult syncSample([FromBody] SampleRequestDto request)
        {
            //async 전 쓰레드 
            _logger.LogInformation("Controller BEFORE SendAsync, Thread={ThreadId}", Environment.CurrentManagedThreadId);
            bool success = _sendService.SendSync(request);

            //async 이후 쓰레드
            _logger.LogInformation("Controller AFTER SendAsync, Thread={ThreadId}", Environment.CurrentManagedThreadId);
            if (!success)
            {
                return StatusCode(502, "Failed to send request to external API");
            }

            return Ok("Success");
        }

        [HttpPost("async")]
        public async Task<IActionResult> asyncSample([FromBody] SampleRequestDto request)
        {
            //async 전 쓰레드 
            _logger.LogInformation("Controller BEFORE SendAsync, Thread={ThreadId}", Environment.CurrentManagedThreadId);
            bool success = await _sendService.SendAsync(request);

            //async 이후 쓰레드
            _logger.LogInformation("Controller AFTER SendAsync, Thread={ThreadId}", Environment.CurrentManagedThreadId);
            if (!success)
            {
                return StatusCode(502, "Failed to send request to external API");
            }

            return Ok("Success");
        }


    }
}
