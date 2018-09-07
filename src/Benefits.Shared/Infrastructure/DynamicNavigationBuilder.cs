using Benefits.Shared.Interfaces;
using Benefits.Shared.Models.Templates;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Benefits.Shared.Infrastructure
{
    public class DynamicNavigationBuilder : IDynamicNavigationBuilder
    {
        public string GetSlugPrefix(string slug)
        {
            var splitChar = new string[] { "/" };
            var slugParts = slug.Split(splitChar, StringSplitOptions.None);

            return slugParts[0].ToLower();
        }

        public async Task<LinkWidget> GetDynamicLinkAsync(string name, ICISOregonRepository repo)
        {
            var dynamicLinkJson = await repo.GetJsonDataSource(name);
            return JsonConvert.DeserializeObject<LinkWidget>(dynamicLinkJson.Data);
        }
    }
}