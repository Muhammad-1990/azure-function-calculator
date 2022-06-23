using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class ThirdModel : BaseModel
    {
        [JsonProperty("width")]
        public decimal Width { get; }

        [JsonProperty("height")]
        public decimal Height { get; }

        [JsonProperty("v1")]
        public decimal V1 { get; }

        [JsonProperty("v2")]
        public decimal V2 { get; }

        [JsonProperty("h1")]
        public decimal H1 { get; }

        [JsonProperty("h2")]
        public decimal H2 { get; }


        public ThirdModel(decimal w)
        {
            this.Width = w;
            this.V1 = this.Width/3;
            this.V2 = this.V1 * 2;
            this.H1 = this.V1 / 1.618M;
            this.H2 = this.H1 * 2;
            this.Height = this.H1 * 3;
        }
    }
}