using NetMauiSamples.Shared.Services.Interfaces;
using NetMauiSamples.Shared.ViewModels.Interfaces;
using NetMauiSamples.Shared.ViewModels.Parameters.Interfaces;

namespace NetMauiSamples.Shared.ViewModels.Base;

public abstract class ViewModelBase : BindableObjectBase, IEventDrivenViewModel, IErrorHandler, INavigationProvider
{
    #region Fields
    protected readonly IErrorHandler errorHandler;
    protected readonly IInvocationService invocationService;
    protected readonly INavigationProvider navigationProvider;
    #endregion

    protected ViewModelBase(IErrorHandler errorHandler,
                            IInvocationService invocationService,
                            INavigationProvider navigationProvider)
    {
        this.errorHandler = errorHandler;
        this.invocationService = invocationService;
        this.navigationProvider = navigationProvider;
    }

    #region Interface implementations
    public void HandleError(Exception ex)
    {
        errorHandler.HandleError(ex);
    }

    public virtual Task OnAppearingAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnDisappearingAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnNavigatedFromAsync()
    {
        return Task.CompletedTask;
    }

    public async Task PopModalPageAsync()
    {
        await navigationProvider.PopModalPageAsync();
    }

    public async Task PopPageAsync()
    {
        await navigationProvider.PopPageAsync();
    }

    public async Task<bool> PushPageAsync(string uri, INavigationParametersProvider navigationParametersProvider)
    {
        return await navigationProvider.PushPageAsync(uri, navigationParametersProvider);
    }
    #endregion
}
