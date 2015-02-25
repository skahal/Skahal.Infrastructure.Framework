using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.PCL.UnitTests.Logging.Stubs;
using Skahal.Infrastructure.Framework.PCL.Logging;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests.Logging
{
	[TestFixture()]
	public class LogStrategyBaseTest
	{
		[Test()]
		public void OnDebugWritten_ListenerAttached_EventRaised ()
		{
			var target = new LogStrategyStub ();

			bool eventRaised = false;
			target.DebugWritten += delegate(object sender, LogWrittenEventArgs e) {
				eventRaised = true;
				Assert.AreEqual(e.Message, "DEBUG:1");
			};

			target.WriteDebug ("DEBUG:{0}", 1);
			Assert.IsTrue (eventRaised);
		}

		[Test()]
		public void OnWarningWritten_ListenerAttached_EventRaised ()
		{
			var target = new LogStrategyStub ();

			bool eventRaised = false;
			target.WarningWritten += delegate(object sender, LogWrittenEventArgs e) {
				eventRaised = true;
				Assert.AreEqual(e.Message, "WARNING:1");
			};

			target.WriteWarning ("WARNING:{0}", 1);
			Assert.IsTrue (eventRaised);
		}

		[Test()]
		public void OnErroWritten_ListenerAttached_EventRaised ()
		{
			var target = new LogStrategyStub ();

			bool eventRaised = false;
			target.ErrorWritten += delegate(object sender, LogWrittenEventArgs e) {
				eventRaised = true;
				Assert.AreEqual(e.Message, "ERROR:1");
			};

			target.WriteError ("ERROR:{0}", 1);
			Assert.IsTrue (eventRaised);
		}
	}
}

