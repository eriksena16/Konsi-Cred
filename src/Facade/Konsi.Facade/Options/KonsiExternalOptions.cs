﻿namespace KonsiCred.Facade
{
    public class KonsiExternalOptions
    {
        public static string Instance { get; } = "KONSI";
        public string BaseAddress { get; set; }
        public string RequestUriToken { get; set; }
    }
}
