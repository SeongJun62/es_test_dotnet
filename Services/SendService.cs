using EnsolTest.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EnsolTest.Services
{
    public class SendService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SendService> _logger;
        private readonly string _sampleEndpoint;

        public SendService(HttpClient httpClient, ILogger<SendService> logger, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sampleEndpoint = configuration["ExternalApi:SampleEndpoint"] ?? throw new InvalidOperationException("설정이 없습니다");
        }

        public async Task<bool> SendAsync(SampleRequestDto dto, CancellationToken ct = default)
        {
            _logger.LogInformation(
                "Async Sending dto: {@SampleRequestDto}", dto);

            var response = await _httpClient.PostAsJsonAsync(_sampleEndpoint, dto, ct);
            return response.IsSuccessStatusCode;
        }

        public bool SendSync(SampleRequestDto dto)
        {
            _logger.LogInformation(
                "Sync Sending dto: {@SampleRequestDto}", dto);

            try
            {
                var response = _httpClient.PostAsJsonAsync(_sampleEndpoint, dto).GetAwaiter().GetResult();

                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Sync Request Failed to {Endpoint}", _sampleEndpoint);
                return false;
            }
        }
    }
}
