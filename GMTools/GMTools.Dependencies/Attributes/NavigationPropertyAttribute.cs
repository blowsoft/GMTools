using System;

namespace GMTools.Dependencies.Attributes
{
    /// <summary>
    /// Attribute class for the autocreation of a navigation property inside the data-set.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NavigationPropertyAttribute : Attribute
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        /// <value>
        /// The type of the property.
        /// </value>
        public Type PropertyType { get; set; }

        /// <summary>
        /// Gets or sets the name of the key.
        /// </summary>
        /// <value>
        /// The name of the key.
        /// </value>
        public string KeyName { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationPropertyAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public NavigationPropertyAttribute(Type type)
        {
            KeyName = "Id";
            PropertyType = type;
        }

        #endregion
    }
}
