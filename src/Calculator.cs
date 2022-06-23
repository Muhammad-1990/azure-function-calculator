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

        [FunctionName(nameof(Calculator.GetRectangle))]
        [OpenApiOperation(operationId: "GetRectangle", tags: new[] { "Calculate Rectangle diamentions" }, Summary = "Gets the width and height of regtangle", Description = "Gets the width and height of regtangle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(RectangleModel), Summary = "The width used to calculate the regtangle", Description = "The width used to calculate the regtangle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(RectangleModel), Summary = "Rectangle diamentions", Description = "Rectangle diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetRectangle(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetRectangle/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger calculate function processed a request.");

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
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(SquareModel), Summary = "The width used to calculate the Square", Description = "The width used to calculate the Square", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(SquareModel), Summary = "Square diamentions", Description = "Square diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetSquare(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetSquare/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger calculate function processed a request.");

            try
            {
                return new OkObjectResult((await _calculatorService.CalculateSquare(width)).ToString());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName(nameof(Calculator.GetCircle))]
        [OpenApiOperation(operationId: "GetCircle", tags: new[] { "Calculate Circle diamentions" }, Summary = "Gets the width and height of Circle", Description = "Gets the width and height of Circle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(CircleModel), Summary = "The width used to calculate the Circle", Description = "The width used to calculate the Circle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(CircleModel), Summary = "Circle diamentions", Description = "Circle diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetCircle(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetCircle/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger calculate function processed a request.");

            try
            {
                return new OkObjectResult((await _calculatorService.CalculateCircle(width)).ToString());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName(nameof(Calculator.GetGrid))]
        [OpenApiOperation(operationId: "GetGrid", tags: new[] { "Calculate Grid diamentions" }, Summary = "Gets the width and height of Grid", Description = "Gets the width and height of Grid", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(GridModel), Summary = "The width used to calculate the Grid", Description = "The width used to calculate the Grid", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(GridModel), Summary = "Grid diamentions", Description = "Grid diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetGrid(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetGrid/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger calculate function processed a request.");

            try
            {
                return new OkObjectResult((await _calculatorService.CalculateGrid(width)).ToString());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName(nameof(Calculator.GetInverseTriangle))]
        [OpenApiOperation(operationId: "GetInverseTriangle", tags: new[] { "Calculate Inverse Triangle diamentions" }, Summary = "Gets the width and height of Inverse Triangle", Description = "Gets the width and height of Inverse Triangle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(InverseTriangleModel), Summary = "The width used to calculate the Inverse Triangle", Description = "The width used to calculate the Inverse Triangle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(InverseTriangleModel), Summary = "Inverse Triangle diamentions", Description = "Inverse Triangle diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetInverseTriangle(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetInverseTriangle/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger calculate function processed a request.");

            try
            {
                return new OkObjectResult((await _calculatorService.CalculateInverseTriangle(width)).ToString());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName(nameof(Calculator.GetTriangle))]
        [OpenApiOperation(operationId: "GetTriangle", tags: new[] { "Calculate Triangle diamentions" }, Summary = "Gets the width and height of Triangle", Description = "Gets the width and height of Triangle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(TriangleModel), Summary = "The width used to calculate the Triangle", Description = "The width used to calculate the Triangle", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(TriangleModel), Summary = "Triangle diamentions", Description = "Triangle diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetTriangle(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetTriangle/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger calculate function processed a request.");

            try
            {
                return new OkObjectResult((await _calculatorService.CalculateTriangle(width)).ToString());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }        

        [FunctionName(nameof(Calculator.GetThird))]
        [OpenApiOperation(operationId: "GetThird", tags: new[] { "Calculate Third diamentions" }, Summary = "Gets the width and height of Third", Description = "Gets the width and height of Third", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "width", In = ParameterLocation.Path, Required = true, Type = typeof(ThirdModel), Summary = "The width used to calculate the Third", Description = "The width used to calculate the Third", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ThirdModel), Summary = "Third diamentions", Description = "Third diamentions")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert width to decimal", Description = "Cannot convert width to decimal")]
        public async Task<IActionResult> GetThird(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/GetThird/{width}")] HttpRequest req,
            string width,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger calculate function processed a request.");

            try
            {
                return new OkObjectResult((await _calculatorService.CalculateThird(width)).ToString());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}