using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetCategoryPhotoQuery(Guid Id) : IQuery<CategoryPhotoResponse?>;

public sealed record CategoryPhotoResponse(string? Photo);

internal sealed class GetCategoryPhotoQueryHandler (
    ICategoryRepository categoryRepository,
    IStorageCloudService storageCloudService
): IQueryHandler<GetCategoryPhotoQuery, CategoryPhotoResponse?>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;

    public async Task<CategoryPhotoResponse?> Handle(GetCategoryPhotoQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryWithPhotoAsync(request.Id, asNoTracking: true, cancellationToken: cancellationToken)
            ?? throw new NotFoundException("Категория не найдена.");

        if (category.Photo is null)
            return null;

        var photo = await _storageCloudService.GetFileLinkAsync(
            name: category.Photo.FileName,
            bucket: category.Photo.Bucket,
            cancellationToken: cancellationToken
        );

        return new CategoryPhotoResponse(photo);
    }
}