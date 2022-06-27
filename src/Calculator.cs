using System;
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


namespace GoldenCalculator
{
    public class Calculator
    {
        private readonly ICalculatorService _calculatorService;

        public Calculator(ICalculatorService calculateService)
        {
            _calculatorService = calculateService;
        }

        [FunctionName(nameof(Calculator.GetCircle))]
        [OpenApiOperation(operationId: "GetCircle", tags: new[] { "Calculate Circle diamentions" }, Summary = "Gets the width and height of Circle", Description = "Gets the width and height of Circle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(string), Summary = "The width used to calculate the Circle", Description = "The width used to calculate the Circle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Circle diamentions", Description = "Circle diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetCircle(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetCircle/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger GetCircle function processed a request.");

            try
            {
                return new OkObjectResult((await _calculatorService.CalculateCircle(width)).ToString());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName(nameof(Calculator.GetRectangle))]
        [OpenApiOperation(operationId: "GetRectangle", tags: new[] { "Calculate Rectangle diamentions" }, Summary = "Gets the width and height of regtangle", Description = "Gets the width and height of regtangle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(string), Summary = "The width used to calculate the regtangle", Description = "The width used to calculate the regtangle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Rectangle diamentions", Description = "Rectangle diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetRectangle(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetRectangle/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger GetRectangle function processed a request.");

            try
            {
                return new OkObjectResult(await _calculatorService.CalculateRectangle(width));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName(nameof(Calculator.GetSquare))]
        [OpenApiOperation(operationId: "GetSquare", tags: new[] { "Calculate Square diamentions" }, Summary = "Gets the width and height of Square", Description = "Gets the width and height of Square", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(string), Summary = "The width used to calculate the Square", Description = "The width used to calculate the Square", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Square diamentions", Description = "Square diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetSquare(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetSquare/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger GetSquare function processed a request.");

            try
            {
                return new OkObjectResult((await _calculatorService.CalculateSquare(width)).ToString());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}