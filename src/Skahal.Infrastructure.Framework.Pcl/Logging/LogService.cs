#region Usings
using System;
using Skahal.Infrastructure.Framework.Commons;
#endregion

namespace Skahal.Infrastructure.Framework.Logging
{
	#region Enums
	/// <summary>
	/// Log level.
	/// </summary>
	public enum LogLevel
	{
		/// <summary>
		/// The debug log level.
		/// </summary>
		Debug,
	
		/// <summary>
		/// The warning log level.
		/// </summary>
		Warning,

		/// <summary>
		/// The error log level.
		/// </summary>
		Error
	}
	#endregion

	/// <summary>
	/// A central point to organize logs.
	/// </summary>
	public static class LogService
	{
		#region Events
		/// <summary>
		/// Occurs when a debug log is written.
		/// </summary>
		public static event EventHandler<LogWrittenEventArgs> DebugWritten;

		/// <summary>
		/// Occurs when a warning log is written.
		/// </summary>
		public static event EventHandler<LogWrittenEventArgs> WarningWritten;

		/// <summary>
		/// Occurs when a error log is written.
		/// </summary>
		public static event EventHandler<LogWrittenEventArgs> ErrorWritten;
		#endregion
		
		#region Fields
		/// <summary>
		/// The log strategy.
		/// </summary>
		private static ILogStrategy s_logStrategy = new BufferLogStrategy();

		/// <summary>
		/// The log strategy used to applied filters.
		/// </summary>
		private static FiltrableLogStrategy s_filtrableLogStrategy;
		#endregion

		#region Methods
		/// <summary>
		/// Initialize the service.
		/// </summary>
		/// <param name="logStrategy">Log strategy.</param>
		public static void Initialize (ILogStrategy logStrategy)
		{
			var buffer = s_logStrategy as BufferLogStrategy;
			s_logStrategy = logStrategy;
			
			s_logStrategy.DebugWritten += delegate(object sender, LogWrittenEventArgs e) {
				DebugWritten.Raise(typeof(LogService), e);
			};
			
			s_logStrategy.WarningWritten += delegate(object sender, LogWrittenEventArgs e) {
				WarningWritten.Raise(typeof(LogService), e);
			};
			
			s_logStrategy.ErrorWritten += delegate(object sender, LogWrittenEventArgs e) {
				ErrorWritten.Raise(typeof(LogService), e);
			};

			if(buffer != null)
			{
				buffer.Flush(s_logStrategy);
			}
		}

		/// <summary>
		/// Applies the filter.
		/// </summary>
		/// <param name="filter">Filter.</param>
		public static void ApplyFilter(Func<LogMessage, bool> filter)
		{
			if(s_filtrableLogStrategy == null)
			{
				s_filtrableLogStrategy = new FiltrableLogStrategy(s_logStrategy);
				s_logStrategy = s_filtrableLogStrategy;
			}

			s_filtrableLogStrategy.Filter = filter;
		}

		/// <summary>
		/// Write a debug log level.
		/// </summary>
		/// <param name='message'>
		/// Message.
		/// </param>
		/// <param name='args'>
		/// Arguments.
		/// </param>
		public static void Debug (string message, params object[] args)
		{
#if DEBUG
			ValidateLogStrategy();
#endif
			s_logStrategy.WriteDebug(message, args);
		}
		
		/// <summary>
		/// Write a warning log level.
		/// </summary>
		/// <param name='message'>
		/// Message.
		/// </param>
		/// <param name='args'>
		/// Arguments.
		/// </param>
		public static void Warning (string message, params object[] args)
		{
#if DEBUG
			ValidateLogStrategy();
#endif
			s_logStrategy.WriteWarning(message, args);
		}
		
		/// <summary>
		/// Write an error log level.
		/// </summary>
		/// <param name='message'>
		/// Message.
		/// </param>
		/// <param name='args'>
		/// Arguments.
		/// </param>
		public static void Error (string message, params object[] args)
		{
#if DEBUG
			ValidateLogStrategy();
#endif
			s_logStrategy.WriteError(message, args);
		}

#if DEBUG
		private static void ValidateLogStrategy()
		{
			if (s_logStrategy == null) {
				throw new InvalidOperationException ("LogService: are you trying to use LogService Debug, Warning and Error methods before call the Initialize method?");
			}
		}
#endif
		#endregion
	}
}