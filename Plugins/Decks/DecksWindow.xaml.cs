using System.ComponentModel.Composition;
using System.Windows;
using GMTools.Dependencies.Custom;

namespace Decks
{
    /// <summary>
    /// Interaction logic for DecksWindow.xaml
    /// </summary>
    [Export(typeof(ICustomPlugin))]
    public partial class DecksWindow : ICustomPlugin
    {
        #region Public Properties

        /// <summary>
        /// Gets the window.
        /// </summary>
        /// <value>
        /// The window.
        /// </value>
        public Window Window
        {
            get { return this; }
        }


        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DecksWindow"/> class.
        /// </summary>
        public DecksWindow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
