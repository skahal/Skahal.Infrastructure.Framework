using System;

namespace Skahal.Infrastructure.Framework.Globalization
{
	/// <summary>
	/// Globalization extensions.
	/// </summary>
	public static class GlobalizationExtensions
	{
		#region Methods
		/// <summary>
		/// Translate the specified text to the currente language.
		/// </summary>
		/// <param name="text">Text.</param>
		/// <param name="args">Arguments.</param>
		public static string Translate (this string text, params object[] args)
		{
			var result = string.Format(text, args);

			return GlobalizationService.Translate(result);	
		}
		#endregion
	}
}

