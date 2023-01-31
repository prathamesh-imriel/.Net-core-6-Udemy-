
using Microsoft.EntityFrameworkCore;
using Udemy_Api.Model.Domain;

namespace Udemy_Api.DataAccess
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options) 
            :base(options) 
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
