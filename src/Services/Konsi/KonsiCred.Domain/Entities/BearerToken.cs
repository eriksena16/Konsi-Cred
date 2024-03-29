﻿using System.Text.Json.Serialization;

namespace KonsiCred.Application
{
    public class BearerToken
    {
        public bool Success { get; set; }
        public Data Data { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Observations { get; set; }
    }

    public class Data
    {
        public string Token { get; set; }
        public string Type { get; set; }
    }

}
