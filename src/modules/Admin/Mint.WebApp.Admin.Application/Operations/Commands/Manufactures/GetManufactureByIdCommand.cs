using AutoMapper;
using Mint.Infrastructure.Repositories.Admin;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Manufactures;

public sealed record GetManufactureByIdCommand(Guid Id) : ICommand<ManufactureFullViewModel>;

internal sealed class GetManufactureByIdCommandHandler(
    IManufactureRepository manufactureRepository,
    IStorageCloudService storageCloudService,
    IMapper mapper
) : ICommandHandler<GetManufactureByIdCommand, ManufactureFullViewModel>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IMapper _mapper = mapper;

    public async Task<ManufactureFullViewModel> Handle(GetManufactureByIdCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.FindByIdAsync(request.Id, asNoTracking: true, cancellationToken: cancellationToken);

        string imagePath = "";

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
