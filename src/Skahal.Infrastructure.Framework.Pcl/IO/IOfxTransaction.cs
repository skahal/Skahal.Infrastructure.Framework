//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2011 Skahal Studios
using System;

namespace Skahal.Infrastructure.Framework.PCL.IO
{
	/// <summary>
	/// Defines an interface for an OFX transaction.
	/// </summary>
	public interface IOfxTransaction
	{
		#region Properties
		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		float Value { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		string Description { get; set; }
		#endregion
	}
}

