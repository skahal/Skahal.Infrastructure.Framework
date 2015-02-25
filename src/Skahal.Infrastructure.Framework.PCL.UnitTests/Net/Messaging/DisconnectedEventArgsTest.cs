using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.PCL.Net.Messaging;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests
{
	[TestFixture()]
	public class DisconnectedEventArgsTest
	{
		[Test()]
		public void Constructor_Reason_PropertyReason ()
		{
			var target = new DisconnectedEventArgs(DisconnectionReason.ConnectionLost);
			Assert.AreEqual(DisconnectionReason.ConnectionLost, target.Reason);

			target = new DisconnectedEventArgs(DisconnectionReason.LocalQuit);
			Assert.AreEqual(DisconnectionReason.LocalQuit, target.Reason);

			target = new DisconnectedEventArgs(DisconnectionReason.RemoteQuit);
			Assert.AreEqual(DisconnectionReason.RemoteQuit, target.Reason);
		}
	}
}

