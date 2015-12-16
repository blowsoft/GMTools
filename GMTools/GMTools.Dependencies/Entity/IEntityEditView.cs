using System;
using System.Windows.Controls;

namespace GMTools.Dependencies.Entity
{
    /// <summary>
    /// Interface for a view providing a UserControl for edit an entity to the data-set.
    /// </summary>
    public interface IEntityEditView
    {
        #region Properties

        /// <summary>
        /// Gets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        Type EntityType { get; }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <value>
        /// The control.
        /// </value>
        UserControl Control { get; }

        #endregion
    }
}
