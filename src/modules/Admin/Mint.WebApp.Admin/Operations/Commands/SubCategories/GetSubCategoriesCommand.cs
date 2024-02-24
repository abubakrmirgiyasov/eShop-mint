using Mint.Domain.Helpers;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.SubCategories;

namespace Mint.WebApp.Admin.Operations.Commands.SubCategories;

public sealed record GetSubCategoriesCommand(
    string? Search,
    int PageIndex = 0,
    int PageSize = 50
) : ICommand<PaginatedResult<SubCategoryDTO>>;

internal sealed class GetSubCategoriesCommandHandler 
    : ICommandHandler<GetSubCategoriesCommand, PaginatedResult<SubCategoryDTO>>
{
    public Task<PaginatedResult<SubCategoryDTO>> Handle(GetSubCategoriesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
