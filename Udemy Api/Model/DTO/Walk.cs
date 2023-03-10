using Udemy_Api.Model.Domain;

namespace Udemy_Api.Model.DTO
{
    public class Walk
    {
        public Guid Id { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public Guid RegionId { get; set; }

        public string? Name { get; set; }

        public double Length { get; set; }

        //Navigation
        public Region? Region { get; set; }
        public WalkDifficulty? walkDifficulty { get; set; }
    }
}
