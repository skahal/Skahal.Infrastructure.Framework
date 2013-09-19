using System;
using NUnit.Framework;
using Rhino.Mocks;
using Skahal.Infrastructure.Framework.Domain;
using Skahal.Infrastructure.Framework.People;

namespace Skahal.Infrastructure.Framework.UnitTests
{
	[TestFixture()]
	public class EntityBaseTest
	{
		[Test()]
		public void EqualsOperator_NullEqualsNull_True ()
		{
			EntityBase one = null;

			Assert.IsTrue (one == null);
		}

		[Test()]
		public void Equals_DiffKeys_False ()
		{
			var target1 = new User("1");
            var target2 = new User("2");

			Assert.IsFalse (target1 == target2);
		}
	}
}

