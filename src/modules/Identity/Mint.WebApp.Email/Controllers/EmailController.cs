using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Email.Interfaces;
using Mint.WebApp.Email.Models;

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
                throw new Exception("Не правильный адрес электронной почти");

            var email = new EmailOptions()
            {
                ToEmails = new List<string>() { user.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{Login}}", user.Email),
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