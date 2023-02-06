using FluentValidation;

namespace Udemy_Api.Validator
{
    public class LoginRequestValidator : AbstractValidator<Model.DTO.LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(a=>a.UserName).NotEmpty();
            RuleFor(a=>a.Password).NotEmpty();
        }
    }
}
