using System.Net.Http.Json;
using CinemaManagement.Common.Exceptions;

namespace CinemaManagement.Integrations.AI
{
    public class GeminiService
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly string _model;
        private readonly HttpClient _httpClient;

        public GeminiService(string apiKey, string baseUrl, string model)
        {
            _apiKey = apiKey;
            _baseUrl = baseUrl;
            _model = model;
            _httpClient = new HttpClient();
        }

        public async Task<string> SendMessageAsync(string message)
        {
            var url = $"{_baseUrl}/{_model}:generateContent?key={_apiKey}";
            
            var requestBody = new
            {
                contents = new[]
                {
                    new { parts = new[] { new { text = message } } }
                }
            };

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new IntegrationException($"Lỗi gọi Gemini API: {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<GeminiResponse>();
            return result?.candidates?[0]?.content?.parts?[0]?.text ?? "Không có phản hồi";
        }
    }

    public class GeminiResponse
    {
        public Candidate[] candidates { get; set; }
    }

    public class Candidate
    {
        public Content content { get; set; }
    }

    public class Content
    {
        public Part[] parts { get; set; }
    }

    public class Part
    {
        public string text { get; set; }
    }
}
