namespace NetMauiSamples.Shared.Services.Interfaces;

public interface IPageEventHandler
{
    public Task OnPageAppearingAsync(object bindingContext);
    public Task OnPageDisappearingAsync(object bindingContext);
    public Task OnPageNavigatedFromAsync(object bindingContext);
}
