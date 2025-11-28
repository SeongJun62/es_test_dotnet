using EnsolTest.Dtos;
using EnsolTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EnsolTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _SAPPOURL;

        public TestController(ILogger<SampleController> logger, HttpClient httpClient, IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = httpClient;
            _SAPPOURL = configuration["SAPPOURL"] ?? throw new InvalidOperationException("설정이 없습니다");
        }

        [HttpPost("MaterialMaster")]
        public IActionResult ReceiveSample([FromBody] MMHeader request)
        {

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                };
                var response = _httpClient.PostAsJsonAsync(_SAPPOURL, request, options).GetAwaiter().GetResult();
                var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                _logger.LogInformation("ERP OUTER RESPONSE = {StatusCode} BODY={response}", response.StatusCode, responseBody);
                var materialMaster = JsonSerializer.Deserialize<MaterialMaster>(responseBody);
                _logger.LogInformation(
                "Received Sample: {@MaterialMaster}", materialMaster);
                return Ok(materialMaster);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sync Request Failed to {Endpoint}", _SAPPOURL);
                return StatusCode(500, "ERP 연동 중 서버 오류가 발생했습니다.");
            }
        }

        [HttpPost("ImportClearanceTransfer")]
        public IActionResult syncSample([FromBody] ImportClearanceTransfer request)
        {
            _logger.LogInformation(
                "Received Sample: {@ImportClearanceTransfer}", request);

            var response = new ICTReturn
            {
                RETURN_CODE = "S",
                RETURN_MSG = "SUCCESS"
            };

            return Ok(response);
        }

        [HttpPost("ImportClearanceReceive")]
        public async Task<IActionResult> asyncSample([FromBody] ImportClearanceReceive request)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                };
                var response = _httpClient.PostAsJsonAsync(_SAPPOURL, request, options).GetAwaiter().GetResult();
                return Ok(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sync Request Failed to {Endpoint}", _SAPPOURL);
                return StatusCode(500, "ERP 연동 중 서버 오류가 발생했습니다.");
            }
        }


    }
}
