namespace CityInfoServiceAPI.Services;

public class CloudMailService : IMailService
{
    public string MailTo = "nawodyain@gmail.com";
    public string MailFrom = "logger@cityInfo.com";

    public void Send(string subject, string message)
    {
        // send mail - output to console window
        Console.WriteLine($"Mail From {MailFrom} to {MailTo} with {nameof(CloudMailService)}.");
        Console.WriteLine($"Subject {subject}");
        Console.WriteLine($"Message {message}");
    }
}