using Benefits.Shared.Enums;
using Benefits.Shared.Interfaces;
using Benefits.Shared.Structs;
using Benefits.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Benefits.Web.Controllers
{
    public class CustomRouteController : Controller
    {
        private readonly ICISOregonRepository _cisOregonRepository;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IUIHelpers _uiHelpers;

        public CustomRouteController(
            ICISOregonRepository cisOregonRepository,
            ILogger<CustomRouteController> logger,
            IHostingEnvironment hostingEnvironment,
            IUIHelpers uiHelpers)
        {
            _cisOregonRepository = cisOregonRepository;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _uiHelpers = uiHelpers;
        }
        
        public async Task<IActionResult> RenderPage(string url)
        {
            url = string.IsNullOrEmpty(url) ? "home" : url;

            if (url.Contains(".js"))
                return Ok();

            var cms = await _cisOregonRepository.GetCMS(CMSSite.Benefits, url);

            if (cms == null || cms.IsLive == BooleanString.No)
                return Redirect("/Error/PageNotFound");

            var viewModel = new CMSViewModel() { CMS = cms };
            viewModel.Init(_uiHelpers);
            
            if (cms.CMSTemplateTypeLookupID == (int)CMSTemplateType.RedirectTemplate)
                return Redirect(viewModel.RedirectTemplate.RedirectUrl);
                        
            return View("RenderPage", viewModel);
        }
    }
}