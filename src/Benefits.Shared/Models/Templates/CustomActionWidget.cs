namespace Benefits.Shared.Models.Templates
{
    public class CustomActionWidget
    {
        public string View { get; set; }
        public string ViewModel { get; set; }
        // Use like a query string to pass multiple values
        public string ConfigString { get; set; }
    }
}