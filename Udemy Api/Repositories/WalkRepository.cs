using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using Udemy_Api.DataAccess;
using Udemy_Api.Model.Domain;

namespace Udemy_Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly ApiContext context;
        public WalkRepository(ApiContext context)
        {
            this.context = context;
        }
        async Task<IEnumerable<Model.Domain.Walk>> IWalkRepository.GetWalkAsync()
        {
            return await context.Walks.ToListAsync();
        }


        async Task<Walk> IWalkRepository.GetWalkByIdAsync(Guid id)
        {
            return await context.Walks.FindAsync(id);
        }

       async Task<Model.Domain.Walk> IWalkRepository.AddWalkAsync(Model.DTO.AddWalkRequest request)
        {
            var newWalk = new Walk()
            {
                Id = new Guid(),
                RegionId= request.RegionId,
                WalkDifficultyId= request.WalkDifficultyId,
                Name = request.Name,
                Length= request.Length,
            };

            await context.Walks.AddAsync(newWalk);
            await context.SaveChangesAsync();

            return newWalk;
        }

        async Task<Model.Domain.Walk> IWalkRepository.UpdateWalkAsync(Guid id , Model.DTO.AddWalkRequest request)
        {
            var walkFound = await context.Walks.FindAsync(id);
            
            walkFound.Name = request.Name;
            walkFound.Length = request.Length;
            walkFound.WalkDifficultyId = request.WalkDifficultyId;
            walkFound.RegionId= request.RegionId;

            await context.SaveChangesAsync();

            return walkFound;
        }

        async Task<Model.Domain.Walk> IWalkRepository.DeleteWalk(System.Guid id)
        {
            var walkToRemove = await context.Walks.FindAsync(id);

            if (walkToRemove == null)
                return null;

            context.Walks.Remove(walkToRemove);
            await context.SaveChangesAsync();

            return walkToRemove;
        }
    }
}
