namespace NetMauiSamples.Shared.ViewModels.Interfaces;

public interface IEventDrivenViewModel
{
    public Task OnAppearingAsync();

    public Task OnDisappearingAsync();

    public Task OnNavigatedFromAsync();
}
