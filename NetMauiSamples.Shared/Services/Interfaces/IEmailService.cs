namespace NetMauiSamples.Shared.Services.Interfaces;

public interface IEmailService
{
    public Task SendTextViaEmailAsync(List<string> recipientAddresses, string emailSubject, string emailBody);
}
