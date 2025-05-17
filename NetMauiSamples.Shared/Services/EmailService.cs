using NetMauiSamples.Shared.Services.Interfaces;

namespace NetMauiSamples.Shared.Services;

public class EmailService : IEmailService
{
    private readonly IPopupBoxService popupBoxService;

    public EmailService(IPopupBoxService popupBoxService)
    {
        this.popupBoxService = popupBoxService;
    }

    public async Task SendTextViaEmailAsync(List<string> recipientAddresses, 
                                            string emailSubject, 
                                            string emailBody)
    {
        try
        {
            var emailMessage = new EmailMessage
            {
                Subject = emailSubject,
                Body = emailBody,
                To = recipientAddresses
            };

            // Launching email app with composed message ready to be sent
            await Email.Default.ComposeAsync(emailMessage);
        }
        catch (FeatureNotSupportedException)
        {
            // If email client is not configured properly
            await popupBoxService.ShowAlertAsync(title: "Error", message: "Email client is not configured properly...");
        }
        catch (Exception ex)
        {
            // Some general kind of error
            await popupBoxService.ShowAlertAsync(title: "Error", message: ex.Message);
        }
    }
}
