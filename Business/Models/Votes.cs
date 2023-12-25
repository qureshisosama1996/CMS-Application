using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessLayer.Models
{

    public class Votes
    {
        [JsonPropertyName("negative")]
        public int Negative { get; set; }

        [JsonPropertyName("positive")]
        public int Positive { get; set; }

        [JsonPropertyName("important")]
        public int Important { get; set; }

        [JsonPropertyName("liked")]
        public int Liked { get; set; }

        [JsonPropertyName("disliked")]
        public int Disliked { get; set; }

        [JsonPropertyName("lol")]
        public int Lol { get; set; }

        [JsonPropertyName("toxic")]
        public int Toxic { get; set; }

        [JsonPropertyName("saved")]
        public int Saved { get; set; }

        [JsonPropertyName("comments")]
        public int Comments { get; set; }
    }
}
