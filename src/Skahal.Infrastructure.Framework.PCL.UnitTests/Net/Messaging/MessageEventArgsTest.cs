using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.PCL.Net.Messaging;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests
{
	[TestFixture()]
	public class MessageEventArgsTest
	{
		[Test()]
		public void Constructor_Message_PropertyMessage ()
		{
			var msg = new Message();
			msg.Name = "1";
			msg.Value = "2";

			var target = new MessageEventArgs(msg);
			Assert.AreEqual("1", target.Message.Name);
			Assert.AreEqual("2", target.Message.Value);

			target = new MessageEventArgs("3", "4");
			Assert.AreEqual("3", target.Message.Name);
			Assert.AreEqual("4", target.Message.Value);
		}
	}
}

