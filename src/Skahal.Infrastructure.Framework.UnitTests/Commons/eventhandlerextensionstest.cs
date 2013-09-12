using NUnit.Framework;
using System;
using Rhino.Mocks;
using Skahal.Infrastructure.Framework.Commons;
using TestSharp;

namespace Skahal.Infrastructure.Framework.UnitTests
{
	[TestFixture()]
	public class EventHandlerExtensionsTest
	{
		[Test()]
		public void Raise_NullHandler_NoHandlerCalled ()
		{
			Assert.IsFalse(EventHandlerExtensions.Raise(null, EventArgs.Empty));
		}

		[Test()]
		public void Raise_Handler_HandlerCalled ()
		{
			bool raised = false;
			
			var handler = new EventHandler (delegate {
				raised = true;
			});
			
			var actual = EventHandlerExtensions.Raise(handler, EventArgs.Empty);
			Assert.IsTrue(actual);
			Assert.IsTrue(raised);
		}	
	}
}