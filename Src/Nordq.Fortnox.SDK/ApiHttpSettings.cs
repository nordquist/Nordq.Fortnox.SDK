namespace Nordq.Fortnox.SDK
{
    public class ApiHttpSettings
    {
        public string ContentType { get; set; }
        public string AcceptType { get; set; }
        public string ApiBaseUrl { get; set; }

        public ApiHttpSettings()
        {
            ContentType = "application/json";
            AcceptType = "application/json";
            ApiBaseUrl = "https://api.fortnox.se/3/";
        }
    }
}