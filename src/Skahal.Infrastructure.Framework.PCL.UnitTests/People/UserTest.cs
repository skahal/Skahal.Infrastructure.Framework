using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.PCL.People;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests.People
{
	[TestFixture()]
	public class UserTest
	{
		[Test()]
		public void HasPreference_NoPreferences_False ()
		{
			var target = new User ();
			Assert.IsFalse(target.HasPreference ("TEST"));
		}
	}
}

