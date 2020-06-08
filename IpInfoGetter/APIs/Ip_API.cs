using Newtonsoft.Json;
using System.Collections.Generic;

namespace IpInfoGetter.Advanced
{
    class Ip_API
    {
        public List<string> information = new List<string>(9);
        [JsonProperty("query")]
        public string Ip { get; set; } = "";
        [JsonProperty("country")]
        public string Country { get; set; } = "";
        [JsonProperty("region")]
        public string Region { get; set; } = "";
        [JsonProperty("city")]
        public string City { get; set; } = "";
        [JsonProperty("as")]
        public string Org { get; set; } = "";
        [JsonProperty("timezone")]
        public string Timezone { get; set; } = "";
        [JsonProperty("lat")]
        public float Latit { get; set; } = 0;
        [JsonProperty("lon")]
        public float Longit { get; set; } = 0;
        [JsonProperty("isp")]
        public string Using_WebService { get; set; }
        [JsonProperty("success")]
        public string Success { get; set; }
        public void SetOptions()
        {
            information.Add("IPv4:  " + Ip);
            information.Add("Country:   " + Country);
            information.Add("Region:   " + Region);
            information.Add("City:  " + City);
            information.Add("Organization:  " + Org);
            information.Add("Service: " + Using_WebService);
            information.Add("Timezone: " + Timezone);
            information.Add("Latitude:  " + Latit.ToString());
            information.Add("Longitude: " + Longit.ToString());
        }
    }
}
