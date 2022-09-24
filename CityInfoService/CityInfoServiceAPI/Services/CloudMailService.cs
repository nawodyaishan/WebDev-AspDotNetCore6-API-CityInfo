namespace CityInfoServiceAPI.Services;

public class CloudMailService : IMailService
{
    private readonly string _mailTo;
    private readonly string _mailFrom;

    public CloudMailService(IConfiguration configuration)
    {
        _mailFrom = configuration["mailSettings:mailToAddress"];
        _mailTo = configuration["mailSettings:mailFromAddress"];
    }

    public void Send(string subject, string message)
    {
        // send mail - output to console window
        Console.WriteLine($"Mail From {_mailFrom} to {_mailTo} with {nameof(CloudMailService)}.");
        Console.WriteLine($"Subject {subject}");
        Console.WriteLine($"Message {message}");
    }
}