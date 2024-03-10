using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.WebApp.Admin.Services;

public class CategoryService(
    ICategoryRepository categoryRepository,
    IStorageCloudService storageCloudService,
    ILogger<CategoryService> logger)
{
    private readonly ILogger<CategoryService> _logger = logger;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
}
