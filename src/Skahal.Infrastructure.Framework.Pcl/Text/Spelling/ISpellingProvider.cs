using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Skahal.Infrastructure.Framework.PCL.Text.Spelling
{
	/// <summary>
	/// Defines a spelling provider.
	/// </summary>
    public interface ISpellingProvider
    {
        #region Methods
		/// <summary>
		/// Initialize this instance.
		/// </summary>
        void Initialize();

		/// <summary>
		/// Gets the correct version of the text.
		/// </summary>
		/// <returns>The correct text..</returns>
		/// <param name="text">Text.</param>
		/// <param name="culture">Culture.</param>
        string GetCorrect(string text, CultureInfo culture);
        #endregion
    }
}
