using Newtonsoft.Json;

namespace CoronaDoctor.Models.CoronaData
{
    public class CountryData
    {

        [JsonProperty("country")]
        public string Country { get; set; }


        [JsonProperty("cases")]
        public int Cases { get; set; }


        [JsonProperty("todayCases")]
        public int  TodayCases { get; set; }

        [JsonProperty("deaths")]
        public int  Deaths { get; set; }


        [JsonProperty("todayDeaths")]
        public int TodayDeaths { get; set; }


        [JsonProperty("recovered")]
        public int Recovered { get; set; }


        [JsonProperty("critical")]
        public int Critical { get; set; }
    }
}
