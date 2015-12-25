using System;
using System.ComponentModel.Composition;
using System.Windows;
using GMTools.Dependencies.Style;

namespace SineRequieStylePlugin
{
    /// <summary>
    /// Plugin implementation of a unique style based on Sine Requie manual graphics.
    /// </summary>
    [Export(typeof(IStyleProvider))]
    public class SineRequieStyle : IStyleProvider
    {
        /// <summary>
        /// Gets the style dictionary.
        /// </summary>
        /// <value>
        /// The style dictionary.
        /// </value>
        public ResourceDictionary StyleDictionary
        {
            get
            {
                return new ResourceDictionary
                {
                    Source = new Uri("/SineRequieStylePlugin;component/Resources/Style.xaml", UriKind.Relative)
                };
            }
        }
    }
}
