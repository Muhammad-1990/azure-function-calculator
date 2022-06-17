using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GoldenRatio
{
    public static class Calculate
    {
        [FunctionName("Calculate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/calculate/{input}")] HttpRequest req,
            string input,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger calculate function processed a request.");

            decimal.TryParse(input, out decimal ab);

            decimal a = ab / 1.618M;

            decimal b = a / 1.618M;
            
            var calc = new { ab, a , b };

            return new OkObjectResult(JsonConvert.SerializeObject(calc));
        }
    }
}
