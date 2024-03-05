namespace KonsiCred.Facade
{
    public class KonsiCredApiOptions
    {
        public static string Instance { get; } = "KONSI";
        public string BaseAddress { get; set; }
        public string RequestUriKonsi { get; set; }
    }
}
