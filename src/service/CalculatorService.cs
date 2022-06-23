using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class CalculatorService : ICalculatorService
    {
        public async Task<string> CalculateCircle(string width) => await Task.Run(() =>
        {
            if(!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            return new CircleModel(w).ToString();
        });

        public async Task<string> CalculateGrid(string width)  => await Task.Run(() =>
        {
            if(!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            return new GridModel(w).ToString();
        });

        public async Task<string> CalculateInverseTriangle(string width) => await Task.Run(() =>
        {
            if(!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            return new InverseTriangleModel(w).ToString();
        });

        public async Task<string> CalculateRectangle(string width) => await Task.Run(() =>
        {
            if(!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            return new RectangleModel(w).ToString();
        });

        public async Task<string> CalculateSquare(string width) => await Task.Run(() =>
        {
            if(!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            decimal _width = w / 1.618M;
            decimal _height = _width;

            var square = new SquareModel{ Width = _width , Height = _height};

            return JsonConvert.SerializeObject(square);
        });

        public async Task<string> CalculateThird(string width) => await Task.Run(() =>
        {
            if(!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            return new ThirdModel(w).ToString();
        });

        public async Task<string> CalculateTriangle(string width) => await Task.Run(() =>
        {
            if(!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            return new TriangleModel(w).ToString();
        });
    }
}