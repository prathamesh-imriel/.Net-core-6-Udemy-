using FluentValidation;

namespace Udemy_Api.Validator
{
    public class AddWalkValidator : AbstractValidator<Model.DTO.AddWalkRequest>
    {

        public AddWalkValidator()
        {
            RuleFor(a=>a.Name).NotEmpty();
            RuleFor(b => b.Length).GreaterThan(0);
          
        }
    }
}
