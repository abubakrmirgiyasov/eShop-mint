using AutoMapper;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Operations.Commands.SubCategories;

public sealed record CreateSubCategoryCommand(SubCategoryFullBindingModel SubCategory)
    : ICommand<SubCategoryFullViewModel>;

internal sealed class CreateSubCategoryCommandHandler(
    ISubCategoryRepository subCategoryRepository,
    IMapper mapper
) : ICommandHandler<CreateSubCategoryCommand, SubCategoryFullViewModel>
{
    private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<SubCategoryFullViewModel> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var subCategory = new SubCategory
        {
            Id = Guid.NewGuid(),
            DisplayOrder = request.SubCategory.DisplayOrder,
            Name = request.SubCategory.Name,
            FullName = request.SubCategory.FullName,
            DefaultLink = request.SubCategory.DefaultLink,
            CategoryId = request.SubCategory.CategoryId,
        };

        await _subCategoryRepository.Context.AddAsync(subCategory, cancellationToken);

        return _mapper.Map<SubCategoryFullViewModel>(subCategory);
    }
}
