using Newtonsoft.Json;

namespace Benefits.Shared.Models.Templates
{
    public class BenefitsMarketingTemplate : BaseTemplate
    {
        public string SecondaryHeadline { get; set; }
        public BillboardWidget Billboard { get; set; }
        public CallToActionWidget CallToAction { get; set; }
        public string QuickLinksHeading { get; set; }
        public string MainPageHtml { get; set; }
        public InfoBoxWidget SmallInfoBox { get; set; }
        public string FBFeedIsVisible { get; set; }
        public CustomActionWidget CustomAction { get; set; }

        [JsonIgnore]
        public override bool InitFileUploader { get { return true; } }
    }
}