using NetMauiSamples.Shared.Services.Interfaces;
using NetMauiSamples.Shared.ViewModels.Interfaces;

namespace NetMauiSamples.Shared.Services;

public class PageEventHandler : IPageEventHandler
{
    public async Task OnPageAppearingAsync(object bindingContext)
    {
       if (bindingContext is IEventDrivenViewModel viewModel)
       {
            await viewModel.OnAppearingAsync();
       }
    }

    public async Task OnPageDisappearingAsync(object bindingContext)
    {
        if (bindingContext is IEventDrivenViewModel viewModel)
        {
            await viewModel.OnDisappearingAsync();
        }
    }

    public async Task OnPageNavigatedFromAsync(object bindingContext)
    {
        if (bindingContext is IEventDrivenViewModel viewModel)
        {
            await viewModel.OnNavigatedFromAsync();
        }
    }
}
