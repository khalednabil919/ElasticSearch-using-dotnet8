using System.Runtime.CompilerServices;

namespace ElasticSearch_using_dotnet8.Configuration
{
    public class ElasticSettings
    {
        public string Url { get; set; }
        public string DefaultIndex {get;set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
