using Microsoft.Extensions.DependencyInjection;

partial class Program
{
    static async Task Main(string[] args)
    {
        // Setup DI
        var services = new ServiceCollection();

        // Register Named HttpClient
        services.AddHttpClient("WeatherForecast", client =>
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
        });

        // Register WeatherForecastService that uses the named HttpClient
        services.AddHttpClient<IWeatherForecastService, WeatherForecastService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
        });

        services.AddTransient<WeatherForecastPresenter>();

        var serviceProvider = services.BuildServiceProvider();
        var weatherForecastService = serviceProvider.GetRequiredService<WeatherForecastPresenter>();
        await weatherForecastService.PresentAsync();

        Console.ReadLine();
    }
}
