using System;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class CalculatorUnitTest
    {
         [Fact]
        public void GetSquare_()
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            SquareModel square = Task.Run(async () =>
            {
                return JsonConvert.DeserializeObject<SquareModel>(await cs.CalculateSquare("25"));
            }).Result;
            
            //Assert
            Assert.Equal(square.Height, square.Width);
            Assert.Equal(15.451174289245982694684796044M, square.Width);
            Assert.Equal(15.451174289245982694684796044M, square.Height);
        }
    }
}
