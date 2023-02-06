using System.ComponentModel.DataAnnotations;

namespace Udemy_Api.Model.Domain
{
    public class Walk
    {

        public Guid Id { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public Guid RegionId { get; set; }

        [RegularExpression("^[a-zA-Z]{3,0}",ErrorMessage ="Name can not contain numbers or special characters")]
        public string? Name { get; set; }

        
        public double Length { get; set; }

        //Navigation
        public Region? Region { get; set; }
        public WalkDifficulty? walkDifficulty { get; set; }
    }
}
