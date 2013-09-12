#region Usings
using System;
using System.Globalization;
using Skahal.Infrastructure.Framework.Commons;
#endregion

namespace Skahal.Infrastructure.Framework.Text.Spelling
{
	/// <summary>
	/// Spelling service.
	/// </summary>
    public static class SpellingService
    {
        #region Fields
        private static ISpellingProvider s_provider;
        #endregion

        #region Public Methods
		/// <summary>
		/// Initialize the service usigng the specified provider.
		/// </summary>
		/// <param name="provider">Provider.</param>
        public static void Initialize(ISpellingProvider provider)
        {
            s_provider = provider;
            provider.Initialize();
        }

		/// <summary>
		/// Initialize this instance.
		/// </summary>
        public static void Initialize()
        {
           // s_provider = new BingSpellingProvider();
        }

		/// <summary>
		/// Gets the correct text.
		/// </summary>
		/// <returns>The correct.</returns>
		/// <param name="text">Text.</param>
		/// <param name="culture">Culture.</param>
        public static string GetCorrect(string text, CultureInfo culture)
        {
			return s_provider.GetCorrect(text.Trim(), culture);
        }

		/// <summary>
		/// Gets the correct text.
		/// </summary>
		/// <returns>The correct.</returns>
		/// <param name="text">Text.</param>
        public static string GetCorrect(string text)
        {
            return GetCorrect(text, CultureInfo.CurrentUICulture);
        }

		/// <summary>
		/// Determines if is correct the specified text.
		/// </summary>
		/// <returns><c>true</c> if is correct the specified text culture; otherwise, <c>false</c>.</returns>
		/// <param name="text">Text.</param>
		/// <param name="culture">Culture.</param>
        public static bool IsCorrect(string text, CultureInfo culture)
        {
			var textTrimmed = text.Trim();
        	return s_provider.GetCorrect(textTrimmed, culture).Equals(textTrimmed, StringComparison.OrdinalIgnoreCase);
        }

		/// <summary>
		/// Determines if is correct the specified text.
		/// </summary>
		/// <returns><c>true</c> if is correct the specified text; otherwise, <c>false</c>.</returns>
		/// <param name="text">Text.</param>
        public static bool IsCorrect(string text)
        {
            return IsCorrect(text, CultureInfo.CurrentUICulture);
        }
        #endregion
    }
}