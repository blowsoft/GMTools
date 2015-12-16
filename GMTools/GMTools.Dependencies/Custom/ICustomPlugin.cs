using System.Windows;

namespace GMTools.Dependencies.Custom
{
    /// <summary>
    /// Interface for an external plugin. 
    /// </summary>
    public interface ICustomPlugin
    {
        #region Properties

        /// <summary>
        /// Gets the window.
        /// </summary>
        /// <value>
        /// The window.
        /// </value>
        Window Window { get; }

        #endregion
    }
}
