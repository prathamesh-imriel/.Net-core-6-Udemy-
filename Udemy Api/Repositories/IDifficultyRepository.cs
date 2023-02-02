namespace Udemy_Api.Repositories
{
    public interface IDifficultyRepository
    {

        Task<IEnumerable<Model.Domain.WalkDifficulty>> GetAllDifficulties();

        Task<Model.Domain.WalkDifficulty> GetDificultyLevelById(Guid id);

        Task<Model.Domain.WalkDifficulty> AddNewDifficultyAsync(Model.DTO.AddDifficultyRequest difficulty);
        Task<Model.Domain.WalkDifficulty> UpdateDifficultyAsync(Guid id,Model.DTO.AddDifficultyRequest difficulty);
        Task<Model.Domain.WalkDifficulty> DeleteDifficultyLevel(Guid id);
    }
}
