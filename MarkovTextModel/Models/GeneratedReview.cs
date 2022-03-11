using System.Text.Json.Serialization;

namespace MarkovTextModel.Models
{
    public class GeneratedReview
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }
    }
}
