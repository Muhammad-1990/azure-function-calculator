using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class SquareModel : BaseModel
    {
        [JsonProperty("width")]
        public decimal Width { get; set; }

        [JsonProperty("height")]
        public decimal Height { get; set; }
    }
}