using Mint.Application.Interfaces;
using Mint.Application.Repositories;
using Mint.Domain.Common.BucketKeys;
using Mint.Domain.Exceptions;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Products;

public sealed record UpdateProductImagesCommand(Guid ProductId, FileRequest Images) : ICommand;

internal sealed class UpdateProductImagesCommandHandler(
    IStorageCloudService storageCloudService,
    IProductRepository productRepository,
    IProductPhotoRepository productPhotoRepository,
    IUnitOfWork unitOfWork
) : ICommandHandler<UpdateProductImagesCommand>
{
    private const long MaxFileLength = 10 * 1024 * 1024;

    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IProductPhotoRepository _productPhotoRepository = productPhotoRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(UpdateProductImagesCommand request, CancellationToken cancellationToken)
    {
        if (request.Images.Files.Count > 10)
            throw new LogicException("Максимальный лимит - 10 файлов для загрузки.");

        var filesLength = request.Images.Files
            .Select(x => x.Length)
            .Sum();

        if (filesLength > MaxFileLength)
            throw new LogicException("Превышена максимальная длина файла.");

        var product = await _productRepository.GetProductWithPhotosAsync(request.ProductId, cancellationToken: cancellationToken);

        if (product.ProductPhotos?.Count > 0)
        {

        }
        else
        {
            var files = await _storageCloudService.UploadFilesAsync(
                fileCollection: request.Images.Files, 
                id: request.ProductId, 
                bucket: ProductConstants.BUCKET, 
                cancellationToken: cancellationToken
            );

            product.ProductPhotos = [];

            foreach (var file in files)
            {
                await _productPhotoRepository.AddAsync(
                    new ProductPhoto
                    {
                        ProductId = product.Id,
                        Photo = new Photo
                        {
                            Id = Guid.NewGuid(),
                            FileName = file.FileName,
                            FilePath = file.FilePath,
                            Bucket = file.Bucket,
                            FileSize = file.FileSize,
                            FileExtension = file.FileExtension,
                        }
                    },
                    cancellationToken
                );
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
