using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CMS.BusinessLayer.Models
{
    public class CryptoNews
    {
        [JsonPropertyName("kind")]
        public string kind { get; set; }

        [JsonPropertyName("domain")]
        public string domain { get; set; }

        [JsonPropertyName("source")]
        public Source source { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("published_at")]
        public DateTime published_at { get; set; }

        [JsonPropertyName("slug")]
        public string slug { get; set; }

        [JsonPropertyName("currencies")]
        public List<Currency> currencies { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime created_at { get; set; }

        [JsonPropertyName("votes")]
        public Votes votes { get; set; }
    }
}
