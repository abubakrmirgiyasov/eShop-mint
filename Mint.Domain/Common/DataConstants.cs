using Mint.Domain.Models;

namespace Mint.Domain.Common;

public static class UserDataConstants
{
    public static User[] GetExampleUsers()
    {
        var salt = new Hasher().GetSalt();

        return new User[]
        {
            new User()
            {
                FirstName = "Миргиясов",
                SecondName = "Абубакр",
                LastName = "Мукимжонович",
                Email = "abubakrmirgiyasov@gmail.com",
                Phone = 89502768428,
                Ip = "127.0.0.1",
                Password = new Hasher().GetHash("AbuakrMirgiyasov@))!M", salt),
                NumOfAttempts = 0,
                Salt = salt,
                Description = "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428",
                IsActive = true,
                IsConfirmedEmail = true,
                ZipCode = 654000,
                CreatedDate = DateTime.Now,
            },
            new User()
            {
                FirstName = "Test",
                SecondName = "User",
                Email = "test_1@gmail.com",
                Phone = 83452763423,
                Ip = "127.0.0.2",
                Password = new Hasher().GetHash("test_1", salt),
                NumOfAttempts = 0,
                Salt = salt,
                Description = "Test User Почта: test_1@gmail.com Телефон: 83452763423",
                IsActive = true,
                IsConfirmedEmail = true,
                ZipCode = 654000,
                CreatedDate = DateTime.Now,
            },
        };
    }
}

public static class RoleDataContstants
{
    public static Role[] GetExampleRoles()
    {
        return new Role[] 
        {
            new Role
            {
                Id = Guid.NewGuid(),
                Name = Constants.ADMIN,
                CreactionDate = DateTime.Now
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = Constants.SELLER,
                CreactionDate = DateTime.Now
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = Constants.BUYER,
                CreactionDate = DateTime.Now
            },
        };
    }
}

public static class UserRoleDataConstants
{
    public static UserRole[] GetExampleUserRoles()
    {
        return new UserRole[]
        {
            new UserRole 
            { 
                UserId = UserDataConstants.GetExampleUsers()[0].Id,
                RoleId = RoleDataContstants.GetExampleRoles()[0].Id,
            },
            new UserRole
            {
                UserId = UserDataConstants.GetExampleUsers()[0].Id,
                RoleId = RoleDataContstants.GetExampleRoles()[1].Id,
            },
            new UserRole
            {
                UserId = UserDataConstants.GetExampleUsers()[1].Id,
                RoleId = RoleDataContstants.GetExampleRoles()[0].Id,
            },
            new UserRole
            {
                UserId = UserDataConstants.GetExampleUsers()[1].Id,
                RoleId = RoleDataContstants.GetExampleRoles()[1].Id,
            },
            new UserRole
            {
                UserId = UserDataConstants.GetExampleUsers()[1].Id,
                RoleId = RoleDataContstants.GetExampleRoles()[2].Id,
            },
        };
    }
}