using System;
using NUnit.Framework;
using Rhino.Mocks;
using Skahal.Infrastructure.Framework.Domain;

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
		public void Equals_DiffKeys_Fals ()
		{
			var target1 = MockRepository.GenerateMock<EntityBase> (1L);
			var target2 = MockRepository.GenerateMock<EntityBase> (2L);

			Assert.IsFalse (target1 == target2);
		}
	}
}

