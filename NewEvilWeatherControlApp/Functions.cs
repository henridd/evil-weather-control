using EvilWeatherControlApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewEvilWeatherControlApp
{
    public class Functions
    {
        private readonly ILogger _logger;

        public Functions(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<Functions>();
        }

        [Function("SetWeather")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "{country}/Weather")] HttpRequestData req,
            string country)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<WeatherControlRequest>(requestBody);

            if (data == null)
                return new BadRequestObjectResult("Invalid body");

            var message = $"Evil powers have been requested for {country}! Weather: {data.Weather} Duration: {data.Duration}";

            _logger.LogInformation(message);

            return new OkObjectResult(message);
        }
    }
}
