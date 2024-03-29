﻿using Microsoft.AspNetCore.Mvc;
using Mint.Domain.DTO_s.Identity;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.Domain.Extensions;

namespace Mint.WebApp.Identity.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _user;

    public UserController(IUserRepository user)
    {
        _user = user;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAddresses(Guid id)
    {
        try
        {
            var addresses = await _user.GetUserAddressesAsync(id);
            return Ok(addresses);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> SendEmailConfirmationCode([FromBody] UserFullBindingModel model)
    {
		try
		{
            var code = await _user.SendEmailConfirmationCodeAsync(model.Email!);
            Response.SetConfirmationCode(code);
            return Ok(code);
		}
		catch (Exception ex)
		{
            return BadRequest(new { message = ex.Message });
		}
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAddress([FromBody] UserAddressFullBindingModel model)
    {
        try
        {
            var address = await _user.CreateUserAddressAsync(model);
            return Ok(address);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAddress([FromBody] UserAddressFullBindingModel model)
    {
        try
        {
            var address = await _user.UpdateUserAddressAsync(model);
            return Ok(address);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAddress(Guid id)
    {
        try
        {
            await _user.DeleteUserAddressAsync(id);
            return Ok(new { message = "Удалено успешно" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserFullBindingModel model)
    {
		try
		{
            var user = await _user.UpdateUserAsync(model);
			return Ok(user);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserPassword([FromBody] UserFullBindingModel model)
    {
        try
        {
            await _user.UpdateUserPasswordAsync(model);
            return Ok(new { message = "Обновлено успешно" });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
