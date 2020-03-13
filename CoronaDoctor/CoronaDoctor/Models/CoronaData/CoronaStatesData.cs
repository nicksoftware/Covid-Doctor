using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CoronaDoctor.Models.CoronaData
{
    public class CoronaStatesData
    {
        [JsonProperty("cases")]
        public int Cases { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("recovered")]
        public int Recovered { get; set; }
    }
}
