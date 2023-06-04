using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<List<UserFullViewModel>> GetEmployeesAsync();
}
