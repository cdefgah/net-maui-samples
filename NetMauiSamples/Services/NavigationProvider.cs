using NetMauiSamples.Shared.Services.Interfaces;
using NetMauiSamples.Shared.ViewModels.Parameters.Interfaces;

namespace NetMauiSamples.Services;

public class NavigationProvider : INavigationProvider
{
    private readonly IInvocationService invocationService;

    public NavigationProvider(IInvocationService invocationService)
    {
        this.invocationService = invocationService;
    }

    /// <summary>
    /// Pushes page to display stack.
    /// </summary>
    /// <param name="uri">Page uri.</param>
    /// <param name="navigationParametersProvider">Parameters that should be passed to the page.</param>
    /// <returns>true if page displayed, false otherwise.</returns>
    public async Task<bool> PushPageAsync(string uri, INavigationParametersProvider navigationParametersProvider)
    {
        if (Shell.Current == null)
        {
            return false; // page not displayed
        }

        await invocationService.InvokeAsyncOnMainThread(async () =>
        {
            await Shell.Current.GoToAsync(uri, navigationParametersProvider.NavigationParameters);
        });

        return true; // page displayed
    }

    /// <summary>
    /// Pops the current non-modal page from the display stack.
    /// </summary>
    public async Task PopPageAsync()
    {
        await invocationService.InvokeAsyncOnMainThread(async () =>
        {
            if ( (Shell.Current != null) && (Shell.Current.Navigation.NavigationStack.Count > 0))
            {
                await Shell.Current.Navigation.PopAsync();
            }
        });
    }

    /// <summary>
    /// Pops the current modal page from the display stack.
    /// </summary>
    public async Task PopModalPageAsync()
    {
        await invocationService.InvokeAsyncOnMainThread(async () =>
        {
            if ( (Shell.Current != null) && (Shell.Current.Navigation.ModalStack.Count > 0) )
            {
                await Shell.Current.Navigation.PopModalAsync();
            }
        });
    }
}
