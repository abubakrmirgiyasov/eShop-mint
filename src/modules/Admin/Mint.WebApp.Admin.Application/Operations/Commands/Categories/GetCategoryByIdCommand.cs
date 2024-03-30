using AutoMapper;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record GetCategoryByIdCommand(Guid Id) : ICommand<CategoryFullViewModel>;

internal sealed class GetCategoryByIdCommandHandler(
    ICategoryRepository categoryRepository, 
    IMapper mapper
) : ICommandHandler<GetCategoryByIdCommand, CategoryFullViewModel>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryFullViewModel> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FindByIdAsync(request.Id, asNoTracking: true, cancellationToken: cancellationToken);

        return _mapper.Map<CategoryFullViewModel>(category);
    }
}