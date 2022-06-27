using System.Threading.Tasks;

namespace GoldenCalculator
{
    public interface ICalculatorService 
    {
        Task<string> CalculateCircle(string width);
        Task<string> CalculateRectangle(string width);
        Task<string> CalculateSquare(string width);
    }
}