#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.Logging
{
	/// <summary>
	/// Defines a interface for log strategies.
	/// </summary>
	public interface ILogStrategy
	{
		#region Events
		/// <summary>
		/// Occurs when a debug log is written.
		/// </summary>
		event EventHandler<LogWrittenEventArgs> DebugWritten;

		/// <summary>
		/// Occurs when a warning log is written.
		/// </summary>
		event EventHandler<LogWrittenEventArgs> WarningWritten;

		/// <summary>
		/// Occurs when an error log is written.
		/// </summary>
		event EventHandler<LogWrittenEventArgs> ErrorWritten;
		#endregion
	
		
		#region Methods
		/// <summary>
		/// Writes the debug log level message.
		/// </summary>
		/// <param name='message'>
		/// Message.
		/// </param>
		/// <param name='args'>
		/// Arguments.
		/// </param>
		void WriteDebug(string message, params object[] args);
		
		/// <summary>
		/// Writes the warning log level message.
		/// </summary>
		/// <param name='message'>
		/// Message.
		/// </param>
		/// <param name='args'>
		/// Arguments.
		/// </param>
		void WriteWarning(string message, params object[] args);
		
		/// <summary>
		/// Writes the error log level message.
		/// </summary>
		/// <param name='message'>
		/// Message.
		/// </param>
		/// <param name='args'>
		/// Arguments.
		/// </param>
		void WriteError(string message, params object[] args);
		#endregion
	}
}