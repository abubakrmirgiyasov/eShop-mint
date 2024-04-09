using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.SubCategories;

public sealed record CreateSubCategoryCommand(SubCategoryFullBindingModel SubCategory)
    : ICommand<SubCategoryFullViewModel>;

internal sealed class CreateSubCategoryCommandHandler(
    ISubCategoryRepository subCategoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : ICommandHandler<CreateSubCategoryCommand, SubCategoryFullViewModel>
{
    private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
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

        await _subCategoryRepository.AddAsync(subCategory, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SubCategoryFullViewModel>(subCategory);
    }
}
