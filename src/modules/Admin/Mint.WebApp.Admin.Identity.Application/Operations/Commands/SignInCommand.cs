using FluentValidation;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Identity.Application.Operations.Dtos;
using Mint.WebApp.Admin.Identity.Application.Operations.Validations;

namespace Mint.WebApp.Admin.Identity.Application.Operations.Commands;

public sealed record SignInCommand(SignInRequest Auth)
    : ICommand<AuthenticationAdminResponse>;

internal sealed class SignInCommandHandler(IAdminRepository adminRepository)
    : ICommandHandler<SignInCommand, AuthenticationAdminResponse>
{
    private readonly IAdminRepository _adminRepository = adminRepository;

    public async Task<AuthenticationAdminResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var validator = new SignInCommandValidation();
        var validatorValidation = validator.Validate(request.Auth);

        if (!validatorValidation.IsValid)
            throw new ValidationException(validatorValidation.Errors);

        return await _adminRepository.SignAsAdmin(request.Auth, cancellationToken);
    }
}
