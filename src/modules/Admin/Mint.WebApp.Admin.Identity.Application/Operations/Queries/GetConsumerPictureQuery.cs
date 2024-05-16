using MediatR;
using Mint.Application.Dtos;
using Mint.Application.Interfaces;
using Mint.Application.Repositories;
using Mint.Domain.Common;
using Mint.Domain.Exceptions;

namespace Mint.WebApp.Admin.Identity.Application.Operations.Queries;

public sealed record GetConsumerPictureQuery(Guid Id) : IRequest<ImageLink>;

internal sealed class GetConsumerPictureQueryHandler(
    IUserRepository userRepository,
    IStorageCloudService storageCloudService
) : IRequestHandler<GetConsumerPictureQuery, ImageLink>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;

    public async Task<ImageLink> Handle(GetConsumerPictureQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithPhotoAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("Пользователь не найден.");

        var storage = await _storageCloudService.GetFileLinkAsync(
            user.Photo?.FileName ?? Constants.IMAGE_DEFAULT_NAME,
            user.Photo?.Bucket ?? Constants.IMAGE_DEFAULT_PATH,
            cancellationToken: cancellationToken
        );

        return new ImageLink(storage!);
    }
}
