using System.ComponentModel.Composition.Hosting;

namespace GMTools.Utilities.MEF
{
    /// <summary>
    /// Static helper class doing configuration work for MEF (Managed Extensibility Framework) which is used by this application to retrieve plugins.
    /// </summary>
    public static class MefConfigurator
    {
        #region Public Properties

        public static string GamesBasePluginDirectory
        {
            get { return "Games\\"; }
        }

        #endregion

        /// <summary>
        /// Configures the MEF instance populating the catalog with all the directories needed and generating a CompositionContainer.
        /// </summary>
        /// <param name="gameName">Name of the game.</param>
        /// <returns></returns>
        public static CompositionContainer Configure(string gameName)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(GamesBasePluginDirectory + gameName + "\\Data"));
            catalog.Catalogs.Add(new DirectoryCatalog(GamesBasePluginDirectory + gameName + "\\Views"));
            catalog.Catalogs.Add(new DirectoryCatalog(GamesBasePluginDirectory + gameName + "\\ExternalPlugins"));
            
            return new CompositionContainer(catalog);
        }
    }
}
