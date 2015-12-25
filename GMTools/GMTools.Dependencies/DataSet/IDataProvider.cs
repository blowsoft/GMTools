using System;
using System.Collections.Generic;

namespace GMTools.Dependencies.DataSet
{
    /// <summary>
    /// Interface for a piece of software which interconnects the main application with a provider of entities of any kind.
    /// </summary>
    public interface IDataProvider
    {
        #region Properties

        /// <summary>
        /// Gets the entities defined in this data-set.
        /// </summary>
        /// <value>
        /// The entities defined in this data-set.
        /// </value>
        List<Type> Entities { get; }

        #endregion

        /// <summary>
        /// Gets the repository for the specified entity type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        dynamic Repository(Type type);
    }
}
