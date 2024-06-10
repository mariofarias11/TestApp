using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Dto;
using WebApp.Services.Forecast;

namespace WebApp.Pages
{
    public class WeatherModel : PageModel
    {
        private readonly IForecastService _forecastService;
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<WeatherForecast>? Forecasts = Enumerable.Empty<WeatherForecast>();

        public WeatherModel(ILogger<IndexModel> logger, IForecastService forecastService)
        {
            _logger = logger;
            _forecastService = forecastService;
        }

        public async Task OnGet()
        {
            try
            {
                Forecasts = await _forecastService.GetForecastsAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
            }
        }
    }
}