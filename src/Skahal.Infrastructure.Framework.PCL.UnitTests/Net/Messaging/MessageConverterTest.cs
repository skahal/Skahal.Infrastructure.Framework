using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.PCL.Net.Messaging;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests
{
	[TestFixture()]
	public class MessageConverterTest
	{
		[Test()]
		public void ToString_NameValue_StringValue ()
		{
			var actual = MessageConverter.ToString("1", "2");
			Assert.AreEqual("1__MSG__2", actual);
		}

		[Test()]
		public void ToMessage_NullMessageAsString_Null ()
		{
			var actual = MessageConverter.ToMessage(null);
			Assert.IsNull(actual);
		}

		[Test()]
		public void ToMessage_EmptyMessageAsString_EmptyMessage()
		{
			var actual = MessageConverter.ToMessage("");
			Assert.IsTrue(String.IsNullOrWhiteSpace(actual.Name));
			Assert.IsNull(actual.Value);
		}

		[Test()]
		public void ToMessage_MessageAsStringWithoutSeparator_MessageWithoutValue()
		{
			var actual = MessageConverter.ToMessage("1");
			Assert.AreEqual("1", actual.Name);
			Assert.IsNull(actual.Value);
		}

		[Test()]
		public void ToMessage_MessageAsStringOk_MessageOk()
		{
			var actual = MessageConverter.ToMessage("1__MSG__2");
			Assert.AreEqual("1", actual.Name);
			Assert.AreEqual("2", actual.Value);
		}
	}
}

