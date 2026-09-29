namespace AppointmentBook.Services;

public interface IAuthenticationService
{
    Task<AuthenticationResult> LoginAsync(string email, string password);

    Task<AuthenticationResult> RegisterAsync(string name, string email, string password);
}

public sealed record AuthenticationResult(bool Succeeded, string Message);

// Replace this temporary service with the Identity-backed implementation.
public sealed class PlaceholderAuthenticationService : IAuthenticationService
{
    private const string NotConfiguredMessage = "Authentication isn't connected yet. Your information hasn't been saved.";

    public Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        return Task.FromResult(new AuthenticationResult(false, NotConfiguredMessage));
    }

    public Task<AuthenticationResult> RegisterAsync(string name, string email, string password)
    {
        return Task.FromResult(new AuthenticationResult(false, NotConfiguredMessage));
    }
}