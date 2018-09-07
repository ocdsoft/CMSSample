namespace Benefits.Shared.Models.Repository
{
    public class MenuItem
    {
        public MenuItem(string linkText, string linkUrl)
        {
            LinkText = linkText;
            LinkUrl = linkUrl;
        }

        public string LinkText { get; set; }
        public string LinkUrl { get; set; }
    }
}
