using System.Collections.Generic;

namespace Benefits.Shared.Models.Repository
{
    public class MenuSection
    {
        public MenuSection(string sectionName, List<MenuItem> sectionMenuItems)
        {
            SectionName = sectionName;
            SectionMenuItems = sectionMenuItems;
        }

        public string SectionName { get; set; }
        public List<MenuItem> SectionMenuItems { get; set; }
    }
}