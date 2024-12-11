using System.Text.Json.Serialization;

namespace Lab6.Models
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public List<T> Data { get; set; } = new();

        public ApiResponse(string message, int statusCode, List<T> data = null)
        {
            Message = message;
            StatusCode = statusCode;
            Data = data ?? new List<T>();
        }
    }

    public class PostData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}
