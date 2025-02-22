using NetMauiSamples.Shared.Services.Interfaces;
using NetMauiSamples.Shared.ViewModels;
using NetMauiSamples.Views.Base;

namespace NetMauiSamples.Views;

public partial class MainPage : CustomContentPageBase
{
	public MainPage(MainViewModel mainViewModel, IPageEventHandler pageEventHandler) : base(pageEventHandler)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}
}