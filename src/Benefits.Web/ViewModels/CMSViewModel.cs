using Benefits.Shared.Enums;
using Benefits.Shared.Interfaces;
using Benefits.Shared.Models.Repository;
using Benefits.Shared.Models.Templates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Benefits.Web.ViewModels
{
    public class CMSViewModel
    {
        [JsonIgnore]
        protected const string JsRootDirectory = "~/Scripts";

        [JsonIgnore]
        protected const string JsViewModelDirectory = JsRootDirectory + "/ViewModels";

        public CMSTemplateType TemplateType
        {
            get
            {
                return (CMSTemplateType)CMS.CMSTemplateTypeLookupID;
            }
        }

        public CMS CMS { get; set; }

        public RedirectTemplate RedirectTemplate { get; set; }

        public AccountFlyerTemplate AccountFlyerTemplate { get; set; }

        public BenefitsMarketingTemplate BenefitsMarketingTemplate { get; set; }

        public IUIHelpers UIHelpers { get; set; }

        public void Init(IUIHelpers uiHelpers)
        {
            UIHelpers = uiHelpers;
            SetTemplateModelForController();
            SetJsonData(this);
        }

        // Enable controllers to initialize view model if necessary
        public object SetTemplateModelForController()
        {
            SetTemplateModel(UIHelpers);
            return GetType().GetProperty(TemplateType.ToString()).GetValue(this, null);
        }

        // Set the template data (corresponds to unique template saved to the CMS.PageJson 
        // property as a serialized JSON object).
        private void SetTemplateModel(IUIHelpers uiHelpers)
        {
            // Use reflection to find out which template model is used by this CMS page's view model.
            PropertyInfo templateModel = GetType().GetProperty(TemplateType.ToString());
            
            // Deserialize the PageJson property using the template model and assign its value.
            dynamic templateModelData = JsonConvert.DeserializeObject(
                CMS.PageJson,
                templateModel.PropertyType);

            templateModelData.UIHelpers = uiHelpers;

            // Set the relevant CMS Template Model with its corresponding data object
            templateModel.SetValue(this, templateModelData);
        }

        [JsonIgnore]
        public string TemplatePartialViewName
        {
            get
            {
                return string.Format("_{0}", TemplateType);
            }
        }

        [JsonIgnore]
        public string JsonData { get; private set; }

        [JsonIgnore]
        public string[] ScriptsToRender
        {
            get
            {
                var scriptNames = new List<string>
                {
                    $"~/scripts/{TemplateType.ToString()}.js"
                };

                switch (TemplateType)
                {
                    case CMSTemplateType.AccountFlyerTemplate:
                        break;
                    default:
                        break;
                }

                var scriptsVersioned = new List<string>();

                foreach (var s in scriptNames)
                    scriptsVersioned.Add(s);

                return scriptsVersioned.ToArray();
            }
        }

        /// <summary>
        /// Converts the provided object into JSON data format sets to a property of the BaseViewModel
        /// (or calls the provided assignment action anonymous method if provided).
        /// </summary>
        /// <param name="data">The data to convert to JSON.</param>
        /// <param name="assignmentAction">The anonymous method to call for assigning the JSON data to a property.
        /// If not provided, the JSON data will be assigned to a property.</param>
        /// <param name="autoTypeNameHandling">Indicates whether or not the JSON serializer should automatically add type information to the JSON when necessary.</param>
        public void SetJsonData(object data, Action<string> assignmentAction = null, bool autoTypeNameHandling = false)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            if (autoTypeNameHandling)
                jsonSerializerSettings.TypeNameHandling = TypeNameHandling.Auto;

            var jsonData = JsonConvert.SerializeObject(data, jsonSerializerSettings);

            if (assignmentAction != null)
            {
                assignmentAction(jsonData);
            }
            else
            {
                JsonData = jsonData;
            }
        }
    }
}
