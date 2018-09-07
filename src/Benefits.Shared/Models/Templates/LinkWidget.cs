namespace Benefits.Shared.Models.Templates
{
    public class LinkWidget
    {
        public string LinkName { get; set; }
        public string LinkSrc { get; set; }

        // Optional:
        public string LinkFileName { get; set; }
        public bool IsSubLevel { get; set; }
    }
}