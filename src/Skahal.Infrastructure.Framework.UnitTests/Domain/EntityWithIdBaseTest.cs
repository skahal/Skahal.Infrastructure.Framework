using System;
using NUnit.Framework;

namespace Skahal.Infrastructure.Framework.UnitTests.Domain
{
    [TestFixture]
    public class EntityWithIdBaseTest
    {
        [Test()]
        public void EqualsOperator_NullEqualsNull_True()
        {
            EntityWithIdLongStub one = null;

            Assert.IsTrue(one == null);
        }

        [Test()]
        public void Equals_DiffIds_False()
        {
            var target1 = new EntityWithIdLongStub() { Id = 1 };
            var target2 = new EntityWithIdLongStub() { Id = 2 };
            Assert.IsFalse(target1 == target2);

            var target3 = new EntityWithIdStringStub() { Id = "1" };
            var target4 = new EntityWithIdStringStub() { Id = "2" };
            Assert.IsFalse(target3 == target4);
        }

        [Test()]
        public void Equals_DefaultIds_False()
        {
            var target1 = new EntityWithIdLongStub();
            var target2 = new EntityWithIdLongStub();
            Assert.IsFalse(target1 == target2);

            var target3 = new EntityWithIdStringStub();
            var target4 = new EntityWithIdStringStub();
            Assert.IsFalse(target3 == target4);
        }
    }
}