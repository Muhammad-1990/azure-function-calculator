using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class RectangleModel : BaseModel
    {
        [JsonProperty("width")]
        public decimal Width { get; }

        [JsonProperty("height")]
        public decimal Height { get; }


        public RectangleModel(decimal w)
        {
            this.Width = w;
            this.Height = w / 1.618M;
        }
    }
}