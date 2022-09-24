namespace CityInfoServiceAPI.Services;

public class LocalMailService : IMailService
{
    private readonly string _mailTo;
    private readonly string _mailFrom;

    public LocalMailService(IConfiguration configuration)
    {
        _mailFrom = configuration["mailSettings:mailToAddress"];
        _mailTo = configuration["mailSettings:mailFromAddress"];
    }

    public void Send(string subject, string message)
    {
        // send mail - output to console window
        Console.WriteLine($"Mail From {_mailFrom} to {_mailTo} with {nameof(LocalMailService)}.");
        Console.WriteLine($"Subject {subject}");
        Console.WriteLine($"Message {message}");
    }
}