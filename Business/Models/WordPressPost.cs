// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
using System.Text.Json.Serialization;

public class About
{
    [JsonPropertyName("href")]
    public string href { get; set; }
}

public class Author
{
    [JsonPropertyName("embeddable")]
    public bool embeddable { get; set; }

    [JsonPropertyName("href")]
    public string href { get; set; }
}

public class Collection
{
    [JsonPropertyName("href")]
    public string href { get; set; }
}

public class Content
{
    [JsonPropertyName("rendered")]
    public string rendered { get; set; }

    [JsonPropertyName("protected")]
    public bool @protected { get; set; }
}

public class Cury
{
    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("href")]
    public string href { get; set; }

    [JsonPropertyName("templated")]
    public bool templated { get; set; }
}

public class Excerpt
{
    [JsonPropertyName("rendered")]
    public string rendered { get; set; }

    [JsonPropertyName("protected")]
    public bool @protected { get; set; }
}

public class Guid
{
    [JsonPropertyName("rendered")]
    public string rendered { get; set; }
}

public class Links
{
    [JsonPropertyName("self")]
    public List<Self> self { get; set; }

    [JsonPropertyName("collection")]
    public List<Collection> collection { get; set; }

    [JsonPropertyName("about")]
    public List<About> about { get; set; }

    [JsonPropertyName("author")]
    public List<Author> author { get; set; }

    [JsonPropertyName("replies")]
    public List<Reply> replies { get; set; }

    [JsonPropertyName("version-history")]
    public List<VersionHistory> versionhistory { get; set; }

    [JsonPropertyName("wp:attachment")]
    public List<WpAttachment> wpattachment { get; set; }

    [JsonPropertyName("wp:term")]
    public List<WpTerm> wpterm { get; set; }

    [JsonPropertyName("curies")]
    public List<Cury> curies { get; set; }
}

public class Meta
{
    [JsonPropertyName("footnotes")]
    public string footnotes { get; set; }
}

public class Reply
{
    [JsonPropertyName("embeddable")]
    public bool embeddable { get; set; }

    [JsonPropertyName("href")]
    public string href { get; set; }
}

public class WordPressPost
{
    [JsonPropertyName("id")]
    public int id { get; set; }

    [JsonPropertyName("date")]
    public DateTime date { get; set; }

    [JsonPropertyName("date_gmt")]
    public DateTime date_gmt { get; set; }

    [JsonPropertyName("guid")]
    public Guid guid { get; set; }

    [JsonPropertyName("modified")]
    public DateTime modified { get; set; }

    [JsonPropertyName("modified_gmt")]
    public DateTime modified_gmt { get; set; }

    [JsonPropertyName("slug")]
    public string slug { get; set; }

    [JsonPropertyName("status")]
    public string status { get; set; }

    [JsonPropertyName("type")]
    public string type { get; set; }

    [JsonPropertyName("link")]
    public string link { get; set; }

    [JsonPropertyName("title")]
    public Title title { get; set; }

    [JsonPropertyName("content")]
    public Content content { get; set; }

    [JsonPropertyName("excerpt")]
    public Excerpt excerpt { get; set; }

    [JsonPropertyName("author")]
    public int author { get; set; }

    [JsonPropertyName("featured_media")]
    public int featured_media { get; set; }

    [JsonPropertyName("comment_status")]
    public string comment_status { get; set; }

    [JsonPropertyName("ping_status")]
    public string ping_status { get; set; }

    [JsonPropertyName("sticky")]
    public bool sticky { get; set; }

    [JsonPropertyName("template")]
    public string template { get; set; }

    [JsonPropertyName("format")]
    public string format { get; set; }

    [JsonPropertyName("meta")]
    public Meta meta { get; set; }

    [JsonPropertyName("categories")]
    public List<int> categories { get; set; }

    [JsonPropertyName("tags")]
    public List<object> tags { get; set; }

    [JsonPropertyName("_links")]
    public Links _links { get; set; }
}

public class Self
{
    [JsonPropertyName("href")]
    public string href { get; set; }
}

public class Title
{
    [JsonPropertyName("rendered")]
    public string rendered { get; set; }
}

public class VersionHistory
{
    [JsonPropertyName("count")]
    public int count { get; set; }

    [JsonPropertyName("href")]
    public string href { get; set; }
}

public class WpAttachment
{
    [JsonPropertyName("href")]
    public string href { get; set; }
}

public class WpTerm
{
    [JsonPropertyName("taxonomy")]
    public string taxonomy { get; set; }

    [JsonPropertyName("embeddable")]
    public bool embeddable { get; set; }

    [JsonPropertyName("href")]
    public string href { get; set; }
}

