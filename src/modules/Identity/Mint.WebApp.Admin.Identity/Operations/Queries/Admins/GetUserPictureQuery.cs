using MediatR;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Exceptions;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.WebApp.Admin.Identity.Operations.Queries.Admins;

public sealed record GetUserPictureQuery(Guid Id) : IRequest<UserPictureResponse>;

public class UserPictureResponse
{
    public required string Link { get; set; }
}

internal sealed class GetUserPictureQueryHandler(
    IUserRepository userRepository,
    IStorageCloudService storageCloudService
) : IRequestHandler<GetUserPictureQuery, UserPictureResponse>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;

    public async Task<UserPictureResponse> Handle(GetUserPictureQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .Context
            .Users
            .Include(x => x.Photo)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (user is null)
            throw new NotFoundException("Пользователь не найден.");

        if (user.Photo is null)
        {
            var storage = await _storageCloudService.GetFileLinkAsync(
                user.Photo?.FileName ?? Constants.IMAGE_DEFAULT_NAME,
                user.Photo?.FileType ?? Constants.IMAGE_DEFAULT_PATH,
                cancellationToken: cancellationToken
            );

            return new UserPictureResponse
            {
                Link = storage
            };
        }
        else
        {
            return new UserPictureResponse 
            {
                Link = user.Photo.FilePath
            };
        }
    }
}
