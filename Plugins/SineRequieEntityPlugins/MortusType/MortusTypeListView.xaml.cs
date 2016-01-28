using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using GMTools.Dependencies.Entity;
using GMTools.Dependencies.Localization;

namespace SineRequieEntityPlugins.MortusType
{
    /// <summary>
    /// Interaction logic for MortusTypeListView.xaml
    /// </summary>
    [Export(typeof(IEntityListView))]
    public partial class MortusTypeListView : IEntityListView
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
        /// Gets or sets the mortus type identifier.
        /// </summary>
        /// <value>
        /// The mortus type identifier.
        /// </value>
        public string MortusTypeId { get; set; }

        /// <summary>
        /// Gets or sets the mortus type description.
        /// </summary>
        /// <value>
        /// The mortus type description.
        /// </value>
        public string MortusTypeDescription { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MortusTypeSearchView"/> class.
        /// </summary>
        public MortusTypeListView()
        {
            DataContext = this;
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <param name="localizationProvider">The localization provider.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public UserControl GetControl(ILocalizationProvider localizationProvider, string language)
        {
            MortusTypeId = localizationProvider.GetLocalizedString("MortusTypeId", language);
            MortusTypeDescription = localizationProvider.GetLocalizedString("MortusTypeDescription", language);

            return this;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void LoadData(IEnumerable<object> entities)
        {
            MortusTypeList.ItemsSource = entities;
        }
    }
}
