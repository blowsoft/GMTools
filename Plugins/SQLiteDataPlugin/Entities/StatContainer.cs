using GMTools.Dependencies.Attributes;
using GMTools.Dependencies.DataSet;
using SQLite;

namespace SineRequieDataPlugin.Entities
{
	/// <summary>
	/// Container for the stats involved during checks.
	/// </summary>
	public class StatContainer : IndexedEntity
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
		/// Gets or sets the memory.
		/// </summary>
		/// <value>
		/// The memory.
		/// </value>
		[Category("Hearts")]
		public int Memory { get; set; }
	}
}
