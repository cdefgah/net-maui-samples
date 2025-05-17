using Mopups.Pages;
using Mopups.Services;

using NetMauiSamples.Shared.Services.Interfaces;

namespace NetMauiSamples.Shared.Services;

public class PopupBoxService : IPopupBoxService
{
    private static Page? CurrentMainPage => Application.Current?.Windows[0].Page;

    public async Task ShowAlertAsync(string title, string message, Action? onClosed = null)
    {
        ArgumentNullException.ThrowIfNull(CurrentMainPage);
        await CurrentMainPage.DisplayAlert(title, message, "Ok");
        onClosed?.Invoke();
    }

    public async Task<string> ShowActionSheetAsync(string title, 
                                                   string cancel, 
                                                   string? destruction = null, 
                                                   string[]? buttons = null)
    {
        ArgumentNullException.ThrowIfNull(CurrentMainPage);

        var displayButtons = buttons ?? [];
        var action = await CurrentMainPage.DisplayActionSheet(title, cancel, destruction, displayButtons);
        return action;
    }

    public async Task<bool> ShowConfirmationDialogAsync(string title, 
                                                        string message, 
                                                        string confirmButtonTitle = "Ok", 
                                                        string declineButtonTitle = "Cancel")
    {
        ArgumentNullException.ThrowIfNull(CurrentMainPage);
        return await CurrentMainPage.DisplayAlert(title, message, confirmButtonTitle, declineButtonTitle);
    }

    public async Task ShowConfirmationDialogAsync(string title,
                                                  string message,
                                                  Action? onActionConfirmed = null,
                                                  Action? onActionDeclined = null,
                                                  string confirmButtonTitle = "Ok",
                                                  string declineButtonTitle = "Cancel")
    {
        ArgumentNullException.ThrowIfNull(CurrentMainPage);
        var answer = await CurrentMainPage.DisplayAlert(title, message, confirmButtonTitle, declineButtonTitle);
        if (answer)
        {
            onActionConfirmed?.Invoke();
        }
        else
        {
            onActionDeclined?.Invoke();
        }
    }

    public async Task<string> ShowInputBoxAsync(string title, 
                                                string message, 
                                                string defaultValue, 
                                                string acceptButtonTitle = "Ok", 
                                                string cancelButtonTitle = "Cancel")
    {
        ArgumentNullException.ThrowIfNull(CurrentMainPage);
        return await CurrentMainPage.DisplayPromptAsync(title, 
                                                        message, 
                                                        initialValue: defaultValue, 
                                                        accept: acceptButtonTitle, 
                                                        cancel: cancelButtonTitle);
    }

    public async Task ShowPopupPageAsync(PopupPage page)
    {
        await MopupService.Instance.PushAsync(page, false);
    }

    public async Task HidePopupPageAsync(PopupPage page)
    {
        await MopupService.Instance.RemovePageAsync(page);
    }
}
