using Microsoft.Extensions.Logging;
using Mint.Infrastructure.Repositories.Admin;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.WebApp.Admin.Application.Operations.Services;

public class CategoryService(
    ICategoryRepository categoryRepository,
    IStorageCloudService storageCloudService,
    ILogger<CategoryService> logger
) : ICategoryService
{
    private readonly ILogger<CategoryService> _logger = logger;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
}
