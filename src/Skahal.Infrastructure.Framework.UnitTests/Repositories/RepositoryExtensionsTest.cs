using System;
using System.Linq;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Repositories;
using Skahal.Infrastructure.Framework.People;

namespace Skahal.Infrastructure.Framework.UnitTests.Repositories
{
	[TestFixture()]
	public class RepositoryExtensionsTest
	{
		#region Fields
		private MemoryRepository<User> m_userRepository;
		private IUnitOfWork m_unitOfWork = new MemoryUnitOfWork();
		#endregion

		[SetUp]
		public void InitializeFixture()
		{
			m_userRepository = new MemoryRepository<User> (m_unitOfWork, (u) => { return Guid.NewGuid().ToString(); });
		}

        #region FindLast
        [Test()]
		public void FindLast_NoEntities_Null ()
		{
			Assert.IsNull (m_userRepository.FindLast());
		}

		[Test()]
		public void FindLast_OnlyOneEntity_TheOneEntity ()
		{
			var entity = new User() { Name = "1" };
			m_userRepository.Add (entity);
			m_unitOfWork.Commit();

			Assert.AreEqual ("1", m_userRepository.FindLast().Name);
		}

		[Test()]
		public void FindLast_ManyEntities_LastOne ()
		{
			var entity = new User () { Key = "1" };
			m_userRepository.Add (entity);

			entity = new User() { Key = "2" };
			m_userRepository.Add (entity);

			entity = new User() { Key = "3" };
			m_userRepository.Add (entity);

			m_unitOfWork.Commit();

			Assert.AreEqual ("3", m_userRepository.FindLast().Key);
		}
        #endregion

        #region FindFirst
        [Test()]
        public void FindFirst_NoMatch_Null()
        {
            var entity = new User() { Name = "1" };
            m_userRepository.Add(entity);
            m_unitOfWork.Commit();

            Assert.IsNull(m_userRepository.FindFirst((u) => u.Name.Equals("2") ));
        }

        [Test()]
        public void FindFirst_Match_Entity()
        {
            m_userRepository.Add(new User() { Name = "1" });
            m_userRepository.Add(new User() { Name = "2" });
            m_userRepository.Add(new User() { Name = "3" });
            m_unitOfWork.Commit();

            Assert.AreEqual("2", m_userRepository.FindFirst((u) => u.Name.Equals("2")).Name);
        }

        [Test()]
        public void FindFirstAscending_Match_EntityOrdered()
        {
            m_userRepository.Add(new User() { Name = "3" });
            m_userRepository.Add(new User() { Name = "1" });
            m_userRepository.Add(new User() { Name = "2" });
            m_unitOfWork.Commit();

            Assert.AreEqual("1", m_userRepository.FindFirstAscending((f) => true, (o) => o.Name).Name);
            Assert.AreEqual("2", m_userRepository.FindFirstAscending((f) => f.Name == "2", (o) => o.Name).Name);
        }

        [Test()]
        public void FindFirstDescending_Match_EntityOrdered()
        {
            m_userRepository.Add(new User() { Name = "1" });
            m_userRepository.Add(new User() { Name = "3" });
            m_userRepository.Add(new User() { Name = "2" });
            m_unitOfWork.Commit();

            Assert.AreEqual("3", m_userRepository.FindFirstDescending((f) => true, (o) => o.Name).Name);
            Assert.AreEqual("2", m_userRepository.FindFirstDescending((f) => f.Name == "2", (o) => o.Name).Name);
        }
        #endregion

        #region FindAllAscending
        [Test()]
        public void FindAllAscending_Match_OrderedEntities()
        {
            m_userRepository.Add(new User() { Name = "3" });
            m_userRepository.Add(new User() { Name = "1" });
            m_userRepository.Add(new User() { Name = "2" });
            m_unitOfWork.Commit();

            var actual = m_userRepository.FindAllAscending((o) => o.Name).ToList();
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual("1", actual[0].Name);
            Assert.AreEqual("2", actual[1].Name);
            Assert.AreEqual("3", actual[2].Name);

            actual = m_userRepository.FindAllAscending((f) => f.Name == "2", (o) => o.Name).ToList();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("2", actual[0].Name);

            actual = m_userRepository.FindAllAscending(1, 2, (o) => o.Name).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("2", actual[0].Name);
            Assert.AreEqual("3", actual[1].Name);

            actual = m_userRepository.FindAllAscending(0, 2, (f) => f.Name == "2", (o) => o.Name).ToList();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("2", actual[0].Name);
        }
        #endregion

        #region FindAllDescending
        [Test()]
        public void FindAllDescending_Match_OrderedEntities()
        {
            m_userRepository.Add(new User() { Name = "3" });
            m_userRepository.Add(new User() { Name = "1" });
            m_userRepository.Add(new User() { Name = "2" });
            m_unitOfWork.Commit();

            var actual = m_userRepository.FindAllDescending((o) => o.Name).ToList();
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual("3", actual[0].Name);
            Assert.AreEqual("2", actual[1].Name);
            Assert.AreEqual("1", actual[2].Name);

            actual = m_userRepository.FindAllDescending((f) => f.Name == "2", (o) => o.Name).ToList();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("2", actual[0].Name);

            actual = m_userRepository.FindAllDescending(1, 2, (o) => o.Name).ToList();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("2", actual[0].Name);
            Assert.AreEqual("1", actual[1].Name);

            actual = m_userRepository.FindAllDescending(0, 2, (f) => f.Name == "2", (o) => o.Name).ToList();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("2", actual[0].Name);
        }
        #endregion
    }
}