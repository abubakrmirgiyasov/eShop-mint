using Mint.Application.Dtos;
using Mint.Application.Interfaces;
using Mint.Application.Repositories;
using Mint.Domain.Common.BucketKeys;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Products;

public sealed record GetProductImagesQuery(Guid Id) : IQuery<List<ImageLink>>;

internal sealed class GetProductImagesQueryHandler(
    IStorageCloudService storageCloudService,
    IPhotoRepository photoRepository
) : IQueryHandler<GetProductImagesQuery, List<ImageLink>>
{
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IPhotoRepository _photoRepository = photoRepository;

    public async Task<List<ImageLink>> Handle(GetProductImagesQuery request, CancellationToken cancellationToken)
    {
        var photos = await _photoRepository.GetPhotosById(x => x.ProductPhotos!.Any(y => y.ProductId == request.Id), cancellationToken);

        var photosNames = photos.Select(x => x.FileName).ToArray();

        var links = await _storageCloudService.GetFilesLinkAsync(photosNames, ProductConstants.BUCKET, cancellationToken);

        return links.Select(link => new ImageLink(link)).ToList();
    }
}
