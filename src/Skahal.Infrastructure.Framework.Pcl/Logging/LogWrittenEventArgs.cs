#region Usings
using System;
using System.Globalization;


#endregion

namespace Skahal.Infrastructure.Framework.Logging
{
	/// <summary>
	/// SH log written event arguments.
	/// </summary>
	public class LogWrittenEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Logging.LogWrittenEventArgs"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		public LogWrittenEventArgs (string message)
		{
			Message = message;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Logging.LogWrittenEventArgs"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public LogWrittenEventArgs (string message, params object[] args)
		{
			Message = String.Format(CultureInfo.InvariantCulture, message, args);
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; private set;}
		#endregion
	}
}