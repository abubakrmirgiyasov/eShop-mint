using FluentValidation;
using Mint.Application.Interfaces;
using Mint.Domain.DTO_s.Identity;
using Mint.WebApp.Admin.Identity.Operations.Validations.Authentications;
using Mint.WebApp.Identity.Application.Operations.Repositories;

namespace Mint.WebApp.Identity.Application.Operations.Commands.Admins;

public sealed record SignInCommand(SignInRequest Auth)
    : ICommand<AuthenticationAdminResponse>;

internal sealed class SignInCommandHandler(
    IAdminAuthenticationRepository authentication
) : ICommandHandler<SignInCommand, AuthenticationAdminResponse>
{
    private readonly IAdminAuthenticationRepository _authentication = authentication;

    public async Task<AuthenticationAdminResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var validator = new SignInCommandValidation();
        var validatorValidation = validator.Validate(request.Auth);

        if (!validatorValidation.IsValid)
            throw new ValidationException(validatorValidation.Errors);

        var token = await _authentication.SignAsAdmin(request.Auth, cancellationToken);

        return token;
    }
}