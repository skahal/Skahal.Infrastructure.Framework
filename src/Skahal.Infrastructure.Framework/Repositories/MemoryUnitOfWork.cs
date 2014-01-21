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
        #region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Repositories.MemoryUnitOfWork&lt;TKey&gt;"/> class.
		/// </summary>
        public MemoryUnitOfWork()
        {
            Entities = new List<EntityRepositoryPair>();
        }
        #endregion

        #region Properties
        protected IList<EntityRepositoryPair> Entities { get; private set; }
        #endregion


        #region Methods
		/// <summary>
		/// Registers an entity to be added when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
        public virtual void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            Entities.Add(new EntityRepositoryPair(new UnitOfWorkEntity(entity, UnitOfWorkEntityState.Added), repository));
	    }

		/// <summary>
		/// Registers an entity to be changed when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		public virtual void RegisterChanged(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            Entities.Add(new EntityRepositoryPair(new UnitOfWorkEntity(entity, UnitOfWorkEntityState.Changed), repository));
        }

		/// <summary>
		/// Registers an entity to be removed when commited.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
        public virtual void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            Entities.Add(new EntityRepositoryPair(new UnitOfWorkEntity(entity, UnitOfWorkEntityState.Removed), repository));
        }

		/// <summary>
		/// Commit the registered entities.
		/// </summary>
        public virtual void Commit()
        {
           foreach (var item in Entities.Where(e => e.Entity.State == UnitOfWorkEntityState.Removed))
            {
                item.Repository.PersistDeletedItem(item.Entity.Entity);
            }

           foreach (var item in Entities.Where(e => e.Entity.State == UnitOfWorkEntityState.Added))
            {
				item.Repository.PersistNewItem(item.Entity.Entity);
            }

            foreach (var item in Entities.Where(e => e.Entity.State == UnitOfWorkEntityState.Changed))
            {
                item.Repository.PersistUpdatedItem(item.Entity.Entity);
            }

            Entities.Clear();
        }

        /// <summary>
        /// Undo changes made after the latest commit.
        /// </summary>
        public void Rollback()
        {
            Entities.Clear();
        }
        #endregion


        /// <summary>
        /// Get the entity which is registered inside the unit of work.
        /// </summary>
        /// <param name="key">The entity key.</param>
        /// <returns>
        /// The entity instance or null if it is not register.
        /// </returns>
        public UnitOfWorkEntity Get(object key)
        {
            UnitOfWorkEntity result = null;

            var pair = Entities.FirstOrDefault(e => e.Entity.Entity.Key.Equals(key));

            if (pair != null)
            {
                result = pair.Entity;
            }

            return result;
        }        
    }
}
