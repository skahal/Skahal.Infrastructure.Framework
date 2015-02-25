using System;
using Skahal.Infrastructure.Framework.Domain;
using Skahal.Infrastructure.Framework.Repositories;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// Defines an interface for an unit of work.
	/// </summary>
	public interface IUnitOfWork
    {
		/// <summary>
		/// Registers an entity to be added when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository repository);

		/// <summary>
		/// Registers an entity to be changed when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		void RegisterChanged(IAggregateRoot entity, IUnitOfWorkRepository repository);

		/// <summary>
		///  Registers an entity to be removed when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository repository);

		/// <summary>
		/// Commit the registered entities.
		/// </summary>
        void Commit();

        /// <summary>
        /// Undo changes made after the latest commit.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Get the entity which is registered inside the unit of work.
        /// </summary>
        /// <param name="key">The entity key.</param>
        /// <returns>The entity instance or null if it is not register.</returns>
        UnitOfWorkEntity Get(object key);
    }
}
