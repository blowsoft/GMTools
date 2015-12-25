using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using GMTools.Dependencies.Localization;

namespace GMTools.Utilities.Localization
{
    /// <summary>
    /// Default localization provider for the system.
    /// </summary>
    public class DefaultLocalizationProvider : ILocalizationProvider
    {
        #region Private Properties

        private readonly IDictionary<string, LocalizedEntryCollection> _localizedCollections = new ConcurrentDictionary<string, LocalizedEntryCollection>(); 

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultLocalizationProvider"/> class.
        /// </summary>
        public DefaultLocalizationProvider(string game)
        {
            var files = Directory.EnumerateFiles("Games\\" + game + "\\Languages\\", "*.xml");
            var serializer = new XmlSerializer(typeof(LocalizedEntryCollection));

            foreach (var fileName in files)
            {
                using (var reader = new StreamReader(fileName))
                {
                    _localizedCollections.Add(Path.GetFileNameWithoutExtension(fileName),
                        (LocalizedEntryCollection) serializer.Deserialize(reader));
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets the localized string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public string GetLocalizedString(string key, string language)
        {
            if (!_localizedCollections.ContainsKey(language)) return "TRANSLATION NOT FOUND: " + language;

            if(_localizedCollections[language].LocalizedEntries.Any(entry => entry.Key.Equals(key)))
            {
                return _localizedCollections[language].LocalizedEntries.First(entry => entry.Key.Equals(key)).Value;
            }


            return "ENTRY NOT FOUND: " + key;
        }
    }
}
