using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GMTools.Dependencies.DataSet;
using GMTools.Utilities.FileSystem;

namespace GMTools.Bootstrapper
{
    #region Usings

    using Utilities.MEF;

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

            try
            {
                _mefContainer.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                MessageBox.Show(ex.ToString());
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
            DirectoryChecker.CheckIfExistsAndCreate(pluginDir + "\\Styles");
            DirectoryChecker.CheckIfExistsAndCreate(pluginDir + "\\ExternalPlugins");
        }

        /// <summary>
        /// Handles the OnLoaded event of the MainWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var type in _dataProvider.Entities)
            {
                var tabItem = new TabItem { Header = type.Name };
                EntityTab.Items.Add(tabItem);

                _dataProvider.Repository(type).GenerateTable();
            }
        }
    }
}
