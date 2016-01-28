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
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the mortus type identifier.
		/// </summary>
		/// <value>
		/// The mortus type identifier.
		/// </value>
        public int MortusTypeId { get; set; }

		/// <summary>
		/// Gets or sets the type of the mortus.
		/// </summary>
		/// <value>
		/// The type of the mortus.
		/// </value>
		[Ignore]
		public MortusType MortusType { get; set; }

		/// <summary>
		/// Gets or sets the stat container identifier.
		/// </summary>
		/// <value>
		/// The stat container identifier.
		/// </value>
		public int StatContainerId { get; set; }

		/// <summary>
		/// Gets or sets the stat container.
		/// </summary>
		/// <value>
		/// The stat container.
		/// </value>
		[Ignore]
		public StatContainer StatContainer { get; set; }
    }
}
