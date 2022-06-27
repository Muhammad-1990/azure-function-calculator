using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class CalculatorService : ICalculatorService
    {
        public decimal doValidation(string width){
            
            // We do not support calculations on non decimal values.
            if ((!decimal.TryParse(width, out decimal w)))
                throw new FormatException($"Cannot convert width({width}) to decimal.");
            
            // We do not support calculations on non positive values.
            if (w <= 0)
                throw new FormatException($"Cannot convert width({width}) to decimal.");

            return w;
        }

        public async Task<string> CalculateCircle(string width) => await Task.Run(() =>
        {
            decimal w = doValidation(width);
            decimal _pi = 3.14M;
            decimal _diameter = w / 1.618M;
            decimal _radius = _diameter / 2;
            decimal _circumference = 2 * _pi * _radius;

            return JsonConvert.SerializeObject(new { Circumference = _circumference.ToString("0.##"), Diameter = _diameter.ToString("0.##"), Radius = _radius.ToString("0.##") });
        });

        public async Task<string> CalculateRectangle(string width) => await Task.Run(() =>
        {
            decimal w = doValidation(width);

            decimal _width = w;
            decimal _height = w / 1.618M;

            return JsonConvert.SerializeObject(new { Height = _height.ToString("0.##"), Width = _width.ToString("0.##") });
        });

        public async Task<string> CalculateSquare(string width) => await Task.Run(() =>
        {
            decimal w = doValidation(width);

            decimal _width = w / 1.618M;
            decimal _height = _width;

            return JsonConvert.SerializeObject(new { Height = _height.ToString("0.##"), Width = _width.ToString("0.##") });
        });

    }
}