using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;

using NetMauiSamples.Services;
using NetMauiSamples.Shared.Services;
using NetMauiSamples.Shared.Services.Interfaces;
using NetMauiSamples.Shared.ViewModels;
using NetMauiSamples.Shared.ViewModels.Base;
using NetMauiSamples.Views;

namespace NetMauiSamples;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        
        builder.RegisterServices();
        return builder.Build();
    }

    private static void RegisterServices(this MauiAppBuilder builder)
    {
        RegisterUtilityServices(builder);
        RegisterViewModelsAndPages(builder);
    }

    private static void RegisterUtilityServices(MauiAppBuilder builder)
    {
        // registering platform-agnostic utility services here
        builder.Services.AddSingleton<IErrorHandler, ErrorHandler>();
        builder.Services.AddSingleton<IInvocationService, InvocationService>();
        builder.Services.AddSingleton<INavigationProvider, NavigationProvider>();
        builder.Services.AddSingleton<IPageEventHandler, PageEventHandler>();

        // and registering platform dependent services afterwards
        RegisterPlatformDependentUtilityServices(builder);
    }

    private static void RegisterPlatformDependentUtilityServices(MauiAppBuilder builder)
    {
#if WINDOWS

#elif MACCATALYST

#elif ANDROID

#elif IOS

#elif TIZEN

#else
     throw new PlatformNotSupportedException($"Unsupported platform {DeviceInfo.Platform} upon registering platform dependent utility services!");
#endif
    }

    private static void RegisterViewModelsAndPages(MauiAppBuilder builder)
    {
        builder.RegisterPageAndViewModel<MainPage, MainViewModel>();
    }

    private static void RegisterPageAndViewModel<TPage, TViewModel>(this MauiAppBuilder builder)
                                                                    where TViewModel : ViewModelBase where TPage : Page
    {
        builder.Services.AddTransient<TPage>();
        builder.Services.AddTransient<TViewModel>();
    }
}
