using GMTools.Dependencies.DataSet;
using SQLite;

namespace SineRequieDataPlugin.Entities
{
    /// <summary>
    /// Class representing a mortus type.
    /// </summary>
    public class MortusType : IndexedEntity
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
