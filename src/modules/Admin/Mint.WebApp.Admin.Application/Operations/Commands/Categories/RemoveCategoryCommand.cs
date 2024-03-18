using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record RemoveCategoryCommand(Guid Id) : ICommand;

internal sealed class RemoveCategoryCommandHandler(
    ICategoryRepository categoryRepository
) : ICommandHandler<RemoveCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.DeleteCategoryAsync(request.Id, cancellationToken);
    }
}