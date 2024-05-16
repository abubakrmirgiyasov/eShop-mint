using Mint.Application.Dtos;
using Mint.Application.Interfaces;
using Mint.Application.Repositories;
using Mint.Domain.Common.BucketKeys;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Products;

public sealed record GetProductsImagesQuery(
    List<Guid> ProductsIds,
    int Count = 5
) : IQuery<Dictionary<Guid, IEnumerable<ImageLink>>>;

internal sealed class GetProductsImagesQueryHandler(
    IProductPhotoRepository productPhotoRepository,
    IStorageCloudService storageCloudService
) : IQueryHandler<GetProductsImagesQuery, Dictionary<Guid, IEnumerable<ImageLink>>>
{
    private readonly IProductPhotoRepository _productPhotoRepository = productPhotoRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;

    public async Task<Dictionary<Guid, IEnumerable<ImageLink>>> Handle(GetProductsImagesQuery request, CancellationToken cancellationToken)
    {
        var productsImages = _productPhotoRepository.GetProductsImages(request.ProductsIds, request.Count);

        var res = new Dictionary<Guid, IEnumerable<ImageLink>>();

        foreach (var (productId, photos) in productsImages)
        {
            var photosNames = photos.Select(x => x.FileName).ToArray();

            var photoLinks = await _storageCloudService.GetFilesLinkAsync(
                photosNames, 
                ProductConstants.BUCKET,
                cancellationToken
            );

            res.Add(productId, photoLinks.Select(x => new ImageLink(x)));
        }

        return res;
    }
}
