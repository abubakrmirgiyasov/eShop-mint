using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.Repositories.Admin.Interfaces;

namespace Mint.WebApp.Admin.Operations.Commands.Categories;

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