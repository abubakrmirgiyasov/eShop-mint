using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record DeleteCategoryCommand(Guid CategoryId) : ICommand;

internal sealed class DeleteCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IStorageCloudService storageCloudService,
    ILogger<DeleteCategoryCommandHandler> logger
) : ICommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly ILogger<DeleteCategoryCommandHandler> _logger = logger;

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryWithPhotoAsync(request.CategoryId, cancellationToken: cancellationToken);

        if (category is null)
            return;

        try
        {
            _categoryRepository.Remove(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (category.Photo is not null)
                await _storageCloudService.DeleteFileAsync(category.Photo.FileName, category.Photo.Bucket, cancellationToken);

            _logger.LogWarning("Удалено успешно! Id={Id}", category.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);
        }
    }
}
