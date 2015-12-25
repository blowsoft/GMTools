namespace GMTools.Dependencies.Localization
{
    /// <summary>
    /// Interface for a pack which grants localization capabilities to the plugin.
    /// </summary>
    public interface ILocalizationProvider
    {
        /// <summary>
        /// Gets the localized string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        string GetLocalizedString(string key, string language);
    }
}
