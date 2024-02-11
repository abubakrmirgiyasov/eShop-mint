using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Services;

namespace Mint.WebApp.Admin.Operations.Commands.Categories;

public sealed record CreateCategoryCommand(CategoryFullBindingModel Category) : ICommand<Guid>;

internal sealed class CreateCategoryCommandHandler(CategoryService categoryService) : ICommandHandler<CreateCategoryCommand, Guid>
{
    private readonly CategoryService _categoryService = categoryService;

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var res = await _categoryService.Create(request.Category, cancellationToken);
        return res;
    }
}
