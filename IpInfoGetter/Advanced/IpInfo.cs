using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IpInfoGetter
{
    public class IpInfo
    {
        public List<string> information = new List<string>(5);
        [JsonProperty("ip")]
        public string Ip { get; set; } = "";
        [JsonProperty("country")]
        public string Country { get; set; } = "";
        [JsonProperty("region")]
        public string Region { get; set; } = "";
        [JsonProperty("city")]
        public string City { get; set; } = "";
        [JsonProperty("org")]
        public string Org { get; set; } = "";
        [JsonProperty("timezone_gmt")]
        public string Timezone { get; set; } = "";
        [JsonProperty("latitude")]
        public float Latit { get; set; } = 0;
        [JsonProperty("longitude")]
        public float Longit { get; set; } = 0;
        [JsonProperty("country_flag")]
        public string Country_Flag_Svg { get; set; }
        [JsonProperty("isp")]
        public string Using_WebService { get; set; }

        public void SetOptions()
        {
            information.Add("IPv4:  " + Ip);
            information.Add("Country:   " + Country);
            information.Add("Region:   " + Region);
            information.Add("City:  " + City);
            information.Add("Organization:  " + Org);
            information.Add("Service: " + Using_WebService);
            information.Add("Тime zona:  " + Timezone);
            information.Add("Latitude:  " + Latit.ToString());
            information.Add("Longitude: " + Longit.ToString());
        }
    }
}
