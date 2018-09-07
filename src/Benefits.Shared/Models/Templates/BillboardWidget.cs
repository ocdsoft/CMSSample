namespace Benefits.Shared.Models.Templates
{
    public class BillboardWidget
    {
        // All properties are optional, pick & choose as needed.
        public string Headline { get; set; }
        public string Tagline { get; set; }
        public string Summary { get; set; }
        public string MediaEmbedCode { get; set; }        
        public string Image { get; set; }
        public string ImageFileName { get; set; }
        public string ImageHref { get; set; }
        public bool IsActuallyAVideoLink { get; set; }
        public bool IsLive { get; set; }
    }
}