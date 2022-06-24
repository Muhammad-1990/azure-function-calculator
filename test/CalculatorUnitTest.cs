using System;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Moq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

using Microsoft.Azure.WebJobs;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace GoldenCalculator
{
    public class CalculatorUnitTest
    {
        [Fact]
        public void GetSquare_Given_CalculatorServiceMock_Should_Return_Expected_Square_Width_And_Height()
        {
            // Arrange
            var expectedSquare = JsonConvert.SerializeObject(new
            {
                Height = 61.804697156983930778739184178M,
                Width = 61.804697156983930778739184178M
            });

            var CalculatorServiceMoq = new Mock<ICalculatorService>();
            CalculatorServiceMoq.Setup<Task<string>>(cs => cs.CalculateSquare(It.IsAny<string>())).Returns(Task.Run(() => { return expectedSquare; }));

            var HttpReqMoq = new Mock<HttpRequest>();
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger>();

            // Act
            var response = new Calculator(CalculatorServiceMoq.Object).GetSquare(HttpReqMoq.Object, "100", logger.Object);
            
            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(response.Result);
            Assert.Equal(expectedSquare, ((OkObjectResult)response.Result).Value.ToString());
        }

        //  [Fact]
        // public void GetSquare()
        // {
        //     var host = new HostBuilder()
        //     .UseEnvironment("Development")
        //         .ConfigureWebJobs(x => {
        //             x.AddAzureStorage();
        //             x.AddHttp();
        //             x.UseExternalStartup();
                    
        //         })
        //         .UseConsoleLifetime()
        //         .ConfigureServices(s =>
        //         {
        //             s.AddSingleton<ICalculatorService>((cs) => { return new CalculatorService(); });
        //         })
        //         .Build();

        //     using (host) {
        //         host.Run();
                
        //         HttpClient client = new HttpClient();
        //         var response = client.GetAsync("http://localhost:7071/api/v1/GetCircle/100");
        //         response.Wait();
        //     }

        // }

        // [Fact]
        // public void Test_Calculate_GetRectangle()
        // {
        //     var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        //     var response = new Calculator(new CalculatorService()).GetRectangle(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
        //     response.Wait();

        //     Assert.IsAssignableFrom<OkObjectResult>(response.Result);

        //     var actual = (OkObjectResult)response.Result;

        //     //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

        //     Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        // }

        // [Fact]
        // public void Test_Calculate_GetCircle()
        // {
        //     var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        //     var response = new Calculator(new CalculatorService()).GetCircle(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
        //     response.Wait();

        //     Assert.IsAssignableFrom<OkObjectResult>(response.Result);

        //     var actual = (OkObjectResult)response.Result;

        //     //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

        //     Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        // }

        // [Fact]
        // public void Test_Calculate_GetGrid()
        // {
        //     var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        //     var response = new Calculator(new CalculatorService()).GetGrid(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
        //     response.Wait();

        //     Assert.IsAssignableFrom<OkObjectResult>(response.Result);

        //     var actual = (OkObjectResult)response.Result;

        //     //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

        //     Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        // }

        // [Fact]
        // public void Test_Calculate_GetTriangle()
        // {
        //     var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        //     var response = new Calculator(new CalculatorService()).GetTriangle(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
        //     response.Wait();

        //     Assert.IsAssignableFrom<OkObjectResult>(response.Result);

        //     var actual = (OkObjectResult)response.Result;

        //     //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

        //     Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        // }

        // [Fact]
        // public void Test_Calculate_GetInverseTriangle()
        // {
        //     var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        //     var response = new Calculator(new CalculatorService()).GetInverseTriangle(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
        //     response.Wait();

        //     Assert.IsAssignableFrom<OkObjectResult>(response.Result);

        //     var actual = (OkObjectResult)response.Result;

        //     //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

        //     Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        // }

        // [Fact]
        // public void Test_Calculate_GetThird()
        // {
        //     var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        //     var response = new Calculator(new CalculatorService()).GetThird(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
        //     response.Wait();

        //     Assert.IsAssignableFrom<OkObjectResult>(response.Result);

        //     var actual = (OkObjectResult)response.Result;

        //     //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

        //     Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        // }

    }
}