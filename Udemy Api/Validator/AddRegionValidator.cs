using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Udemy_Api.Validator
{
    public class AddRegionValidator : AbstractValidator<Model.DTO.AddRegionRequest>
    {
        public AddRegionValidator()
        {
            RuleFor(a => a.Code).NotEmpty();
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Area).GreaterThan(0);
            RuleFor(a => a.Lat).GreaterThan(0);
            RuleFor(a => a.Long).GreaterThan(0);
            RuleFor(a=>a.Population).GreaterThanOrEqualTo(0);
            
        }
    }
}
