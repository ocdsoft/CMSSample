using Benefits.Shared.Interfaces;
using Benefits.Shared.Models.Repository;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;

namespace Benefits.Web.ViewModels
{
    public class PublicationsViewModel
    {
        public IUIHelpers UIHelpers { get; set; }
        public List<Publication> Publications { get; set; }

        public void Init(
            IDocumentManagementRepository documentRepository,
            IUIHelpers uiHelpers,
            string configString = "")
        {
            UIHelpers = uiHelpers;

            var publication = QueryHelpers.ParseQuery(configString)["Publication"].ToString();
            Publications = documentRepository.GetPublications(publication);
        }
    }
}