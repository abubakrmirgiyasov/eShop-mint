using Mint.Domain.Models.Admin.Manufactures;
using Mint.Infrastructure.Repositories;

namespace Mint.WebApp.Admin.Repositories.Interfaces;

public interface IManufactureRepository 
    : IBaseRepository<Manufacture, Guid> { }
