namespace wikimediatests.Models.API.ResponseModels.Search.Pages
{
    public class Page
    {
        public int id { get; set; }
        public string key { get; set; }
        public string title { get; set; }
        public string excerpt { get; set; }
        public object matched_title { get; set; }
        public string description { get; set; }
        public Thumbnail thumbnail { get; set; }
    }
}