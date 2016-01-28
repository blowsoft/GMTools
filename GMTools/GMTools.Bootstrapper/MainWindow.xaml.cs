using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using GMTools.Dependencies.Command;
using GMTools.Dependencies.Custom;
using GMTools.Dependencies.Entity;

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
        #region Public Properties

        /// <summary>
        /// Gets or sets the user guide command.
        /// </summary>
        /// <value>
        /// The user guide command.
        /// </value>
        public ICommand UserGuideCommand { get; set; }

        /// <summary>
        /// Gets or sets the about program command.
        /// </summary>
        /// <value>
        /// The about program command.
        /// </value>
        public ICommand AboutProgramCommand { get; set; }

        /// <summary>
        /// Gets or sets the about developers command.
        /// </summary>
        /// <value>
        /// The about developers command.
        /// </value>
        public ICommand AboutDevelopersCommand { get; set; }

        #endregion

        #region Private Properties

        private readonly CompositionContainer _mefContainer;
        
        [Import(typeof(IDataProvider))]
        private IDataProvider _dataProvider;

        [ImportMany(typeof(ICustomPlugin))]
        private IEnumerable<ICustomPlugin> _customPlugins;

        [ImportMany(typeof(IEntityListView))]
        private IEnumerable<IEntityListView> _entityListViews; 

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

            LoadPluginStyleIfPresent();
            LoadCustomPluginMenuEntries();

            PrepareCommands();
        }

        #endregion

        /// <summary>
        /// Prepares the commands.
        /// </summary>
        private void PrepareCommands()
        {
            UserGuideCommand = new RelayCommand<object>(OpenUserGuide);
            AboutProgramCommand = new RelayCommand<object>(OpenAboutProgram);
            AboutDevelopersCommand = new RelayCommand<object>(OpenAboutDevelopers);
        }

        /// <summary>
        /// Loads the custom plugin menu entries.
        /// </summary>
        private void LoadCustomPluginMenuEntries()
        {
            foreach (var plugin in _customPlugins)
            {
                PluginsMenuItem.Items.Add(new MenuItem
                {
                    Header = plugin.GetType().Name,
                    Command = new RelayCommand<ICustomPlugin>(CustomPluginCommand),
                    CommandParameter = plugin
                });
            }
        }

        /// <summary>
        /// Loads the plugin style if present.
        /// </summary>
        private void LoadPluginStyleIfPresent()
        {
            var styleFile = "Games\\" + Properties.Settings.Default.CurrentGame + "\\Style.xaml";

            if (!File.Exists(styleFile)) return;
            Application.Current.Resources.MergedDictionaries.Clear();

            using (var reader = new FileStream(styleFile, FileMode.Open))
            {
                Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary)XamlReader.Load(reader));
            }
        }

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

        #region Command Functions

        /// <summary>
        /// Opens the user guide.
        /// </summary>
        /// <param name="o">The o.</param>
        private void OpenUserGuide(object o)
        {
            
        }

        /// <summary>
        /// Opens the about program window.
        /// </summary>
        /// <param name="o">The o.</param>
        private void OpenAboutProgram(object o)
        {
            
        }

        /// <summary>
        /// Opens the about developers window.
        /// </summary>
        /// <param name="o">The o.</param>
        private void OpenAboutDevelopers(object o)
        {
            
        }

        /// <summary>
        /// Command which handles the click on a custom plugin menu item.
        /// </summary>
        /// <param name="customPlugin">The custom plugin.</param>
        private void CustomPluginCommand(ICustomPlugin customPlugin)
        {
            customPlugin.Window.Show();
        }

        #endregion

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

                //await _dataProvider.Repository(type).GenerateTableAsync();

                var listView = _entityListViews.FirstOrDefault(view => view.EntityType == type);
                if (listView != default(IEntityListView))
                {
                    tabItem.Content = listView.GetControl(_localizationProvider, Properties.Settings.Default.CurrentLanguage);
                }

                EntityTab.Items.Add(tabItem);
            }

            EntityTab.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the OnSelectionChanged event of the EntityTab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void EntityTab_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = EntityTab.SelectedItem as TabItem;

            if (selected == null) return;
            var listView = selected.Content as IEntityListView;

            if (listView == null) return;

            var items = await _dataProvider.Repository(listView.EntityType).GetAllAsync();
            listView.LoadData(items);
        }
    }
}
