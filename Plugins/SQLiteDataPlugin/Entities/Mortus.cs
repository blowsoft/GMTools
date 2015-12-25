using GMTools.Dependencies.Attributes;
using GMTools.Dependencies.DataSet;
using SQLite;

namespace SineRequieDataPlugin.Entities
{
    /// <summary>
    /// Class representing a single mortus.
    /// </summary>
    public class Mortus : IndexedEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [PrimaryKey, AutoIncrement]
        public new int Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [Indexed, NavigationProperty(typeof(MortusType))]
        public int MortusTypeId { get; set; }
    }
}
