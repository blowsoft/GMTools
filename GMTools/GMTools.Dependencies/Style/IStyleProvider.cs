using System.Windows;

namespace GMTools.Dependencies.Style
{
    /// <summary>
    /// Interface providing the user to change the style of all the application based on the game.
    /// </summary>
    public interface IStyleProvider
    {
        #region Properties

        /// <summary>
        /// Gets the style dictionary.
        /// </summary>
        /// <value>
        /// The style dictionary.
        /// </value>
        ResourceDictionary StyleDictionary { get; }

        #endregion
    }
}
