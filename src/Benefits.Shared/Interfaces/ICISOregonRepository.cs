using Benefits.Shared.Enums;
using Benefits.Shared.Models.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benefits.Shared.Interfaces
{
    public interface ICISOregonRepository
    {
        Task<IList<CMS>> GetCMS(CMSSite cmsSite);
        Task<CMS> GetCMS(CMSSite cmsSite, string url);
        Task<JsonDataSource> GetJsonDataSource(string name);
    }
}