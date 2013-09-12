using System;
using NUnit.Framework;
using TestSharp;
using Skahal.Infrastructure.Framework.Logging;
using Rhino.Mocks;

namespace Skahal.Infrastructure.Framework.UnitTests
{
	[TestFixture()]
	public class FiltrableLogStrategyTest
	{
		[Test()]
		public void Constructor_NullUnderlying_Exception ()
		{
			ExceptionAssert.IsThrowing(new ArgumentNullException("underlyingLogStrategy"), () => {
				new FiltrableLogStrategy(null);
			});
		}

		[Test()]
		public void Constructor_UnderlyingNoFilter_AllLogs ()
		{
			var underlying = MockRepository.GenerateMock<ILogStrategy>();
			var target = new FiltrableLogStrategy(underlying);
		
			underlying.Expect(u => u.WriteDebug("a", 1));
			underlying.Expect(u => u.WriteWarning("b", 2));
			underlying.Expect(u => u.WriteError("c", 3));

			target.WriteDebug("a", 1);
			target.WriteWarning("b", 2);
			target.WriteError("c", 3);

			underlying.VerifyAllExpectations();
		}

		
		[Test()]
		public void Constructor_UnderlyingFilterApplied_FilteredLogs ()
		{
			var underlying = MockRepository.GenerateMock<ILogStrategy>();
			var target = new FiltrableLogStrategy(underlying);

			underlying.Expect(u => u.WriteDebug("d", 1));
			underlying.Expect(u => u.WriteDebug("d", 2));

			underlying.Expect(u => u.WriteWarning("w", 1));
			underlying.Expect(u => u.WriteWarning("w", 2));

			underlying.Expect(u => u.WriteError("e", 1));
			underlying.Expect(u => u.WriteError("e", 2));

			target.Filter = (l) => l.LogLevel == LogLevel.Debug && l.Message.Length == 1;
			target.WriteDebug("d", 1);
			target.WriteDebug("d", 2);
			target.WriteDebug("d3", 3);
			target.WriteWarning("d", 4);
			target.WriteError("d", 5);

			target.Filter = (l) => l.LogLevel == LogLevel.Warning && l.Message.Length == 1;
			target.WriteWarning("w", 1);
			target.WriteWarning("w", 2);
			target.WriteWarning("w3", 3);
			target.WriteDebug("w", 4);
			target.WriteError("w", 5);

			target.Filter = (l) => l.LogLevel == LogLevel.Error && l.Message.Length == 1;
			target.WriteError("e", 1);
			target.WriteError("e", 2);
			target.WriteError("e3", 3);
			target.WriteDebug("e", 4);
			target.WriteWarning("e", 5);
			
			underlying.VerifyAllExpectations();
		}
	}
}

