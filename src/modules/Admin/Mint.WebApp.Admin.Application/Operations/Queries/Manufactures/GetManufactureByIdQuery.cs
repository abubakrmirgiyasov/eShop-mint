using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Manufactures;

public sealed record GetManufactureByIdQuery(Guid Id) : IQuery<ManufactureFullViewModel>;

internal sealed class GetManufactureByIdQueryHandler(
    IManufactureRepository manufactureRepository,
    IStorageCloudService storageCloudService,
    IMapper mapper
) : IQueryHandler<GetManufactureByIdQuery, ManufactureFullViewModel>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IMapper _mapper = mapper;

    public async Task<ManufactureFullViewModel> Handle(GetManufactureByIdQuery request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.GetManufactureByIdAsync(request.Id, cancellationToken);

        string? imagePath = "";

        if (manufacture.Photo is not null)
        {
            imagePath = await _storageCloudService.GetFileLinkAsync(
                name: manufacture.Photo.FilePath,
                bucket: manufacture.Photo.FileType,
                cancellationToken: cancellationToken
            );
        }

        var manufactureDto = _mapper.Map<ManufactureFullViewModel>(manufacture);
        manufactureDto.ImagePath = imagePath;
        return manufactureDto;
    }
}
