using System;
using Skahal.Infrastructure.Framework.Domain;
using Skahal.Infrastructure.Framework.Repositories;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// Defines an interface for an unit of work.
	/// </summary>
	public interface IUnitOfWork<TKey>
    {
		/// <summary>
		/// Registers an entity to be added when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		void RegisterAdded(IAggregateRoot<TKey> entity, IUnitOfWorkRepository<TKey> repository);

		/// <summary>
		/// Registers an entity to be changed when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		void RegisterChanged(IAggregateRoot<TKey> entity, IUnitOfWorkRepository<TKey> repository);

		/// <summary>
		///  Registers an entity to be removed when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		void RegisterRemoved(IAggregateRoot<TKey> entity, IUnitOfWorkRepository<TKey> repository);

		/// <summary>
		/// Commit the registered entities.
		/// </summary>
        void Commit();
    }
}
