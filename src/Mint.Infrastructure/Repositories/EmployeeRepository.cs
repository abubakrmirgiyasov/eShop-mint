//using Microsoft.EntityFrameworkCore;
//using Mint.Domain.FormingModels;
//using Mint.Domain.ViewModels;
//using Mint.Infrastructure.Repositories.Interfaces;

//namespace Mint.Infrastructure.Repositories;

//public class EmployeeRepository : IEmployeeRepository
//{
//    private readonly ApplicationDbContext _context;

//    public EmployeeRepository(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<List<UserFullViewModel>> GetEmployeesAsync()
//    {
//        try
//        {
//            var employees = await _context.Users
//                .Include(x => x.Photo)
//                .Include(x => x.UserRoles!)
//                .ThenInclude(x => x.Role)
//                .ToListAsync();
//            return new UserManager().FormingMultiViewModels(employees);
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message, ex);
//        }
//    }
//}
