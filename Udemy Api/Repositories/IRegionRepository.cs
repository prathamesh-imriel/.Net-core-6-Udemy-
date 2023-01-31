using Udemy_Api.Model.Domain;

namespace Udemy_Api.Repositories
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<Region>> GetRegionsAsync();
    }
}
