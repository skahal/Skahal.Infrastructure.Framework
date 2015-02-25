using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.PCL.Net.Messaging;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests
{
	[TestFixture()]
	public class MessageTest
	{
		[Test()]
		public void Constructor_NameValue_PropertiesSetted ()
		{
			var target = new Message();
			Assert.IsNull(target.Name);
			Assert.IsNull(target.Value);

			target = new Message("1", "2");
			Assert.AreEqual("1", target.Name);
			Assert.AreEqual("2", target.Value);
		}
	}
}

