using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Logging;
using Rhino.Mocks;

namespace Skahal.Infrastructure.Framework.UnitTests.Logging
{
	[TestFixture()]
	public class BufferLogStrategyTest
	{
		[Test()]
		public void Flush_AnyWrite_AllFlushed ()
		{
			var target = new BufferLogStrategy ();
			bool bufferEventRaised = false;

			target.DebugWritten += delegate { bufferEventRaised = true; };
			target.WarningWritten += delegate { bufferEventRaised = true; };
			target.ErrorWritten += delegate { bufferEventRaised = true; };

			target.WriteDebug ("DEBUG", 1);
			Assert.IsFalse (bufferEventRaised, "WriteDebug should not raise event.");

			target.WriteWarning ("WARNING", 2);
			Assert.IsFalse (bufferEventRaised, "WriteWarning should not raise event.");

			target.WriteError ("ERROR", 3);
			Assert.IsFalse (bufferEventRaised, "WriteError should not raise event.");

			var notSoRealLogStrategy = MockRepository.GenerateMock<ILogStrategy> ();
			notSoRealLogStrategy.Expect (n => n.WriteDebug("DEBUG", 1));
			notSoRealLogStrategy.Expect (n => n.WriteWarning("WARNING", 2));
			notSoRealLogStrategy.Expect (n => n.WriteError("ERROR", 3));
		
			target.Flush (notSoRealLogStrategy);

			notSoRealLogStrategy.VerifyAllExpectations ();
		}
	}
}

