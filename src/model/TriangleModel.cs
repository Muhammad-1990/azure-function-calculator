using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class TriangleModel : BaseModel
    {
        [JsonProperty("width")]
        public decimal Width { get; }

        [JsonProperty("height")]
        public decimal Height { get; }

        public TriangleModel(decimal w)
        {
            this.Width = w / 1.618M;
            this.Height = w / 1.618M;
        }
    }
}