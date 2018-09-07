using System.Collections.Generic;

namespace Benefits.Shared.Models.Templates
{
    public class InfoBoxWidget
    {
        public string Headline { get; set; }
        public string Body { get; set; }
        public List<LinkWidget> Downloads { get; set; }        
    }
}