using Newtonsoft.Json;

namespace LoRa_Logger.Models
{
    /// <summary>
    /// Class that represents a measure extracted from kerlink device csv
    /// </summary>
    public sealed class Measure
    {
        [JsonIgnore]
        public int id { get; set; }

        [JsonIgnore]
        public string msgId { get; set; }
        public string devEui { get; set; }
        public string devAddr { get; set; }
        public string time { get; set; }
        public string payload { get; set; }

        [JsonIgnore]
        public double frequency { get; set; }
        public int sf { get; set; }
        public string gwEui { get; set; }
        public string gwName { get; set; }

        [JsonIgnore]
        public int gwChannel { get; set; }
        public int gwRssi { get; set; }

        [JsonIgnore]
        public double gwSnr { get; set; }
        public int devUplinkCounter { get; set; }

        public override string ToString()
        {
            return "Measure: " + gwName + " " + gwRssi;
        }
    }
}