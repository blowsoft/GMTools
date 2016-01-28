using GMTools.Dependencies.DataSet;
using SQLite;

namespace SineRequieDataPlugin.Entities
{
	/// <summary>
	/// Class for a stat modifier container.
	/// </summary>
	public class ModifierContainer : IndexedEntity
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
		/// Gets or sets the memory modifier.
		/// </summary>
		/// <value>
		/// The memory modifier.
		/// </value>
		public int MemoryModifier { get; set; }
	}
}
