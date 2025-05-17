using System.Windows.Input;

using NetMauiSamples.Shared.Services.Interfaces;
using NetMauiSamples.Shared.ViewModels.Base;

namespace NetMauiSamples.Shared.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IEmailService emailService;
    private readonly IPopupBoxService popupBoxService;

    public MainViewModel(IEmailService emailService,
                         IErrorHandler errorHandler, 
                         IInvocationService invocationService, 
                         INavigationProvider navigationProvider,
                         IPopupBoxService popupBoxService) 
                            : base(errorHandler, invocationService, navigationProvider)
    {
        this.emailService = emailService;
        this.popupBoxService = popupBoxService;

        SendTextViaEmailCommand = new Command(async () => await ExecuteSendTextViaEmailCommandAsync());
    }

    public ICommand SendTextViaEmailCommand { get; }

    private async Task ExecuteSendTextViaEmailCommandAsync()
    {
        bool actionConfirmed = await popupBoxService.ShowConfirmationDialogAsync(title: "Confirmation",
                   message: "If you accept this dialog, the email client app will be launched...",
                   confirmButtonTitle: "Accept",
                   declineButtonTitle: "Decline");

        if (actionConfirmed)
        {
            await emailService.SendTextViaEmailAsync(["someaddress@mail.com"], "some subject", "some text for email body");
        }
    }
}
