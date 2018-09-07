using Benefits.Shared.Enums;
using Benefits.Shared.Interfaces;
using Benefits.Shared.Models.Repository;
using Benefits.Shared.Structs;
using Benefits.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Web.ViewComponents
{
    public class HeaderFooterViewComponent : ViewComponent
    {
        private const string benefitsHeaderLink = nameof(benefitsHeaderLink);
        private const string viewNameHeader = "header";
        private const string cmsPageNameProperty = "PageName";
        private readonly ICISOregonRepository _cisOregonRepository;
        private readonly IUIHelpers _uiHelpers;
        private readonly IDynamicNavigationBuilder _dynamicNavigationBuilder;

        public HeaderFooterViewComponent(ICISOregonRepository cisOregonRepository,
             IUIHelpers uiHelpers,
             IDynamicNavigationBuilder dynamicNavigationBuilder)
        {
            _cisOregonRepository = cisOregonRepository;
            _uiHelpers = uiHelpers;
            _dynamicNavigationBuilder = dynamicNavigationBuilder;
        }

        public async Task<IViewComponentResult> InvokeAsync(string viewName)
        {
            var cms = await _cisOregonRepository.GetCMS(CMSSite.Benefits);
            cms = cms.Where(c => c.IncludeInNav == BooleanString.Yes
                && c.IsLive == BooleanString.Yes).ToList();

            var menu = BuildMenu(cms);
            var headerLink = viewName == viewNameHeader
                ? await _dynamicNavigationBuilder.GetDynamicLinkAsync(benefitsHeaderLink, _cisOregonRepository)
                : null;

            return View(viewName, new HeaderFooterViewModel()
            {
                MenuSections = menu,
                HeaderLink = headerLink
            });
        }

        private IList<MenuSection> BuildMenu(IList<CMS> cms)
        {
            var sections = new List<MenuSection>();
            var itemsForSpecialSortRules = new List<MenuItem>();
            string sectionSlugPrefix = "";
            int sectionIndex = -1;

            foreach (CMS page in cms)
            {
                string pageName = JToken.Parse(page.PageJson)[cmsPageNameProperty].ToString();
                string pageSlugPrefix = _dynamicNavigationBuilder.GetSlugPrefix(page.Slug);

                bool beginsNewSection = (sectionSlugPrefix == "" || sectionSlugPrefix != pageSlugPrefix);

                if (beginsNewSection)
                {
                    sections = AddNewSection(sections, pageName, page.Slug);
                    sectionSlugPrefix = pageSlugPrefix;
                    sectionIndex++;
                }
                else
                {
                    sections[sectionIndex].SectionMenuItems.Add(new MenuItem(pageName, $"/{page.Slug}"));
                }
            }

            sections = ApplySpecialSortConditions(sections);

            return sections;
        }

        private List<MenuSection> AddNewSection(List<MenuSection> sections, string pageName, string slug)
        {
            var items = new List<MenuItem>()
            {
                new MenuItem(pageName, $"/{slug}")
            };

            sections.Add(new MenuSection(pageName, items));

            return sections;
        }

        private List<MenuSection> ApplySpecialSortConditions(List<MenuSection> sections)
        {
            sections = MovePublicationsToBottomOfSection(sections, "Wellness Resources");

            return sections;
        }

        private List<MenuSection> MovePublicationsToBottomOfSection(List<MenuSection> sections, string sectionName)
        {
            var items = sections.Where(s => s.SectionName.Equals(sectionName)).FirstOrDefault().SectionMenuItems;
            var publicationItems = items.Where(i => i.LinkUrl.Contains("publications")).ToList();

            // Remove from current order then add to bottom of the collection
            items.RemoveAll(i => i.LinkUrl.Contains("publications"));
            items.AddRange(publicationItems);

            // Remove and then add section itself to get new sort order items
            sections.RemoveAll(s => s.SectionName.Equals("Wellness Resources"));
            sections.Add(new MenuSection("Wellness Resources", items));

            return sections;
        }
    }
}