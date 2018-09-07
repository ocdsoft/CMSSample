using Benefits.Shared.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Benefits.Shared.Models.Templates
{
    public abstract class BaseTemplate
    {
        public IUIHelpers UIHelpers { get; set; }

        [Required]
        public string PageName { get; set; }
        
        [JsonIgnore]
        virtual public bool InitFileUploader { get; } = false;
    }
}
