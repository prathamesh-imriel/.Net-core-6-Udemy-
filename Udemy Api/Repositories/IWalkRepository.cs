namespace Udemy_Api.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Model.Domain.Walk>> GetWalkAsync();

        Task<Model.Domain.Walk> GetWalkByIdAsync(Guid id);

        Task<Model.Domain.Walk> AddWalkAsync(Model.DTO.AddWalkRequest request);

        Task<Model.Domain.Walk> UpdateWalkAsync(Guid id , Model.DTO.AddWalkRequest request);

        Task<Model.Domain.Walk> DeleteWalk(Guid id);
    }
}
