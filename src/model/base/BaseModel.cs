using Newtonsoft.Json;

namespace GoldenCalculator
{
    public class BaseModel
    {
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