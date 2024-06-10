using WebApp.Dto;

namespace WebApp.Services.Forecast
{
    public interface IForecastService
    {
        Task<IEnumerable<WeatherForecast>?> GetForecastsAsync();
    }
}
