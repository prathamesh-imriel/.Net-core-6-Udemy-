using Microsoft.EntityFrameworkCore;
using Udemy_Api.DataAccess;
using Udemy_Api.Model.Domain;

namespace Udemy_Api.Repositories
{
    public class RegionRepository : IRegionRepository
    {

        private readonly ApiContext context;

        public RegionRepository(ApiContext context)
        {
            this.context = context; 
        }
       async Task<IEnumerable<Region>> IRegionRepository.GetRegionsAsync()
        {
            return await context.Regions.ToListAsync();
        }
    }
}
