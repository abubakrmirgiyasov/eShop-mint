﻿using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Exceptions;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserFullBindingModel>> GetUsers()
    {
        try
        {
            var users = await _context.Users.ToListAsync();
            return new List<UserFullBindingModel>();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public User GetUserById(Guid id)
    {
        try
        {
            var user = _context.Users
                .Include(x => x.RefreshTokens!)
                .Include(x => x.UserRoles!)
                .ThenInclude(x => x.Role)
                .FirstOrDefault(x => x.Id == id);
            return user ?? throw new UserNotFoundException("Пользователь не найден.");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public User GetUserByToken(string token)
    {
        try
        {
            var user = _context.Users
                .Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens!.Any(y => y.Token == token));
            return user ?? throw new Exception("Invalid token.");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task AddNewUserAsync(UserFullBindingModel model)
    {
        try
        {
            var users = await _context.Users.ToListAsync();
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == Constants.BUYER);
            var isEmailExist = users.FirstOrDefault(x => x.Email == model.Email);
            var isPhoneExist = users.FirstOrDefault(x => x.Phone == model.Phone);

            if (isEmailExist != null)
                throw new Exception("Email error");

            if (isPhoneExist != null)
                throw new Exception("Phone error");

            var user = await new UserManager().FormingBindingModelAddNewUser(model);
            user.UserRoles?.Add(new UserRole() { RoleId = role!.Id, });

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateUserInfoAsync(UserFullBindingModel model)
    {
        try
        {
            var user = await _context.Users
                .Include(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Id == model.Id)
                ?? throw new UserNotFoundException("Пользователь не найден.");

            user.FirstName = model.FirstName!;
            user.SecondName = model.SecondName!;
            user.LastName = model.LastName;
            user.Gender = model.Gender!;
            user.Description = model.Description!;
            user.DateBirth = DateTime.Parse(model.DateOfBirth!);

            if (model.Photo != null && model.Folder != null)
            {
                var photo = await PhotoManager.CopyPhotoAsync(model.Photo, model.Id, model.Folder);
                if (user.Photo != null)
                {
                    photo.Users = new List<User> { user };
                    await _context.Photos.AddAsync(photo);
                }
                else
                {
                    // update photo
                }
            }
                        
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
