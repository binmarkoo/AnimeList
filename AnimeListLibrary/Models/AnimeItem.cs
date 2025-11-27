using System.Text.Json.Serialization;

namespace AnimeListLibrary.Models
{
    public class AnimeItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("releaseYear")]
        public int ReleaseYear { get; set; }

        [JsonPropertyName("picSrc")]
        public string PicSrc { get; set; }

        public override string ToString() => $"ID: {Id} - {Name}";
    }
}
