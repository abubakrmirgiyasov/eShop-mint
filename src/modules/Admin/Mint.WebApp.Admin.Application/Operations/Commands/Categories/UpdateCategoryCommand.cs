﻿using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record UpdateCategoryCommand(CategoryFullBindingModel Category) : ICommand;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository
) : ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FindByIdAsync(request.Category.Id, cancellationToken: cancellationToken);

        category.Name = request.Category.Name;
        category.BadgeText = request.Category.BadgeText ?? category.BadgeText;
        category.BadgeStyle = request.Category.BadgeStyle ?? category.BadgeStyle;

        await _categoryRepository.Context.SaveChangesAsync(cancellationToken);
    }
}