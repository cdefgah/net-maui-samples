using System.Collections.Immutable;

namespace NetMauiSamples.Shared.ViewModels.Parameters.Interfaces;

public interface INavigationParametersProvider
{
    public ImmutableDictionary<string, object> NavigationParameters { get; }
}
