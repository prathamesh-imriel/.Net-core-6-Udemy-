using Udemy_Api.Model.Domain;

namespace Udemy_Api.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetRegionsAsync();

        Task<Region> GetRegionByIdAsync(Guid id);

        Task<Model.Domain.Region> AddNewRegionAsync(Model.DTO.AddRegionRequest region);

        Task<Model.Domain.Region> DeleteRegionAsync(Guid id);

        Task<Model.Domain.Region> UpdateRegionAsync(Guid id, Model.DTO.AddRegionRequest request);
    }
}
