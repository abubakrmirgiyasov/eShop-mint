using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record UpdateCategoryCommand(
    Guid Id,
    CategoryInfoBindingModel Category
) : ICommand;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IStorageCloudService storageCloudService,
    IUnitOfWork unitOfWork,
    ILogger<UpdateCategoryCommandHandler> logger
) : ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<UpdateCategoryCommandHandler> _logger = logger;

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetSampleCategoryById(request.Id, cancellationToken: cancellationToken)
            ?? throw new NotFoundException("Категория не найдена.");

        category.Name = request.Category.Name;
        category.DisplayOrder = request.Category.DisplayOrder;
        category.IsPublished = request.Category.IsPublished;
        category.ShowOnHomePage = request.Category.ShowOnHomePage;
        category.BadgeText = request.Category.BadgeText;
        category.BadgeStyle = request.Category.BadgeStyle;
        category.Ico = request.Category.Ico;
        category.DefaultLink = request.Category.DefaultLink;
        category.Description = request.Category.Description;
        category.UpdateDateTime = DateTimeOffset.Now;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Успешно обновлено! Id={Id}", category.Id);
    }
}
