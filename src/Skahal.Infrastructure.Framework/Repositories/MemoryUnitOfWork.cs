#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using Skahal.Infrastructure.Framework.Domain;
#endregion

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// Defines an in memory unit of work.
	/// </summary>
	public class MemoryUnitOfWork : IUnitOfWork
    {
        #region Fields
		private List<EntityRepositoryPair> m_AddedEntities;
		private List<EntityRepositoryPair> m_changedEntities;
		private List<EntityRepositoryPair> m_deletedEntities;
        #endregion

        #region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Repositories.MemoryUnitOfWork&lt;TKey&gt;"/> class.
		/// </summary>
        public MemoryUnitOfWork()
        {
			m_AddedEntities = new List<EntityRepositoryPair>();
			m_changedEntities = new List<EntityRepositoryPair>();
			m_deletedEntities = new List<EntityRepositoryPair>();
        }
        #endregion

        #region Methods
		/// <summary>
		/// Registers an entity to be added when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		public void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
			m_AddedEntities.Add(new EntityRepositoryPair(entity, repository));
	    }

		/// <summary>
		/// Registers an entity to be changed when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		public void RegisterChanged(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
			m_changedEntities.Add(new EntityRepositoryPair(entity, repository));
        }

		/// <summary>
		/// Registers an entity to be removed when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
			m_deletedEntities.Add(new EntityRepositoryPair(entity, repository));
        }

		/// <summary>
		/// Commit the registered entities.
		/// </summary>
        public virtual void Commit()
        {
           foreach (var item in m_deletedEntities)
            {
				item.Repository.PersistDeletedItem(item.Entity);
            }

            foreach (var item in m_AddedEntities)
            {
				item.Repository.PersistNewItem(item.Entity);
            }

            foreach (var item in m_changedEntities)
            {
				item.Repository.PersistUpdatedItem(item.Entity);
            }
		
			m_deletedEntities.Clear();
			m_AddedEntities.Clear();
			m_changedEntities.Clear();
        }
        #endregion
    }
}
