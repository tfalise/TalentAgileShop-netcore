using System;
using Microsoft.Extensions.DependencyInjection;
using TalentAgileShop.Model;

public static class FeatureConfigurationHelper
{
    public static void AddFeatureConfiguration(this IServiceCollection serviceCollection, Action<FeatureConfigurationOptions> configure)
    {
        var featureSet = new FeatureSet  {
            CatalogCategoriesEnabled = false,
            ThumbnailViewEnabled = false
        };

        configure(new FeatureConfigurationOptions(featureSet));

        serviceCollection.AddSingleton<FeatureSet>(featureSet);
    }
}
