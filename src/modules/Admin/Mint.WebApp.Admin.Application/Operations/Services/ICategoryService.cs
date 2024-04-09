using Mint.Domain.Models.Admin.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Services;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesFromRedisAsync(string key);
}
