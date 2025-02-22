using NetMauiSamples.Shared.Services.Interfaces;

namespace NetMauiSamples.Shared.Utils;

public static class ClassExtensions
{
    public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler? handler = null)
    {
        try
        {
            await task;
        }
        catch (Exception ex)
        {
            handler?.HandleError(ex);
        }
    }
}
