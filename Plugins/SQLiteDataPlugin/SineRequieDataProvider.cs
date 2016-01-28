using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using GMTools.Dependencies.DataSet;
using SineRequieDataPlugin.Entities;

namespace SineRequieDataPlugin
{
    /// <summary>
    /// Class implementing a data-set based on SQLite.
    /// </summary>
    [Export(typeof(IDataProvider))]
    public class SineRequieDataProvider : IDataProvider
    {
        #region Public Properties

        /// <summary>
        /// Gets the entities defined in this data-set.
        /// </summary>
        /// <value>
        /// The entities defined in this data-set.
        /// </value>
        public List<Type> Entities 
        {
            get
            {
                return new List<Type>
                {
                    typeof(MortusType),
                    typeof(Mortus)
                };
            } 
        }

        #endregion

        #region Private Properties
        
        private readonly IDictionary<Type, dynamic> _repositories = new Dictionary<Type, dynamic>();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SineRequieDataProvider"/> class.
        /// </summary>
        public SineRequieDataProvider()
        {
            PrepareTypes();
        }

        #endregion

        /// <summary>
        /// Instantiates the repositories ensuring a single instance of each one per-type.
        /// </summary>
        private void PrepareTypes()
        {
            _repositories.Add(typeof(Mortus), new SQLiteRepository<Mortus>());
            _repositories.Add(typeof(MortusType), new SQLiteRepository<MortusType>());
			_repositories.Add(typeof(ModifierContainer), new SQLiteRepository<ModifierContainer>());
			_repositories.Add(typeof(StatContainer), new SQLiteRepository<StatContainer>());
        }

        /// <summary>
        /// Gets the repository for the specified entity type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public dynamic Repository(Type type)
        {
            return _repositories[type];
        }
    }
}
