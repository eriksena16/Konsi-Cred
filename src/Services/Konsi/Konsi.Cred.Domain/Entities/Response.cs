using System.Text.Json.Serialization;

namespace KonsiCred.Domain.Entities
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Observations { get; set; }
    }
}
