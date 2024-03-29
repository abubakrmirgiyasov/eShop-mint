﻿using AutoMapper;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record GetSampleCategoryByIdCommand(Guid Id) : ICommand<List<CategorySampleViewModel>>;

internal sealed class GetSampleCategoryByIdCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : ICommandHandler<GetSampleCategoryByIdCommand, List<CategorySampleViewModel>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CategorySampleViewModel>> Handle(GetSampleCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FindByIdAsync(request.Id, cancellationToken: cancellationToken);

        var result = new List<CategorySampleViewModel>()
        {
            _mapper.Map<CategorySampleViewModel>(category)
        };

        return result;
    }
}