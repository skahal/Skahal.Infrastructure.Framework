//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2011 Skahal Studios

#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.Domain
{
	/// <summary>
	/// Represents an excetion occurent on domain layer.
	/// </summary>
	public class DomainException : Exception
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Domain.DomainException"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		public DomainException (string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Domain.DomainException"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="innerException">Inner exception.</param>
		public DomainException(string message, Exception innerException) : base(message, innerException)
		{
		}
		#endregion
	}
}