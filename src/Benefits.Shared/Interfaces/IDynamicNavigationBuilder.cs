using Benefits.Shared.Models.Templates;
using System.Threading.Tasks;

namespace Benefits.Shared.Interfaces
{
    public interface IDynamicNavigationBuilder
    {
        string GetSlugPrefix(string slug);
        Task<LinkWidget> GetDynamicLinkAsync(string name, ICISOregonRepository repo);
    }
}