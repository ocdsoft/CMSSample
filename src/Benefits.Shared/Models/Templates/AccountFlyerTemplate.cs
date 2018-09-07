using Newtonsoft.Json;
using System.Collections.Generic;

namespace Benefits.Shared.Models.Templates
{
    public class AccountFlyerTemplate : BaseTemplate
    {
        public TextBoxWidget PublicAnnouncement { get; set; }
        public BillboardWidget Billboard { get; set; }
        public List<TextBoxWidget> SectionHighlights { get; set; }
        public CallToActionWidget CallToAction { get; set; }
        public LinkWidget LinkButton { get; set; }
        public LinkWidget QuickLinksHeading { get; set; }
        public List<LinkWidget> QuickLinks { get; set; }
        public InfoBoxWidget SmallInfoBox { get; set; }

        [JsonIgnore]
        public override bool InitFileUploader { get { return true; } }
    }
}