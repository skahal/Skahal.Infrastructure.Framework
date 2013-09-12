#region Usings
using System;
using Skahal.Infrastructure.Framework.Commons;


#endregion

namespace Skahal.Infrastructure.Framework.Logging
{

	/// <summary>
	/// A base ILogStrategy implementation.
	/// </summary>
	public abstract class LogStrategyBase : ILogStrategy
	{
		#region Events
		/// <summary>
		/// Occurs when a debug log is written.
		/// </summary>
		public event EventHandler<LogWrittenEventArgs> DebugWritten;
		
		/// <summary>
		/// Occurs when a warning log is written.
		/// </summary>
		public event EventHandler<LogWrittenEventArgs> WarningWritten;
		
		/// <summary>
		/// Occurs when an error log is written.
		/// </summary>
		public event EventHandler<LogWrittenEventArgs> ErrorWritten;
		#endregion

		#region Methods
		/// <summary>
		/// Writes the debug log level message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public abstract void WriteDebug (string message, params object[] args);

		/// <summary>
		/// Writes the warning log level message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		/// <returns>The warning.</returns>
		public abstract void WriteWarning (string message, params object[] args);

		/// <summary>
		/// Writes the error log level message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		/// <returns>The error.</returns>
		public abstract void WriteError (string message, params object[] args);

		/// <summary>
		/// Raises the debug written event.
		/// </summary>
		/// <param name="e">The arguments.</param>
		protected virtual void OnDebugWritten(LogWrittenEventArgs e)
		{
			DebugWritten.Raise(this, e);
		}

		/// <summary>
		/// Raises the warning written event.
		/// </summary>
		/// <param name="e">The arguments.</param>
		protected virtual void OnWarningWritten(LogWrittenEventArgs e)
		{
			WarningWritten.Raise(this, e);
		}

		/// <summary>
		/// Raises the error written event.
		/// </summary>
		/// <param name="e">The arguments.</param>
		protected virtual void OnErrorWritten(LogWrittenEventArgs e)
		{
			ErrorWritten.Raise(this, e);
		}
		#endregion
	}
}