using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using GMTools.Dependencies.Custom;

namespace GMTools.Bootstrapper
{
    #region Usings

    using Utilities.MEF;
    using Dependencies.DataSet;
    using Dependencies.Localization;
    using Utilities.FileSystem;
    using Utilities.Localization;

    #endregion

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Private Properties

        private readonly CompositionContainer _mefContainer;
        
        [Import(typeof(IDataProvider))]
        private IDataProvider _dataProvider;

        [ImportMany(typeof(ICustomPlugin))]
        private IEnumerable<ICustomPlugin> _customPlugins; 

        private readonly ILocalizationProvider _localizationProvider;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            CheckDirectories();

            _mefContainer = MefConfigurator.Configure(Properties.Settings.Default.CurrentGame);
            _localizationProvider = new DefaultLocalizationProvider(Properties.Settings.Default.CurrentGame);

            try
            {
                _mefContainer.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            var styleFile = "Games\\" + Properties.Settings.Default.CurrentGame + "\\Style.xaml";

            if (!File.Exists(styleFile)) return;
            Application.Current.Resources.MergedDictionaries.Clear();

            using (var reader = new FileStream(styleFile, FileMode.Open))
            {
                Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary) XamlReader.Load(reader));
            }
        }

        #endregion

        /// <summary>
        /// Checks the directories.
        /// </summary>
        private void CheckDirectories()
        {
            var pluginDir = MefConfigurator.GamesBasePluginDirectory + Properties.Settings.Default.CurrentGame;

            DirectoryChecker.CheckIfExistsAndCreate(pluginDir);
            DirectoryChecker.CheckIfExistsAndCreate(pluginDir + "\\Data");
            DirectoryChecker.CheckIfExistsAndCreate(pluginDir + "\\Views");
            DirectoryChecker.CheckIfExistsAndCreate(pluginDir + "\\ExternalPlugins");
        }

        /// <summary>
        /// Handles the OnLoaded event of the MainWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var type in _dataProvider.Entities)
            {
                var tabItem = new TabItem
                {
                    Header = _localizationProvider.GetLocalizedString(type.Name + "Header", Properties.Settings.Default.CurrentLanguage)
                };

                EntityTab.Items.Add(tabItem);

                await _dataProvider.Repository(type).GenerateTableAsync();

                foreach (var plugin in _customPlugins)
                {
                    plugin.Window.Show();
                }
            }
        }
    }
}
