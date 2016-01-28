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

		/// <summary>
		/// Gets or sets the modifier container identifier.
		/// </summary>
		/// <value>
		/// The modifier container identifier.
		/// </value>
		public int ModifierContainerId { get; set; }

		/// <summary>
		/// Gets or sets the modifier container.
		/// </summary>
		/// <value>
		/// The modifier container.
		/// </value>
		[Ignore]
		public ModifierContainer ModifierContainer 
		{ 
			get
			{
				var provider = new SineRequieDataProvider();
				return provider.Repository(typeof (ModifierContainer)).GetAsync(ModifierContainerId).Result;
			}
			set
			{
				ModifierContainerId = value.Id;
			}
		}
    }
}
