﻿using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Models.Email;
using Mint.Infrastructure.Repositories.Email;

namespace Mint.WebApp.Email.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailRepository _email;

    public EmailController(IEmailRepository email)
    {
        _email = email;
    }

    [HttpPost]
    public async Task<IActionResult> SendTestMail([FromBody] UserEmailOptions user)
    {
        try
        {
            if (string.IsNullOrEmpty(user.Email.Trim()))
                throw new Exception("Неверный адрес электронной почты");

            var email = new EmailOptions()
            {
                ToEmails = new List<string>() { user.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new("{{Login}}", user.Email),
                },
            };

            await _email.SendTestEmailAsync(email);
            return Ok(new { message = "mail was sended" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}