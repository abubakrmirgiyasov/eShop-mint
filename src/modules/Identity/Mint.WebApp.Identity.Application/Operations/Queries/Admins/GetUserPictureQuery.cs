using MediatR;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Exceptions;
using Mint.WebApp.Identity.Application.Operations.Dtos;
using Mint.WebApp.Identity.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Identity.Operations.Queries.Admins;

public sealed record GetUserPictureQuery(Guid Id) : IRequest<UserPictureResponse>;

internal sealed class GetUserPictureQueryHandler(
    IUserRepository userRepository,
    IStorageCloudService storageCloudService
) : IRequestHandler<GetUserPictureQuery, UserPictureResponse>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;

    public async Task<UserPictureResponse> Handle(GetUserPictureQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithPhotoAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("Пользователь не найден.");

        var storage = await _storageCloudService.GetFileLinkAsync(
            user.Photo?.FileName ?? Constants.IMAGE_DEFAULT_NAME,
            user.Photo?.FileType ?? Constants.IMAGE_DEFAULT_PATH,
            cancellationToken: cancellationToken
        );

        return new UserPictureResponse(storage!);
    }
}
