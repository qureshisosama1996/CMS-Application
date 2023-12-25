using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CMS.BusinessLayer.Models
{
    public class Currency
    {
        [JsonPropertyName("code")]
        public string code { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("slug")]
        public string slug { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }
}
