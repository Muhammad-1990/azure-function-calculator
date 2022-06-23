using System.Threading.Tasks;

namespace GoldenCalculator
{
    public interface ICalculatorService 
    {
        Task<string> CalculateSquare(string width);
        Task<string> CalculateCircle(string width);
        Task<string> CalculateRectangle(string width);
        Task<string> CalculateThird(string width);
        Task<string> CalculateGrid(string width);
        Task<string> CalculateTriangle(string width);
        Task<string> CalculateInverseTriangle(string width);
    }
}