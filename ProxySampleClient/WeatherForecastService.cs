using System.Text.Json;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly HttpClient _httpClient;

    public WeatherForecastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5052/weatherforecast");
        response.EnsureSuccessStatusCode();
        var forecast = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<WeatherForecast[]>(forecast, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        })!;
    }
}



