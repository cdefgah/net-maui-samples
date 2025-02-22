using NetMauiSamples.Shared.Services.Interfaces;

namespace NetMauiSamples.Services;

public class InvocationService : IInvocationService
{
    private static bool InvokeRequired
    {
        get
        {
            try
            {
                return Application.Current!.Dispatcher.IsDispatchRequired;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }

    public void InvokeOnMainThreadIfRequired(Action action)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (InvokeRequired)
        {
            Application.Current!.Dispatcher.Dispatch(action);
        }
        else
        {
            action();
        }
    }

    public async Task InvokeAsyncOnMainThreadIfRequired(Func<Task> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (InvokeRequired)
        {
            await Application.Current!.Dispatcher.DispatchAsync(action);
        }
        else
        {
            await action();
        }
    }

    public void InvokeOnMainThread(Action action)
    {
        ArgumentNullException.ThrowIfNull(action);
        Application.Current!.Dispatcher.Dispatch(action);
    }

    public async Task InvokeAsyncOnMainThread(Func<Task> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        await Application.Current!.Dispatcher.DispatchAsync(action);
    }
}
