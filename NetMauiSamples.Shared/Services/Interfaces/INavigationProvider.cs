using NetMauiSamples.Shared.ViewModels.Parameters.Interfaces;

namespace NetMauiSamples.Shared.Services.Interfaces;

public interface INavigationProvider
{
    /// <summary>
    /// Pushes page to display stack.
    /// </summary>
    /// <param name="uri">Page uri.</param>
    /// <param name="navigationParametersProvider">Parameters that should be passed to the page.</param>
    /// <returns>true if page displayed, false otherwise.</returns>
    public Task<bool> PushPageAsync(string uri, INavigationParametersProvider navigationParametersProvider);

    /// <summary>
    /// Pops the current page from the display stack.
    /// </summary>
    public Task PopPageAsync();

    /// <summary>
    /// Pops the current modal page from the display stack.
    /// </summary>
    public Task PopModalPageAsync();
}
