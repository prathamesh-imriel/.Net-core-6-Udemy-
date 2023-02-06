
using Microsoft.EntityFrameworkCore;
using Udemy_Api.Model.Domain;
using Udemy_Api.Model.DTO;
using Region = Udemy_Api.Model.Domain.Region;

namespace Udemy_Api.DataAccess
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options) 
            :base(options) 
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Model.Domain.Walk> Walks { get; set; }
        public DbSet<Model.Domain.WalkDifficulty> WalkDifficulty { get; set; }
    }
}
