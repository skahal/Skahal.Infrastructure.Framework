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
			EntityBase<int> one = null;

			Assert.IsTrue (one == null);
		}

		[Test()]
		public void Equals_DiffKeys_Fals ()
		{
			var target1 = MockRepository.GenerateMock<EntityBase<long>> (1L);
			var target2 = MockRepository.GenerateMock<EntityBase<long>> (2L);

			Assert.IsFalse (target1 == target2);
		}
	}
}

