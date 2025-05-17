using Mopups.Pages;

namespace NetMauiSamples.Shared.Services.Interfaces;

public interface IPopupBoxService
{
    public Task ShowPopupPageAsync(PopupPage page);

    public Task HidePopupPageAsync(PopupPage page);

    public Task ShowAlertAsync(string title, string message, Action? onClosed = null);

    public Task ShowConfirmationDialogAsync(string title, string message, Action? onActionConfirmed = null, Action? onActionDeclined = null, string confirmButtonTitle = "Ja", string declineButtonTitle = "Nein");

    public Task<bool> ShowConfirmationDialogAsync(string title, string message, string confirmButtonTitle = "Хорошо", string declineButtonTitle = "Отменить");

    public Task<string> ShowActionSheetAsync(string title, string cancel, string? destruction = null, string[]? buttons = null);

    public Task<string> ShowInputBoxAsync(string title, string message, string defaultValue, string acceptButtonTitle = "Хорошо", string cancelButtonTitle = "Отменить");
}
