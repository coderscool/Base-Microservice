using Contracts.Services.Account;
using FluentValidation;

namespace WebApi.Controllers.Account.Validator
{
    public class CreateAccountValidator : AbstractValidator<Command.CreateAccount>
    {
        public CreateAccountValidator()
        {
            RuleFor(p => p.UserName).NotEmpty();
        }

    }
}
