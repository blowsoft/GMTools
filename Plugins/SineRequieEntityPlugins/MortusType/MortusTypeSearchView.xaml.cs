using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using GMTools.Dependencies.Entity;

namespace SineRequieEntityPlugins.MortusType
{
    /// <summary>
    /// Interaction logic for MortusSearchView.xaml
    /// </summary>
    [Export(typeof(IEntitySearchView))]
    public partial class MortusTypeSearchView : IEntitySearchView
    {
        #region Public Properties

        /// <summary>
        /// Gets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        public Type EntityType
        {
            get { return typeof (SineRequieDataPlugin.Entities.MortusType); }
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <value>
        /// The control.
        /// </value>
        public UserControl Control
        {
            get { return this; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MortusTypeSearchView"/> class.
        /// </summary>
        public MortusTypeSearchView()
        {
            InitializeComponent();
        }

        #endregion
    }
}
