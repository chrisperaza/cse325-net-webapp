using AppointmentBook.Data;
using AppointmentBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBook.Services;

public class AuthService(ApplicationDbContext dbContext, IPasswordHasher<User> passwordHasher)
{
    public async Task<string?> RegisterAsync(string name, string email, string password)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();

        var emailTaken = await dbContext.Users
            .AnyAsync(user => user.Email == normalizedEmail);

        if (emailTaken)
        {
            return "An account with that email already exists.";
        }

        var user = new User
        {
            Name = name.Trim(),
            Email = normalizedEmail,
        };

        user.PasswordHash = passwordHasher.HashPassword(user, password);

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        return null;
    }

    public async Task<User?> ValidateCredentialsAsync(string email, string password)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();

        var user = await dbContext.Users
            .FirstOrDefaultAsync(user => user.Email == normalizedEmail);

        if (user is null)
        {
            return null;
        }

        var verification = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

        return verification == PasswordVerificationResult.Failed ? null : user;
    }
}
