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
    public class CalculatorServiceUnitTest
    {
        [Fact]
        public void CalculateCircle_GivenWidth100_ShouldReturnExpectedCircleCircimferenceAndDiameterAndRadius()
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            string actualCircle = Task.Run(async () => { return await cs.CalculateCircle("100"); }).Result;

            //Assert
            var expectedCircle = JsonConvert.SerializeObject(new
            {
                Circumference = 194.06674907292954264524103832M,
                Diameter = 61.804697156983930778739184178M,
                Radius = 30.902348578491965389369592089M
            });

            Assert.Equal(expectedCircle, actualCircle);
        }

        [Fact]
        public void CalculateSquare_GivenWidth100_ShouldReturnExpectedSquareHeightAndWidth()
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            string actualSquare = Task.Run(async () => { return await cs.CalculateSquare("100"); }).Result;
            
            //Assert
            var expectedSquare = JsonConvert.SerializeObject(new
            {
                Height = 61.804697156983930778739184178M,
                Width = 61.804697156983930778739184178M
            });

            Assert.Equal(expectedSquare, actualSquare);
        }

        [Fact]
        public void CalculateGrid_GivenWidth100_ShouldReturnExpectedGridHeightAndWidthAndV1V2AndH1H2()
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            string actualGrid = Task.Run(async () => { return await cs.CalculateGrid("100"); }).Result;
            
            //Assert
            var expectedGrid = JsonConvert.SerializeObject(new
            {
                Height = 61.804697156983930778739184176M,
                Width = 100.0M,
                V1 = 33.333333333333333333333333333M,
                V2 = 66.666666666666666666666666666M,
                H1 = 20.601565718994643592913061392M,
                H2 = 33.334301021216302179385905268M
            });

            Assert.Equal(expectedGrid, actualGrid);
        }

        [Fact]
        public void CalculateInverseTriangle_GivenWidth100_ShouldReturnNotImplementedException()
        {            
            //Assert
            Assert.Throws<NotImplementedException>(delegate { new CalculatorService().CalculateInverseTriangle("100"); });
        }

        [Fact]
        public void CalculateTriangle_GivenWidth100_ShouldReturnNotImplementedException()
        {            
            //Assert
            Assert.Throws<NotImplementedException>(delegate { new CalculatorService().CalculateTriangle("100"); });
        }

        [Fact]
        public void CalculateRectangle_GivenWidth100_ShouldReturnExpectedRectangleHeightAndWidth()
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            string actualRectangle = Task.Run(async () => { return await cs.CalculateRectangle("100"); }).Result;
            
            //Assert
            var expectedRectangle = JsonConvert.SerializeObject(new
            {
                Height = 61.804697156983930778739184178M,
                Width = 100.0M
            });

            Assert.Equal(expectedRectangle, actualRectangle);
        }

        [Fact]
        public void CalculateThird_GivenWidth100_ShouldReturnExpectedThirdHeightAndWidthAndV1V2AndH1H2()
        {
            //Arrange
            CalculatorService cs = new CalculatorService();

            //Act
            string actualThird = Task.Run(async () => { return await cs.CalculateThird("100"); }).Result;
            
            //Assert
            var expectedThird = JsonConvert.SerializeObject(new
            {
                Height = 61.804697156983930778739184176M,
                Width = 100.0M,
                V1 = 33.333333333333333333333333333M,
                V2 = 66.666666666666666666666666666M,
                H1 = 20.601565718994643592913061392M,
                H2 = 41.203131437989287185826122784M
            });
            
            Assert.Equal(expectedThird, actualThird);
        }
    }
}
