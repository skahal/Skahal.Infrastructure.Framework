//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2011 Skahal Studios
using System;

namespace Skahal.Infrastructure.Framework.PCL.IO
{
	/// <summary>
	/// Ofx transaction.
	/// </summary>
	public class OfxTransaction : IOfxTransaction
	{
		#region IOfxTransaction implementation
		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public DateTime Date { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public float Value { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }
		#endregion
	}
}

