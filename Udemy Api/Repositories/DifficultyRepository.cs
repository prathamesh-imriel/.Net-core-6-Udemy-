using Microsoft.EntityFrameworkCore;
using Udemy_Api.DataAccess;
using Udemy_Api.Model.Domain;

namespace Udemy_Api.Repositories
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly ApiContext context;
        public DifficultyRepository(ApiContext context)
        {
            this.context = context;
        }

        async Task<WalkDifficulty> IDifficultyRepository.AddNewDifficultyAsync(Model.DTO.AddDifficultyRequest difficulty)
        {
            var newDifficulty = new WalkDifficulty()
            {
                Id = new Guid(),
                Level = difficulty.Level,
            };
            var res = await context.WalkDifficulty.AddAsync(newDifficulty);
            await context.SaveChangesAsync();

            return newDifficulty;

        }

        async Task<Model.Domain.WalkDifficulty> IDifficultyRepository.DeleteDifficultyLevel(Guid id)
        {
            var difficultyLevel = await context.WalkDifficulty.FindAsync(id);

            if (difficultyLevel == null) 
                return null;

            context.WalkDifficulty.Remove(difficultyLevel);
            await context.SaveChangesAsync();

            return difficultyLevel;
        }

        async Task<IEnumerable<Model.Domain.WalkDifficulty>> IDifficultyRepository.GetAllDifficulties()
        {
            return await context.WalkDifficulty.ToListAsync();
        }

        async Task<WalkDifficulty> IDifficultyRepository.GetDificultyLevelById(Guid id)
        {
            return await context.WalkDifficulty.FirstOrDefaultAsync(a => a.Id == id);
        }

        async Task<WalkDifficulty> IDifficultyRepository.UpdateDifficultyAsync(Guid id, Model.DTO.AddDifficultyRequest difficulty)
        {
            var result = await context.WalkDifficulty.FindAsync(id);

            result.Level  = difficulty.Level;

            await context.SaveChangesAsync();

            return result;
        }
    }
}
