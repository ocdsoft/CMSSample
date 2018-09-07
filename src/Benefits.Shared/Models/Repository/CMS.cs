using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Benefits.Shared.Models.Repository
{
    public class CMS
    {
        public int CMSID { get; set; }
        [Required]
        public string Slug { get; set; }
        // Y or N.
        public string IncludeInNav { get; set; }
        public string PageJson { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string IsLive { get; set; }
        // Lookups
        public int? CMSSiteLookupID { get; set; }
        public int? CMSTemplateTypeLookupID { get; set; }

        [JsonIgnore]
        public string PageName
        {
            get
            {
                try
                {
                    // Parse Json to find PageName property from BaseTemplate object.
                    return JToken.Parse(PageJson)["PageName"].ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
    }
}