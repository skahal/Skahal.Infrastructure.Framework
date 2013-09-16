using System;
using Skahal.Infrastructure.Framework.Domain;

namespace Skahal.Infrastructure.Framework.Globalization
{
	/// <summary>
	/// Globalization label.
	/// </summary>
	public class GlobalizationLabel : EntityBase, IAggregateRoot
	{
		#region Properties
		/// <summary>
		/// Gets or sets the english text.
		/// </summary>
		/// <value>The english text.</value>
		public string EnglishText { get; set; }

		/// <summary>
		/// Gets or sets the culture text.
		/// </summary>
		/// <value>The culture text.</value>
		public string CultureText { get; set; }

		/// <summary>
		/// Gets or sets the culture code.
		/// <remarks>
		/// ISO format: en-US, pt-BR, etc.
		/// </remarks>
		/// </summary>
		/// <value>The culture code.</value>
		public string CultureName { get; set; }
		#endregion
	}
}