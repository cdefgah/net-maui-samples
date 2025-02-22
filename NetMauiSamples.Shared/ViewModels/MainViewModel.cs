using NetMauiSamples.Shared.Services.Interfaces;
using NetMauiSamples.Shared.ViewModels.Base;

namespace NetMauiSamples.Shared.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(IErrorHandler errorHandler, 
                         IInvocationService invocationService, 
                         INavigationProvider navigationProvider) 
                            : base(errorHandler, invocationService, navigationProvider)
    {

    }
}
