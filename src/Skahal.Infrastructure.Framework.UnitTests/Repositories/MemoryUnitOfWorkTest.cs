using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Repositories;
using Skahal.Infrastructure.Framework.People;
using Rhino.Mocks;

namespace Skahal.Infrastructure.Framework.UnitTests.Repositories
{
	[TestFixture()]
	public class MemoryUnitOfWorkTest
	{
		[Test()]
		public void RegisterAdded_Commit_Added ()
		{
			var target = new MemoryUnitOfWork<string> ();
			var user1 = new User ("1");
			var repository = MockRepository.GenerateStrictMock<IUnitOfWorkRepository<string>> ();
			repository.Expect (r => r.PersistNewItem(user1));

			target.RegisterAdded (user1, repository);
		
			target.Commit ();

			repository.VerifyAllExpectations ();
		}

		[Test()]
		public void RegisterChanged_Commit_Updated()
		{
			var target = new MemoryUnitOfWork<string> ();
			var user1 = new User ("1");
			var repository = MockRepository.GenerateStrictMock<IUnitOfWorkRepository<string>> ();
			repository.Expect (r => r.PersistUpdatedItem(user1));

			target.RegisterChanged (user1, repository);

			target.Commit ();

			repository.VerifyAllExpectations ();
		}

		[Test()]
		public void RegisterRemoved_Commit_Deleted ()
		{
			var target = new MemoryUnitOfWork<string> ();
			var user1 = new User ("1");
			var repository = MockRepository.GenerateStrictMock<IUnitOfWorkRepository<string>> ();
			repository.Expect (r => r.PersistDeletedItem(user1));

			target.RegisterRemoved (user1, repository);

			target.Commit ();

			repository.VerifyAllExpectations ();
		}

		[Test()]
		public void Commit_EntitiesToAddChangeAndDelte_RightCommit ()
		{
			var target = new MemoryUnitOfWork<string> ();

			var userToDelete = new User ("1");
			var userToAdd = new User ("2");
			var userToUpdate = new User ("3");

			var repository = MockRepository.GenerateStrictMock<IUnitOfWorkRepository<string>> ();
			repository.Expect (r => r.PersistDeletedItem(userToDelete));
			repository.Expect (r => r.PersistNewItem(userToAdd));
			repository.Expect (r => r.PersistUpdatedItem(userToUpdate));

			target.RegisterRemoved (userToDelete, repository);
			target.RegisterAdded (userToAdd, repository);
			target.RegisterChanged (userToUpdate, repository);

			target.Commit ();

			repository.VerifyAllExpectations ();
		}
	}
}

