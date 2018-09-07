using Benefits.Shared.Models.Repository;
using Benefits.Shared.Models.Templates;
using System.Collections.Generic;

namespace Benefits.Web.ViewModels
{
    public class HeaderFooterViewModel
    {
        public IList<MenuSection> MenuSections { get; set; }
        public LinkWidget HeaderLink { get; set; }
    }
}