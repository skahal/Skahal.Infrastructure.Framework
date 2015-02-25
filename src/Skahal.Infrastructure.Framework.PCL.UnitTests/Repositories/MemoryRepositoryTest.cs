using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.PCL.Repositories;
using TestSharp;
using System.Linq;
using Skahal.Infrastructure.Framework.PCL.People;
using HelperSharp.PCL;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests.Repositories
{
	[TestFixture()]
	public class MemoryRepositoryTest
	{
		#region Fields
		private MemoryUnitOfWork m_unitOfWork;
		private MemoryRepository<User> m_target;
		#endregion

		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			m_unitOfWork = new MemoryUnitOfWork ();
			m_target = new MemoryRepository<User> (m_unitOfWork, (u) => { return Guid.NewGuid().ToString(); });
		}
		#endregion

		#region Tests
		[Test()]
		public void FindAll_Filter_EntitiesFiltered ()
		{
			m_target.Add(new User() {} );

			var user = new User ();
			m_target.Add(user);
			m_target.Add(new User() {} );
			m_target.Add(new User() {} );
			m_unitOfWork.Commit ();

			var actual = m_target.FindAll (f => f.Key == user.Key).ToList();
			Assert.AreEqual (1, actual.Count);
			Assert.AreEqual (user.Key, actual[0].Key);
		}  

        [Test()]
        public void FindAllAscending_NullOrder_ArgumentNullException()
        {
            ExceptionAssert.IsThrowing(new ArgumentNullException("orderBy"), () =>
            {
                m_target.FindAllAscending<int>(0, 1, (o) => o.Name == null, null);
            });
        }

        [Test()]
        public void FindAllAscending_FilterAndOrder_EntitiesFilteredAndOrdered()
        {
            m_target.Add(new User() { Name = "B" });
            m_target.Add(new User() { Name = "C" });
            m_target.Add(new User() { Name = "A" });
            m_unitOfWork.Commit();

            var actual = m_target.FindAllAscending(0, 3, (f) => true, (o) => o.Name).ToList();
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual("A", actual[0].Name);
            Assert.AreEqual("B", actual[1].Name);
            Assert.AreEqual("C", actual[2].Name);

            actual = m_target.FindAllAscending(1, 3, (f) => true, (o) => o.Name).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("B", actual[0].Name);
            Assert.AreEqual("C", actual[1].Name);

            actual = m_target.FindAllAscending(0, 2, (f) => true, (o) => o.Name).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("A", actual[0].Name);
            Assert.AreEqual("B", actual[1].Name);
        }

        [Test()]
        public void FindAllDescending_NullOrder_ArgumentNullException()
        {
            ExceptionAssert.IsThrowing(new ArgumentNullException("orderBy"), () =>
            {
                m_target.FindAllDescending<int>(0, 1, (o) => o.Name == null, null);
            });
        }

        [Test()]
        public void FindAllDescending_FilterAndOrder_EntitiesFilteredAndOrdered()
        {
            m_target.Add(new User() { Name = "B" });
            m_target.Add(new User() { Name = "C" });
            m_target.Add(new User() { Name = "A" });
            m_unitOfWork.Commit();

            var actual = m_target.FindAllDescending(0, 3, (f) => true, (o) => o.Name).ToList();
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual("C", actual[0].Name);
            Assert.AreEqual("B", actual[1].Name);
            Assert.AreEqual("A", actual[2].Name);

            actual = m_target.FindAllDescending(1, 3, (f) => true, (o) => o.Name).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("B", actual[0].Name);
            Assert.AreEqual("A", actual[1].Name);

            actual = m_target.FindAllDescending(0, 2, (f) => true, (o) => o.Name).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("C", actual[0].Name);
            Assert.AreEqual("B", actual[1].Name);
        }

		[Test()]
		public void CountAll_Filter_EntitiesFiltered ()
		{
			m_target.Add(new User() { } );
			m_target.Add(new User() { } );
			m_target.Add(new User() { } );
			m_target.Add(new User() { } );
			m_unitOfWork.Commit();

			var actual = m_target.CountAll (f => true);
			Assert.AreEqual (4, actual);
		}

		[Test()]
		public void Add_NullEntity_ArgumentNullException ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("item"), () => {
				m_target.Add (null);
			});
		}

		[Test()]
		public void Add_EntityAlreadyAdded_Exception()
		{
			var user = new User ("1");
			m_target.Add(user);
			m_target.Add(user);

			ExceptionAssert.IsThrowing (new InvalidOperationException ("There is another entity with id '1'."), () => {
				m_unitOfWork.Commit ();
			});
	
			var actual = m_target.FindAll(f => true).ToList();

			Assert.AreEqual (1, actual.Count);
			Assert.AreEqual ("1", actual[0].Key);
		}

		[Test()]
		public void Add_Entity_Added ()
		{
			m_target.Add(new User());
			m_unitOfWork.Commit ();

			var actual = m_target.FindAll(f => true).ToList();

			Assert.AreEqual (1, actual.Count);
			Assert.IsFalse (String.IsNullOrWhiteSpace((string)actual[0].Key));
		}

        [Test()]
        public void Add_EntityWithIntId_AddedWithNewId()
        {            
            var target = new MemoryRepository<EntityWithIntIdStub>((e) => 1);
            target.SetUnitOfWork(m_unitOfWork);
            target.Add(new EntityWithIntIdStub());
            m_unitOfWork.Commit();

            var actual = target.FindAll(f => true).ToList();

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(1, actual[0].Id);
        }

		[Test()]
		public void Delete_NullEntity_ArgumentNullException ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("item"), () => {
				m_target.Remove(null);
			});
		}

		[Test()]
		public void Delete_EntityWithIdDoesNotExists_ArgumentNullException ()
		{
			var user = new User() { };
			m_target.Remove(user);

			ExceptionAssert.IsThrowing (
				new InvalidOperationException ("There is no entity with id '{0}'.".With(user.Key)), 
				() => { 
				m_unitOfWork.Commit();
			});
		}

		[Test()]
		public void Delete_Entity_EntityDeleted ()
		{
			var user = new User () { };
			m_target.Add (user);
			m_unitOfWork.Commit();

			m_target.Remove (user);
			m_unitOfWork.Commit();

			var actual = m_target.FindAll(f => true).ToList();
			Assert.AreEqual (0, actual.Count);
		}

		[Test()]
		public void Modify_EntityWithIdDoesNotExist_Added ()
		{
			var user = new User();
			Assert.IsNull(user.Key);

			m_target[user.Key] = user;

			m_unitOfWork.Commit();

			Assert.IsNotNull(user.Key);

			var actual = m_target.FindAll(f => true).ToList();
			Assert.AreEqual (1, actual.Count);
			Assert.AreEqual (user.Key, actual[0].Key);
		}

		[Test()]
		public void Modify_Entity_EntityModified ()
		{
			var user = new User ();
			m_target.Add (user);
			user = new User ();
			m_target.Add (user);
			m_unitOfWork.Commit();

			var modifiedUser = new User(user.Key) { Name = "new name" };
			m_target[user.Key] = modifiedUser;

			m_unitOfWork.Commit();

			var actual = m_target.FindAll (f => f == user).FirstOrDefault ();
			Assert.AreEqual (user.Key, actual.Key);
			Assert.AreEqual ("new name", actual.Name);
		}
		#endregion
	}
}

