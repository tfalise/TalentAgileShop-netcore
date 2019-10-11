using System;

public class FeatureConfigurationOptions 
{
    private FeatureSet featureSet;

    public FeatureConfigurationOptions(FeatureSet featureSet)
    {
        this.featureSet = featureSet;
    }

    public FeatureConfigurationOptions UseEnvironmentVariables() {
        featureSet.CatalogCategoriesEnabled = GetBoolValueFromEnv("EnableCatalogCategories", featureSet.CatalogCategoriesEnabled);
        featureSet.ThumbnailViewEnabled = GetBoolValueFromEnv("EnableThumbnailView", featureSet.ThumbnailViewEnabled);
        return this;
    }

    public FeatureConfigurationOptions OverrideFeatures(Action<FeatureSet> setFeatures) {
        setFeatures(this.featureSet);
        return this;
    } 

    private static bool GetBoolValueFromEnv(string environmentVariable, bool defaultValue)
        {
            var envValue = System.Environment.GetEnvironmentVariable(environmentVariable);

            if (envValue == null)
            {
                return defaultValue;                
            }

            return string.Compare(envValue.Trim(), "true", StringComparison.InvariantCultureIgnoreCase) == 0;
        }
}