using System;

namespace GMTools.Dependencies.Attributes
{
	/// <summary>
	/// Attribute used to classify stats.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class CategoryAttribute : Attribute
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the category.
		/// </summary>
		/// <value>
		/// The category.
		/// </value>
		public string Category { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryAttribute"/> class.
		/// </summary>
		/// <param name="category">The category.</param>
		public CategoryAttribute(string category)
		{
			Category = category;
		}

		#endregion
	}
}
