using System;
using System.Windows.Controls;
using GMTools.Dependencies.Localization;

namespace GMTools.Dependencies.Entity
{
    /// <summary>
    /// Interface for a base entity view which all child needs to implement.
    /// </summary>
    public interface IEntityBaseView
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        Type EntityType { get; }

        #endregion

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <param name="localizationProvider">The localization provider.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        UserControl GetControl(ILocalizationProvider localizationProvider, string language);
    }
}
