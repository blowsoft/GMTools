using System.Xml.Serialization;

namespace GMTools.Dependencies.Localization
{
    /// <summary>
    /// Class wrapping a collection of LocalizedEntry/s for serialization purposes.
    /// </summary>
    [XmlRoot("LocalizedEntries")]
    public class LocalizedEntryCollection
    {
        /// <summary>
        /// Gets or sets the localized entries.
        /// </summary>
        /// <value>
        /// The localized entries.
        /// </value>
        [XmlElement("LocalizedEntry")]
        public LocalizedEntry[] LocalizedEntries { get; set; }
    }
}
