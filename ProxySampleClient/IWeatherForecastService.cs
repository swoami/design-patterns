public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
}

