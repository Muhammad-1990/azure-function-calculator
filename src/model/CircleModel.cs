using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class CircleModel : BaseModel
    {
        [JsonProperty("radius")]
        public decimal Radius { get; }

        [JsonProperty("diameter")]
        public decimal Diameter { get; }

        [JsonProperty("circumference")]
        public decimal Circumference { get; }

        private decimal _pi = 3.14M;

        public CircleModel(decimal w)
        {
            this.Diameter = w / 1.618M;
            this.Radius = this.Diameter/2;
            this.Circumference = 2 * _pi * this.Radius;
        }
    }
}