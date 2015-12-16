using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
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

        private CompositionContainer _mefContainer;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DirectoryChecker.CheckIfExistsAndCreate(MefConfigurator.GamesBasePluginDirectory + Properties.Settings.Default.CurrentGame);
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
    }
}
