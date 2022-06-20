using Newtonsoft.Json;

namespace GoldenRatioCalculator
{
    public class GoldenRatio
    {
        [JsonProperty("ab")]
        public decimal Ab { get; set; }

        [JsonProperty("a")]
        public decimal A { get; set; }
        
        [JsonProperty("b")]
        public decimal B { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,
                                                new JsonSerializerSettings
                                                {
                                                    NullValueHandling = NullValueHandling.Ignore,
                                                    DefaultValueHandling = DefaultValueHandling.Ignore
                                                });
        }
    }
}