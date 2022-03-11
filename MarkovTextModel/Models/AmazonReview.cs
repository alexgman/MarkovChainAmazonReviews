using System.Text.Json.Serialization;

namespace MarkovTextModel.Models
{
    public class AmazonReview
    {
        [JsonPropertyName("reviewerID")]
        public string ReviewerID { get; set; }

        [JsonPropertyName("asin")]
        public string Asin { get; set; }

        [JsonPropertyName("reviewerName")]
        public string ReviewerName { get; set; }

        [JsonPropertyName("helpful")]
        public List<int> Helpful { get; set; }

        [JsonPropertyName("reviewText")]
        public string ReviewText { get; set; }

        [JsonPropertyName("overall")]
        public double Overall { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("unixReviewTime")]
        public int UnixReviewTime { get; set; }

        [JsonPropertyName("reviewTime")]
        public string ReviewTime { get; set; }
    }
}
