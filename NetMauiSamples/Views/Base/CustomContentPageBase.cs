using NetMauiSamples.Shared.Services.Interfaces;

namespace NetMauiSamples.Views.Base;

public abstract class CustomContentPageBase : ContentPage
{
    private readonly IPageEventHandler pageEventHandler;

    protected CustomContentPageBase(IPageEventHandler pageEventHandler)
    {
        this.pageEventHandler = pageEventHandler;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await pageEventHandler.OnPageAppearingAsync(BindingContext);
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await pageEventHandler.OnPageDisappearingAsync(BindingContext);
    }

    protected override async void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        await pageEventHandler.OnPageNavigatedFromAsync(BindingContext);
    }
}
