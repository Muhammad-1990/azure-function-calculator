using System;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace test;

public class TestCalculate
{
    [Fact]
    public void Test_Calculate_Golden_Ratio()
    {
        var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        var response = GoldenRatioCalculator.Calculate.CalculateGoldenRatio(new DefaultHttpRequest(new DefaultHttpContext()), "720.0", logger);
        response.Wait();

        Assert.IsAssignableFrom<OkObjectResult>(response.Result);

        var result = (OkObjectResult)response.Result;
        var gr = new GoldenRatioCalculator.GoldenRatio { Ab = 720.0M, A =  444.99381953028430160692212608M, B = 275.02708252798782546781342774M }.ToString();

        Assert.Equal(gr,  result.Value);
    }
}