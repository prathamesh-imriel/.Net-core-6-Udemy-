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

        async Task<Region> IRegionRepository.GetRegionByIdAsync(Guid id)
        {
            return await context.Regions.FirstOrDefaultAsync(a => a.Id == id);

        }


        async Task<Model.Domain.Region> IRegionRepository.AddNewRegionAsync(Model.DTO.AddRegionRequest region)
        {
            var newRegion = new Model.Domain.Region()
            { 
                Id = new Guid(),
                Name = region.Name,
                Code= region.Code,
                Area= region.Area,
                Lat= region.Lat,
                Long= region.Long,
                Population= region.Population,
            };
            
            await context.Regions.AddAsync(newRegion);
            await context.SaveChangesAsync();
            return newRegion;
        }

        async Task<Model.Domain.Region> IRegionRepository.DeleteRegionAsync(Guid id)
        {
            var regionToDelete = await context.Regions.FindAsync(id);

            if (regionToDelete == null)
                return null;

            context.Regions.Remove(regionToDelete);
            await context.SaveChangesAsync();

            return regionToDelete;
        }
        
        async Task<Model.Domain.Region> IRegionRepository.UpdateRegionAsync(Guid id,Model.DTO.AddRegionRequest request)
        {
            var regionFound = await context.Regions.FindAsync(id);

            regionFound.Population = request.Population;
            regionFound.Lat = request.Lat;
            regionFound.Long = request.Long;
            regionFound.Area = request.Area;
            regionFound.Code = request.Code;
            regionFound.Name= request.Name;

            context.Regions.Update(regionFound);
            await context.SaveChangesAsync();

            return regionFound;
            
        }
    }
}
