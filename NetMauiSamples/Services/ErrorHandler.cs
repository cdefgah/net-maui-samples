using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

using NetMauiSamples.Shared.Services.Interfaces;
using NetMauiSamples.Shared.Utils;

namespace NetMauiSamples.Services;

public class ErrorHandler : IErrorHandler
{
    private readonly IInvocationService invocationService;
    
    public ErrorHandler(IInvocationService invocationService)
    {
        this.invocationService = invocationService;
    }

    public void HandleError(Exception ex)
    {
        DisplayToastMessage(ex.Message);
    }

    private void DisplayToastMessage(string message)
    {
        invocationService.InvokeOnMainThread(() =>
        {
            const int fontSize = 18;
            ToastDuration duration = ToastDuration.Long;
            var toast = Toast.Make(message, duration, fontSize);
            toast.Show().FireAndForgetSafeAsync();
        });
    }
}
