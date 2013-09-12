using System;
using System.Collections.Generic;

namespace Skahal.Infrastructure.Framework.Logging
{
	/// <summary>
	/// A buffer log strategy used for keep the logs until a real log strategy be setted.
	/// </summary>
	internal class BufferLogStrategy : LogStrategyBase
	{
		#region Fields
		private List<LogMessage> m_debugBuffer = new List<LogMessage>();
		private List<LogMessage> m_warningBuffer = new List<LogMessage>();
		private List<LogMessage> m_errorBuffer = new List<LogMessage>();
		#endregion

		#region ILogStrategy implementation
		public override void WriteDebug (string message, params object[] args)
		{
			m_debugBuffer.Add(new LogMessage(message, args));
		}

		public override void WriteWarning (string message, params object[] args)
		{
			m_warningBuffer.Add(new LogMessage(message, args));
		}

		public override void WriteError (string message, params object[] args)
		{
			m_errorBuffer.Add(new LogMessage(message, args));
		}

		public void Flush (ILogStrategy realLogStrategy)
		{
			foreach(var debug in m_debugBuffer)
			{
				realLogStrategy.WriteDebug(debug.Message, debug.Arguments);
			}

			foreach(var warning in m_warningBuffer)
			{
				realLogStrategy.WriteWarning(warning.Message, warning.Arguments);
			}

			foreach(var error in m_errorBuffer)
			{
				realLogStrategy.WriteError(error.Message, error.Arguments);
			}
		}
		#endregion
	}
}