using System.Text.Json;

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary, int TemperatureF);

public class WeatherForecastPresenter
{
    private readonly IWeatherForecastService weatherForecastService;

    public WeatherForecastPresenter(IWeatherForecastService weatherForecastService)
    {
        this.weatherForecastService = weatherForecastService;
    }

    public async Task PresentAsync()
    {
        var weatherForecasts = await weatherForecastService.GetWeatherForecastsAsync();
        var latestForecast = weatherForecasts.OrderByDescending(wf => wf.Date).First();

        Console.WriteLine($"The weather on {latestForecast.Date} will be {latestForecast.Summary}, average temperature will be {latestForecast.TemperatureC} C ");
    }
}
