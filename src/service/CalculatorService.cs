using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class CalculatorService : ICalculatorService
    {
        public async Task<string> CalculateCircle(string width) => await Task.Run(() =>
        {
            if (!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            decimal _pi = 3.14M;
            decimal _diameter = w / 1.618M;
            decimal _radius = _diameter / 2;
            decimal _circumference = 2 * _pi * _radius;

            return JsonConvert.SerializeObject(new { Circumference = _circumference, Diameter = _diameter, Radius = _radius });
        });

        public async Task<string> CalculateGrid(string width) => await Task.Run(() =>
        {
            if (!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            decimal _width = w;
            decimal _v1 = _width / 3;
            decimal _v2 = _v1 * 2;
            decimal _h1 = _v1 / 1.618M;
            decimal _h2 = _h1 + ( _h1 / 1.618M);
            decimal _height = (_h1 * 2) + _h1;

            return JsonConvert.SerializeObject(new { Height = _height, Width = _width, V1 = _v1, V2 = _v2, H1 = _h1, H2 = _h2 });
        });

        public Task<string> CalculateInverseTriangle(string width)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CalculateRectangle(string width) => await Task.Run(() =>
        {
            if (!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            decimal _width = w;
            decimal _height = w / 1.618M;

            return JsonConvert.SerializeObject(new { Height = _height, Width = _width });
        });

        public async Task<string> CalculateSquare(string width) => await Task.Run(() =>
        {
            if (!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            decimal _width = w / 1.618M;
            decimal _height = _width;

            return JsonConvert.SerializeObject(new { Height = _height, Width = _width });
        });

        public async Task<string> CalculateThird(string width) => await Task.Run(() =>
        {
            if (!decimal.TryParse(width, out decimal w))
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            decimal _width = w;
            decimal _v1 = _width/3;
            decimal _v2 = _v1 * 2;
            decimal _h1 = _v1 / 1.618M;
            decimal _h2 = _h1 * 2;
            decimal _height = _h1 * 3;

            return JsonConvert.SerializeObject(new { Height = _height, Width = _width, V1 = _v1, V2 = _v2, H1 = _h1, H2 = _h2 });
        });

        public Task<string> CalculateTriangle(string width)
        {
            throw new NotImplementedException();
        }
    }
}