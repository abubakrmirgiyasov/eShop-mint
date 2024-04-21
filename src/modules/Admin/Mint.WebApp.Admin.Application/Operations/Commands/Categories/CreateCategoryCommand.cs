using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Validations.Categories;
using System.Text.Json;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record CreateCategoryCommand(CategoryInfoBindingModel Category) : ICommand<Guid>;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    ILogger<CreateCategoryCommandHandler> logger
) : ICommandHandler<CreateCategoryCommand, Guid>
{
    private readonly ILogger<CreateCategoryCommandHandler> _logger = logger;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var createCategoryValidator = new CreateCategoryCommandValidation();
        var validatorValidate = createCategoryValidator.Validate(request.Category);

        if (!validatorValidate.IsValid)
            throw new Exception(JsonSerializer.Serialize(validatorValidate.Errors));

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Category.Name,
            DisplayOrder = request.Category.DisplayOrder,
            BadgeText = request.Category.BadgeText,
            BadgeStyle = request.Category.BadgeStyle,
            DefaultLink = request.Category.DefaultLink,
            Description = request.Category.Description,
            Ico = request.Category.Ico,
            IsPublished = request.Category.IsPublished,
            ShowOnHomePage = request.Category.ShowOnHomePage,
        };

        await _categoryRepository.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Создана новая категория с Id={Id}", category.Id);
        return category.Id;
    }
}
