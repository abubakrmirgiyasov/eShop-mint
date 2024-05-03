using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Manufactures;

public sealed record GetManufacturesQuery(
    string? Search,
    int PageIndex = 0,
    int PageSize = 25
) : IQuery<PaginatedResult<ManufactureFullViewModel>>;

internal sealed class GetManufacturesQueryHandler(
    IManufactureRepository manufactureRepository,
    IStorageCloudService storageCloudService,
    IMapper mapper
) : IQueryHandler<GetManufacturesQuery, PaginatedResult<ManufactureFullViewModel>>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<ManufactureFullViewModel>> Handle(
        GetManufacturesQuery request,
        CancellationToken cancellationToken)
    {
        var (manufactures, totalCount) = await _manufactureRepository.GetManufacturesAsync(
            searchPhrase: request.Search,
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        var result = new List<ManufactureFullViewModel>();

        foreach (var manufacture in manufactures)
        {
            string? imagePath = "";

            if (manufacture.Photo is not null)
            {
                imagePath = await _storageCloudService.GetFileLinkAsync(
                    name: manufacture.Photo.FilePath,
                    bucket: manufacture.Photo.Bucket,
                    cancellationToken: cancellationToken
                );
            }

            result.Add(
                new ManufactureFullViewModel
                {
                    Id = manufacture.Id,
                    ImagePath = imagePath,
                    Name = manufacture.Name,
                    Website = manufacture.Website,
                    FullAddress = manufacture.FullAddress,
                    DisplayOrder = manufacture.DisplayOrder,
                    Description = manufacture.Description,
                    Country = manufacture.Country,
                    Contacts = _mapper.Map<List<ManufactureContactDto>>(manufacture.Contacts),
                }
            );
        }

        return new PaginatedResult<ManufactureFullViewModel>(result, totalCount);
    }
}