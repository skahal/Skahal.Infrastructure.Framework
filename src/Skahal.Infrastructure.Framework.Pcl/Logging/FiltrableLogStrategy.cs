using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Commons;

namespace Skahal.Infrastructure.Framework.Logging
{
	/// <summary>
	/// A filtrable log strategy used for filter an underlying log strategy.
	/// </summary>
	internal class FiltrableLogStrategy : LogStrategyBase
	{
		#region Fields
		private ILogStrategy m_underlyingLogStrategy;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Logging.FiltrableLogStrategy"/> class.
		/// </summary>
		/// <param name="underlyingLogStrategy">Underlying log strategy.</param>
		public FiltrableLogStrategy(ILogStrategy underlyingLogStrategy)
		{
			if(underlyingLogStrategy == null)
			{
				throw new ArgumentNullException("underlyingLogStrategy");
			}

			m_underlyingLogStrategy = underlyingLogStrategy;
			m_underlyingLogStrategy.DebugWritten += delegate(object sender, LogWrittenEventArgs e) {
				OnDebugWritten(e);
			};

			m_underlyingLogStrategy.WarningWritten += delegate(object sender, LogWrittenEventArgs e) {
				OnWarningWritten(e);
			};

			m_underlyingLogStrategy.ErrorWritten += delegate(object sender, LogWrittenEventArgs e) {
				OnErrorWritten(e);
			};

			Filter = (l) => true;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the filter for log messages.
		/// </summary>
		/// <value>The filter.</value>
		public Func<LogMessage, bool> Filter { get; set; }
		#endregion

		#region ILogStrategy implementation
		/// <summary>
		/// Writes the debug log level message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public override void WriteDebug (string message, params object[] args)
		{
			if(IsFiltered(LogLevel.Debug, message, args))
			{
				m_underlyingLogStrategy.WriteDebug(message, args);
			}
		}

		/// <summary>
		/// Writes the warning log level message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public override void WriteWarning (string message, params object[] args)
		{
			if(IsFiltered(LogLevel.Warning, message, args))
			{
				m_underlyingLogStrategy.WriteWarning(message, args);
			}
		}

		/// <summary>
		/// Writes the error log level message.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="args">Arguments.</param>
		public override void WriteError (string message, params object[] args)
		{
			if(IsFiltered(LogLevel.Error, message, args))
			{
				m_underlyingLogStrategy.WriteError(message, args);
			}
		}

		private bool IsFiltered(LogLevel logLevel, string message, params object[] args)
		{
			return Filter(new LogMessage(logLevel, message, args));
		}
		#endregion
		
		
	}
}