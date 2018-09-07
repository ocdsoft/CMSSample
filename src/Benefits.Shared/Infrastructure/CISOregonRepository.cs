using Benefits.Shared.Enums;
using Benefits.Shared.ExtensionMethods;
using Benefits.Shared.Interfaces;
using Benefits.Shared.Models.Repository;
using Benefits.Shared.Structs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Shared.Infrastructure
{
    public class CISOregonRepository : ICISOregonRepository
    {
        private readonly CISOregonContext _context;

        public CISOregonRepository(CISOregonContext context) {
            _context = context;
        }

        public async Task<IList<CMS>> GetCMS(CMSSite cmsSite)
        {
            return await _context.CMS
                .Where(c => c.CMSSiteLookupID == (int)cmsSite)
                .OrderBy(c => c.Slug)
                .AsNoTracking().FromCacheToListAsync();
        }

        public async Task<CMS> GetCMS(CMSSite cmsSite, string url)
        {
            return await _context.CMS
                .Where(c => c.CMSSiteLookupID == (int)cmsSite
                    && c.Slug == url)
                .AsNoTracking()
                .FromCacheFirstOrDefaultAsync();
        }

        public async Task<JsonDataSource> GetJsonDataSource(string name)
        {
            return await _context.JsonDataSource
                .Where(jds => jds.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}