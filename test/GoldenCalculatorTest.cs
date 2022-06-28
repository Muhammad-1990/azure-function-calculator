using System;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Moq;

namespace GoldenCalculator
{
    public class GoldenCalculatorTest
    {
        [Theory]
        [InlineData(194.07, 61.80, 30.90, "100.00")]
        public void CalculateCircle_GivenWidth100_ShouldReturnExpectedCircleCircimferenceAndDiameterAndRadius(decimal Circumference, decimal Diameter, decimal Radius, string inputWidth)
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            string actualCircle = Task.Run(async () => { return await cs.CalculateCircle(inputWidth); }).Result;

            //Assert
            var expectedCircle = JsonConvert.SerializeObject(new
            {
                Circumference = Circumference.ToString("0.##"),
                Diameter = Diameter.ToString("0.##"),
                Radius = Radius.ToString("0.##")
            });

            Assert.Equal(expectedCircle, actualCircle);
        }

        [Theory]
        [InlineData("qwerty")]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData("")]
        [InlineData(null)]
        public async void CalculateCircle_GivenNegativeOrZeroOrNullOrNonNumericWidth_ShouldThrowFormatException(string inputWidth)
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            var ex = await Assert.ThrowsAsync<FormatException>(async () => {  await cs.CalculateCircle(inputWidth); });

            //Assert
            Assert.Equal("Cannot convert width(" + inputWidth + ") to decimal.", ex.Message);
        }

        [Theory]
        [InlineData(61.80, 100.00, "100.00")]
        public void CalculateRectangle_GivenWidth100_ShouldReturnExpectedRectangleHeightAndWidth(decimal Height, decimal Width, string inputWidth)
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            string actualRectangle = Task.Run(async () => { return await cs.CalculateRectangle(inputWidth); }).Result;
            
            //Assert
            var expectedRectangle = JsonConvert.SerializeObject(new
            {
                Height = Height.ToString("0.##"),
                Width = Width.ToString("0.##")
            });

            Assert.Equal(expectedRectangle, actualRectangle);
        }

        [Theory]
        [InlineData("qwerty")]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData("")]
        [InlineData(null)]
        public async void CalculateRectangle_GivenNegativeOrZeroOrNullOrNonNumericWidth_ShouldThrowFormatException(string inputWidth)
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            var ex = await Assert.ThrowsAsync<FormatException>(async () => {  await cs.CalculateRectangle(inputWidth); });

            //Assert
            Assert.Equal("Cannot convert width(" + inputWidth + ") to decimal.", ex.Message);
        }

        [Theory]
        [InlineData(61.80, 61.80, "100.00")]
        public void CalculateSquare_GivenWidth100_ShouldReturnExpectedSquareHeightAndWidth(decimal Height, decimal Width, string inputWidth)
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            string actualSquare = Task.Run(async () => { return await cs.CalculateSquare(inputWidth); }).Result;
            
            //Assert
            var expectedSquare = JsonConvert.SerializeObject(new
            {
                Height = Height.ToString("0.##"),
                Width = Width.ToString("0.##")
            });

            Assert.Equal(expectedSquare, actualSquare);
        }

        [Theory]
        [InlineData("qwerty")]
        [InlineData("0")]
        [InlineData("-1")]
        [InlineData("")]
        [InlineData(null)]
        public async void CalculateSquare_GivenNegativeOrZeroOrNullOrNonNumericWidth_ShouldThrowFormatException(string inputWidth)
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            var ex = await Assert.ThrowsAsync<FormatException>(async () => {  await cs.CalculateSquare(inputWidth); });

            //Assert
            Assert.Equal("Cannot convert width(" + inputWidth + ") to decimal.", ex.Message);
        }

        [Fact]
        public void GetCircle_GivenMock_IsAssignableFrom_OkObjectResult()
        {
            // Arrange
            var CalculatorServiceMoq = new Mock<ICalculatorService>();
            CalculatorServiceMoq.Setup<Task<string>>(cs => cs.CalculateCircle(It.IsAny<string>())).Returns(Task.Run(() => { return ""; }));
            var HttpReqMoq = new Mock<HttpRequest>();
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger>();

            // Act
            var response = new Calculator(CalculatorServiceMoq.Object).GetCircle(HttpReqMoq.Object, "", logger.Object);
            
            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(response.Result);
        }

        [Fact]
        public void GetCircle_GivenMock_IsAssignableFrom_BadRequestObjectResult()
        {
            // Arrange
            var CalculatorServiceMoq = new Mock<ICalculatorService>();
            CalculatorServiceMoq.Setup<Task<string>>(cs => cs.CalculateCircle(It.IsAny<string>())).Throws(new FormatException());
            var HttpReqMoq = new Mock<HttpRequest>();
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger>();

            // Act
            var response = new Calculator(CalculatorServiceMoq.Object).GetCircle(HttpReqMoq.Object, "", logger.Object);
            
            // Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetRectangle_GivenMock_IsAssignableFrom_OkObjectResult()
        {
            // Arrange
            var CalculatorServiceMoq = new Mock<ICalculatorService>();
            CalculatorServiceMoq.Setup<Task<string>>(cs => cs.CalculateRectangle(It.IsAny<string>())).Returns(Task.Run(() => { return ""; }));
            var HttpReqMoq = new Mock<HttpRequest>();
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger>();

            // Act
            var response = new Calculator(CalculatorServiceMoq.Object).GetRectangle(HttpReqMoq.Object, "", logger.Object);
            
            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(response.Result);
        }

        [Fact]
        public void GetRectangle_GivenMock_IsAssignableFrom_BadRequestObjectResult()
        {
            // Arrange
            var CalculatorServiceMoq = new Mock<ICalculatorService>();
            CalculatorServiceMoq.Setup<Task<string>>(cs => cs.CalculateRectangle(It.IsAny<string>())).Throws(new FormatException());
            var HttpReqMoq = new Mock<HttpRequest>();
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger>();

            // Act
            var response = new Calculator(CalculatorServiceMoq.Object).GetRectangle(HttpReqMoq.Object, "", logger.Object);
            
            // Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetSquare_GivenMock_IsAssignableFrom_OkObjectResult()
        {
            // Arrange
            var CalculatorServiceMoq = new Mock<ICalculatorService>();
            CalculatorServiceMoq.Setup<Task<string>>(cs => cs.CalculateSquare(It.IsAny<string>())).Returns(Task.Run(() => { return ""; }));
            var HttpReqMoq = new Mock<HttpRequest>();
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger>();

            // Act
            var response = new Calculator(CalculatorServiceMoq.Object).GetSquare(HttpReqMoq.Object, "", logger.Object);
            
            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(response.Result);
        }

        [Fact]
        public void GetSquare_GivenMock_IsAssignableFrom_BadRequestObjectResult()
        {
            // Arrange
            var CalculatorServiceMoq = new Mock<ICalculatorService>();
            CalculatorServiceMoq.Setup<Task<string>>(cs => cs.CalculateSquare(It.IsAny<string>())).Throws(new FormatException());
            var HttpReqMoq = new Mock<HttpRequest>();
            var logger = new Mock<Microsoft.Extensions.Logging.ILogger>();

            // Act
            var response = new Calculator(CalculatorServiceMoq.Object).GetSquare(HttpReqMoq.Object, "", logger.Object);
            
            // Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(response.Result);
        }
    }
}
