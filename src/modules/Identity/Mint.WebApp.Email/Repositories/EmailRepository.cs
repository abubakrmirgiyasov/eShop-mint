using Mint.Domain.Models;
using Mint.WebApp.Email.Interfaces;

namespace Mint.WebApp.Email.Repositories;

public class EmailRepository : IEmailRepository
{
    public Task SendTestEmail(User user)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailConfirmation(User user)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailForgotPassword(User user)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailSpam(User user)
    {
        throw new NotImplementedException();
    }
}
