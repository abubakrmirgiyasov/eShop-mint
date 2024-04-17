using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Tags;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetCategoriesQuery(
    string? Search,
    SortType Sorter,
    int PageIndex = 0,
    int PageSize = 50
) : IQuery<PaginatedResult<CategoryFullViewModel>>;

internal sealed class GetCategoriesQueryHandler(
    ICategoryRepository categoryRepository,
    IStorageCloudService storageCloudService,
    IMapper mapper
) : IQueryHandler<GetCategoriesQuery, PaginatedResult<CategoryFullViewModel>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<CategoryFullViewModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var (categories, totalCount) = await _categoryRepository.GetCategoriesAsync(
            searchPhrase: request.Search,
            sorter: request.Sorter,
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        var res = new List<CategoryFullViewModel>();

        foreach (var category in categories)
        {
            string? imagePath = "";

            if (category.Photo is not null)
            {
                imagePath = await _storageCloudService.GetFileLinkAsync(
                    name: category.Photo.FileName,
                    bucket: category.Photo.Bucket,
                    cancellationToken: cancellationToken
                );
            }

            res.Add(
                new CategoryFullViewModel 
                {
                    Id = category.Id,
                    Name = category.Name,
                    DisplayOrder = category.DisplayOrder,
                    BadgeStyle = category.BadgeStyle,
                    BadgeText = category.BadgeText,
                    Ico = category.Ico,
                    ImagePath = imagePath,
                    IsPublished = category.IsPublished,
                    ShowOnHomePage = category.ShowOnHomePage,
                    DefaultLink = new DefaultLinkDTO { DefaultLink = category.DefaultLink ?? "" },
                    SubCategories = _mapper.Map<List<SubCategorySimpleViewModel>>(category.SubCategories),
                    CategoryTags = _mapper.Map<List<TagSampleViewModel>>(category.CategoryTags),
                    Manufactures = _mapper.Map<List<ManufactureSampleViewModel>>(category.ManufactureCategories)
                }
            );
        }

        return new PaginatedResult<CategoryFullViewModel>
        {
            Items = res,
            TotalCount = totalCount,
        };
    }
}