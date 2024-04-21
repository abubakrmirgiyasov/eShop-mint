using AutoMapper;
using FluentValidation;
using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Validations.SubCategories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.SubCategories;

public sealed record CreateSubCategoryCommand(SubCategoryInfoBindingModel SubCategory)
    : ICommand<SubCategoryInfoViewModel>;

internal sealed class CreateSubCategoryCommandHandler(
    ISubCategoryRepository subCategoryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : ICommandHandler<CreateSubCategoryCommand, SubCategoryInfoViewModel>
{
    private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<SubCategoryInfoViewModel> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateSubCategoryCommandValidator();
        var validatorValidation = validator.Validate(request.SubCategory);

        if (!validatorValidation.IsValid)
            throw new ValidationException(validatorValidation.Errors);

        var subCategory = new SubCategory
        {
            Id = Guid.NewGuid(),
            DisplayOrder = request.SubCategory.DisplayOrder,
            Name = request.SubCategory.Name,
            FullName = request.SubCategory.FullName,
            DefaultLink = request.SubCategory.DefaultLink,
            CategoryId = request.SubCategory.Category.Value,
        };

        await _subCategoryRepository.AddAsync(subCategory, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SubCategoryInfoViewModel>(subCategory);
    }
}
