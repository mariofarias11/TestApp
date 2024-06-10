using Newtonsoft.Json;
using WebApp.Dto;

namespace WebApp.Services.Forecast
{
    public class ForecastService : IForecastService
    {
        private readonly HttpClient _httpClient;

        public ForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecast>?> GetForecastsAsync()
        {
            var response = await _httpClient.GetAsync("WeatherForecast");

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseContent);
        }
    }
}
