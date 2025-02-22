namespace NetMauiSamples.Shared.Services.Interfaces;

public interface IInvocationService
{
    void InvokeOnMainThreadIfRequired(Action action);

    Task InvokeAsyncOnMainThreadIfRequired(Func<Task> action);

    void InvokeOnMainThread(Action action);

    Task InvokeAsyncOnMainThread(Func<Task> action);
}
