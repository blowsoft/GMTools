using System.IO;

namespace GMTools.Utilities.FileSystem
{
    /// <summary>
    /// Static class providing helper functions for directory management.
    /// </summary>
    public static class DirectoryChecker
    {
        /// <summary>
        /// Checks if the specified directory exists and create it if not present.
        /// </summary>
        /// <param name="directoryName">Name of the directory.</param>
        public static void CheckIfExistsAndCreate(string directoryName)
        {
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }
    }
}
