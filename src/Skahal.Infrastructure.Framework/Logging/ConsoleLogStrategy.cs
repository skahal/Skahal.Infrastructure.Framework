using System;
using Skahal.Infrastructure.Framework.Logging;

namespace Skahal.Infrastructure.Framework
{
	/// <summary>
	/// A log strategy that send the messages to default system console.
	/// </summary>
	public class ConsoleLogStrategy : LogStrategyBase
	{
		#region implemented abstract members of LogStrategyBase
		/// <summary>
		/// Writes the debug log level message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public override void WriteDebug (string message, params object[] args)
		{
			Console.ResetColor ();
			Console.WriteLine (message, args);
			OnDebugWritten (new LogWrittenEventArgs(message, args));
		}

		/// <summary>
		/// Writes the warning log level message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public override void WriteWarning (string message, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (message, args);
			Console.ResetColor ();
			OnWarningWritten (new LogWrittenEventArgs(message, args));
		}

		/// <summary>
		/// Writes the error log level message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public override void WriteError (string message, params object[] args)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine (message, args);
			Console.ResetColor ();
			OnErrorWritten (new LogWrittenEventArgs(message, args));
		}
		#endregion
	}
}