using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.SubCategories;

public sealed record DeleteSubCategoryCommand(Guid SubCategoryId) : ICommand;

internal sealed class DeleteSubCategoryCommandHandler(
    ISubCategoryRepository subCategoryRepository,
    ILogger<DeleteSubCategoryCommandHandler> logger
) : ICommandHandler<DeleteSubCategoryCommand>
{
    private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
    private readonly ILogger<DeleteSubCategoryCommandHandler> _logger = logger;

    public async Task Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var subCategory = await _subCategoryRepository
            .FirstOrDefaultAsync(x => x.Id ==  request.SubCategoryId, cancellationToken);

        if (subCategory is null)
            return;

        // TODO: Remove all references before save

        _logger.LogInformation("Sub Category with Id={Id}, was deleted", subCategory.Id);
    }
}
