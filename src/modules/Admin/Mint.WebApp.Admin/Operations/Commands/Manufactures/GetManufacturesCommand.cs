using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Helpers;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Operations.Commands.Manufactures;

public sealed record GetManufacturesCommand(
    string? Search,
    int PageIndex = 0,
    int PageSize = 25
) : ICommand<PaginatedResult<ManufactureFullViewModel>>;

internal sealed class GetManufacturesCommandHandler(
    IManufactureRepository manufactureRepository,
    IStorageCloudService storageCloudService,
    IMapper mapper
) : ICommandHandler<GetManufacturesCommand, PaginatedResult<ManufactureFullViewModel>>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<ManufactureFullViewModel>> Handle(
        GetManufacturesCommand request, 
        CancellationToken cancellationToken)
    {
        var query = _manufactureRepository.Context.Manufactures.AsQueryable();

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(x => x.Name.Contains(request.Search));

        var manufactures = await query
            .AsNoTracking()
            .Include(x => x.Contacts)
            .Include(x => x.ManufactureTags!)
            .ThenInclude(x => x.Tag)
            .Include(x => x.ManufactureCategories!)
            .ThenInclude(x => x.Category)
            .Include(x => x.Photo)
            .Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var totalCount = await _manufactureRepository
            .Context
            .Categories
            .AsNoTracking()
            .CountAsync(cancellationToken);

        var result = new List<ManufactureFullViewModel>();

        foreach (var manufacture in manufactures)
        {
            string imagePath = "";

            if (manufacture.Photo is not null)
            {
                imagePath = await _storageCloudService.GetFileLinkAsync(
                    name: manufacture.Photo.FilePath,
                    bucket: manufacture.Photo.FileType,
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

        return new PaginatedResult<ManufactureFullViewModel>
        {
            Items = result,
            TotalCount = totalCount
        };
    }
}