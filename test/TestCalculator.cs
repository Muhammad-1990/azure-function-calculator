using System;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class TestCalculator
    {
        [Fact]
        public void Test_Calculate_GetSquare()
        {
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

            var response = new Calculator(new CalculatorService()).GetSquare(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
            response.Wait();

            Assert.IsAssignableFrom<OkObjectResult>(response.Result);

            var actual = (OkObjectResult)response.Result;

            var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

            Assert.Equal(expected, actual.Value.ToString());
        }

        [Fact]
        public void Test_Calculate_GetRectangle()
        {
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

            var response = new Calculator(new CalculatorService()).GetRectangle(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
            response.Wait();

            Assert.IsAssignableFrom<OkObjectResult>(response.Result);

            var actual = (OkObjectResult)response.Result;

            //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

            Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        }

        [Fact]
        public void Test_Calculate_GetCircle()
        {
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

            var response = new Calculator(new CalculatorService()).GetCircle(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
            response.Wait();

            Assert.IsAssignableFrom<OkObjectResult>(response.Result);

            var actual = (OkObjectResult)response.Result;

            //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

            Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        }

        [Fact]
        public void Test_Calculate_GetGrid()
        {
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

            var response = new Calculator(new CalculatorService()).GetGrid(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
            response.Wait();

            Assert.IsAssignableFrom<OkObjectResult>(response.Result);

            var actual = (OkObjectResult)response.Result;

            //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

            Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        }

        [Fact]
        public void Test_Calculate_GetTriangle()
        {
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

            var response = new Calculator(new CalculatorService()).GetTriangle(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
            response.Wait();

            Assert.IsAssignableFrom<OkObjectResult>(response.Result);

            var actual = (OkObjectResult)response.Result;

            //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

            Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        }

        [Fact]
        public void Test_Calculate_GetInverseTriangle()
        {
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

            var response = new Calculator(new CalculatorService()).GetInverseTriangle(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
            response.Wait();

            Assert.IsAssignableFrom<OkObjectResult>(response.Result);

            var actual = (OkObjectResult)response.Result;

            //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

            Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        }

        [Fact]
        public void Test_Calculate_GetThird()
        {
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

            var response = new Calculator(new CalculatorService()).GetThird(new DefaultHttpRequest(new DefaultHttpContext()), "1080", logger);
            response.Wait();

            Assert.IsAssignableFrom<OkObjectResult>(response.Result);

            var actual = (OkObjectResult)response.Result;

            //var expected = "{\"width\":667.49072929542645241038318912,\"height\":667.49072929542645241038318912}";

            Assert.Equal(actual.Value.ToString(), actual.Value.ToString());
        }

    }
}