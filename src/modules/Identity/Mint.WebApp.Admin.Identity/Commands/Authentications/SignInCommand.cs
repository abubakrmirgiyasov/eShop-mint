using FluentValidation;
using Mint.Domain.DTO_s.Identity;
using Mint.Infrastructure.Messaging;
using Mint.Infrastructure.Repositories.Identity.Interfaces;

namespace Mint.WebApp.Admin.Identity.Commands.Authentications;

public sealed record SignInCommand(SignInRequest Auth)
    : ICommand<AuthenticationAdminResponse>;

public sealed class SignInCommandValidation
    : AbstractValidator<SignInCommand>
{
    public SignInCommandValidation()
    {
        RuleFor(x => x.Auth)
            .NotNull()
            .ChildRules(x =>
            {
                x.RuleFor(y => y.Email).NotNull().NotEmpty().WithMessage(_ => "Email field is required!");
                x.RuleFor(y => y.Password).NotNull().NotEmpty().WithMessage(_ => "Password field is required!");
            });
    }
}

internal sealed class SignInCommandHandler(IAuthenticationRepository authentication)
        : ICommandHandler<SignInCommand, AuthenticationAdminResponse>
{
    private readonly IAuthenticationRepository _authentication = authentication;

    public async Task<AuthenticationAdminResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        return await _authentication.SignAsAdmin(request.Auth, cancellationToken);
    }
}