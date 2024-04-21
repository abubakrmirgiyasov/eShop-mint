using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.SubCategories;

public sealed record GetSubCategoryInfoQuery(Guid Id)
    : IQuery<SubCategoryInfoViewModel>;

internal sealed class GetSubCategoryInfoQueryHandler(
    ISubCategoryRepository subCategoryRepository,
    IMapper mapper
) : IQueryHandler<GetSubCategoryInfoQuery, SubCategoryInfoViewModel>
{
    private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<SubCategoryInfoViewModel> Handle(GetSubCategoryInfoQuery request, CancellationToken cancellationToken)
    {
        var subCategory = await _subCategoryRepository.GetSubCategoryInfoAsync(
            request.Id, 
            asNoTracking: true, 
            cancellationToken: cancellationToken
        );

        return _mapper.Map<SubCategoryInfoViewModel>(subCategory);
    }
}