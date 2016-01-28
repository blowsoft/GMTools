using System.Collections.Generic;

namespace GMTools.Dependencies.Entity
{
    /// <summary>
    /// Interface for a UserControl which presents the entity.
    /// </summary>
    public interface IEntityListView : IEntityBaseView
    {
        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void LoadData(IEnumerable<object> entities);
    }
}
