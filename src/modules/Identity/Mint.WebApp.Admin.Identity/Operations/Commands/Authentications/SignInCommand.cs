using MediatR;
using Mint.Domain.DTO_s.Identity;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.WebApp.Admin.Identity.Operations.Validations.Authentications;

namespace Mint.WebApp.Admin.Identity.Operations.Commands.Authentications;

public sealed record SignInCommand(SignInRequest Auth)
    : IRequest<AuthenticationAdminResponse>;

internal sealed class SignInCommandHandler(IAuthenticationRepository authentication)
        : IRequestHandler<SignInCommand, AuthenticationAdminResponse>
{
    private readonly IAuthenticationRepository _authentication = authentication;

    public async Task<AuthenticationAdminResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var validator = new SignInCommandValidation().Validate(request.Auth);

        if (!validator.IsValid)
            throw new Exception("error sign in validator");

        return await _authentication.SignAsAdmin(request.Auth, cancellationToken);
    }
}