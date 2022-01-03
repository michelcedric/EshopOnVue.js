using MinimalApi.Endpoint;

namespace EshopOnVue.js.Spa.Controllers
{
    /// <summary>
    /// Endp point to manage WeatherForecast
    /// </summary>  
    public class GetAllWeatherForecastEndpoint : IEndpoint<IResult>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GetAllWeatherForecastEndpoint> _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        public GetAllWeatherForecastEndpoint(ILogger<GetAllWeatherForecastEndpoint> logger)
        {
            _logger = logger;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("WeatherForecast", HandleAsync)
                .Produces<IEnumerable<WeatherForecast>>(StatusCodes.Status200OK);
        }

        /// <summary>
        /// Get all WeatherForecast available
        /// </summary>
        /// <returns></returns>
        public Task<IResult> HandleAsync()
        {
            var rng = new Random();
            var values = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();

            return Task.FromResult(Results.Ok(values));
        }
    }
}
