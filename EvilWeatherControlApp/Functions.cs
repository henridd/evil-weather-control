using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace EvilWeatherControlApp
{

    public static class Functions
    {
        [FunctionName("SetWeather")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "{country}/Weather")] HttpRequest req,
            string country,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<WeatherControlRequest>(requestBody);

            if (data == null)
                return new BadRequestObjectResult("Invalid body");

            var message = $"Evil powers have been requested for {country}! Weather: {data.Weather} Duration: {data.Duration}";

            log.LogInformation(message);

            return new OkObjectResult(message);
        }
    }
}
