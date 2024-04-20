using Newtonsoft.Json;

namespace wikimediatests.Models.API.ResponseModels.Pages
{
    public class SinglePageDetails
    {
        public int id { get; set; }
        public string key { get; set; }
        public string title { get; set; }
        public Latest latest { get; set; }
        public string content_model { get; set; }
        public License license { get; set; }
        public string html_url { get; set; }
    }
}