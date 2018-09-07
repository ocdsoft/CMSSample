using Benefits.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace Benefits.Web.ViewComponents
{
    public class CustomActionViewComponent : ViewComponent
    {
        private readonly IDocumentManagementRepository _documentRepository;
        private readonly IUIHelpers _uiHelpers;

        public CustomActionViewComponent(
            IDocumentManagementRepository documentRepository,
            IUIHelpers uiHelpers)
        {
            _documentRepository = documentRepository;
            _uiHelpers = uiHelpers;
        }

        public IViewComponentResult Invoke(string view, string viewModel, string configString)
        {
            dynamic viewModelInstance = Activator.CreateInstance(
                Type.GetType($"Benefits.Web.ViewModels.{viewModel}"));

            var repoName = QueryHelpers.ParseQuery(configString)["Repository"].ToString();

            if (repoName == nameof(IDocumentManagementRepository))
                viewModelInstance.Init(_documentRepository, _uiHelpers, configString);

            return View(view, viewModelInstance);
        }
    }
}