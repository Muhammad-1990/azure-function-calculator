using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace GoldenRatioCalculator
{
    public static class Calculate
    {
        [FunctionName(nameof(Calculate.CalculateGoldenRatio))]
        [OpenApiOperation(operationId: "CalculateGoldenRatio", tags: new[] { "Calculate the Golden Ratio" }, Summary = "Gets the Golden Ratio values", Description = "This gets the Golden Ratio values that was calculated from the input.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "input", In = ParameterLocation.Path, Required = true, Type = typeof(GoldenRatio), Summary = "The value to calculate the golden ratio from", Description = "The value to be used as the base for calculating the golden ratio.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(GoldenRatio), Summary = "The calculated golden ratio values", Description = "This returns golden ratio values a and b.")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid input supplied", Description = "Invalid input supplied")]

        public static async Task<IActionResult> CalculateGoldenRatio(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/CalculateGoldenRatio/{input}")] HttpRequest req,
            string input,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger calculate function processed a request.");

            if (decimal.TryParse(input, out decimal ab))
            {
                decimal a = ab / 1.618M;
                decimal b = a / 1.618M;
                return new OkObjectResult(new GoldenRatio { Ab = ab, A = a, B = b }.ToString());
            }
            else
            {
                return new BadRequestObjectResult($"Invalid input supplied");
            }
        }
    }
}