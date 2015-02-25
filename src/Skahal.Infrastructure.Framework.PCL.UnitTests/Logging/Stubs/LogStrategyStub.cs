using System;
using Skahal.Infrastructure.Framework.PCL.Logging;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests.Logging.Stubs
{
	public class LogStrategyStub : LogStrategyBase
	{
		#region implemented abstract members of LogStrategyBase

		public override void WriteDebug (string message, params object[] args)
		{
			OnDebugWritten (new LogWrittenEventArgs(String.Format(message, args)));
		}

		public override void WriteWarning (string message, params object[] args)
		{
			OnWarningWritten (new LogWrittenEventArgs(String.Format(message, args)));
		}

		public override void WriteError (string message, params object[] args)
		{
			OnErrorWritten (new LogWrittenEventArgs(String.Format(message, args)));
		}
		#endregion
	}
}