using Mint.Domain.DTO_s.Identity;
using Mint.Infrastructure.Messaging;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.WebApp.Admin.Identity.Commands.Validations;

namespace Mint.WebApp.Admin.Identity.Commands.Authentications;

public sealed record SignInCommand(SignInRequest Auth)
    : ICommand<AuthenticationAdminResponse>;

internal sealed class SignInCommandHandler(IAuthenticationRepository authentication)
        : ICommandHandler<SignInCommand, AuthenticationAdminResponse>
{
    private readonly IAuthenticationRepository _authentication = authentication;

    public async Task<AuthenticationAdminResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var validator = new SignInCommandValidation().Validate(request.Auth);

        if (!validator.IsValid)
            throw new Exception("error sign in command");

        return await _authentication.SignAsAdmin(request.Auth, cancellationToken);
    }
}