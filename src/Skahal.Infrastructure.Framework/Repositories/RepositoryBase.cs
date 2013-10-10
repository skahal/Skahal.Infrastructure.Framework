using Skahal.Infrastructure.Framework.Domain;
using System.Collections.Generic;
using System;
using HelperSharp;
using System.Linq.Expressions;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// A base class for repositories.
	/// </summary>
	public abstract class RepositoryBase<TEntity>
		: IRepository<TEntity>, IUnitOfWorkRepository where TEntity : IAggregateRoot 
    {
		#region Fields
		private IUnitOfWork m_unitOfWork;
		#endregion

        #region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Repositories.RepositoryBase&lt;TEntity, TKey&gt;"/> class.
		/// </summary>
        protected RepositoryBase() 
            : this(null)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Repositories.RepositoryBase&lt;TEntity, TKey&gt;"/> class.
		/// </summary>
		/// <param name="unitOfWork">Unit of work.</param>
		protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            m_unitOfWork = unitOfWork;
        }
        #endregion

        #region IRepository<T> Members
		/// <summary>
		/// Finds an entity by the key.
		/// </summary>
		/// <returns>The entity.</returns>
		/// <param name="key">Key.</param>
        public abstract TEntity FindBy(object key);

		/// <summary>
		/// Finds all entities that matches the filter.
		/// </summary>
		/// <returns>The found entities.</returns>
		/// <param name="offset">Offset.</param>
		/// <param name="limit">Limit.</param>
		/// <param name="filter">Filter.</param>
		public abstract IEnumerable<TEntity> FindAll(int offset, int limit, Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Finds all entities that matches the filter in a ascending order.
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="offset">The offset to start the result.</param>
        /// <param name="limit">The result count limit.</param>
        /// <param name="filter">The entities filter.</param>
        /// <param name="orderBy">The order.</param>
        public abstract IEnumerable<TEntity> FindAllAscending<TKey>(int offset, int limit, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> orderBy);

        /// <summary>
        /// Finds all entities that matches the filter in a descending order.
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="offset">The offset to start the result.</param>
        /// <param name="limit">The result count limit.</param>
        /// <param name="filter">The entities filter.</param>
        /// <param name="orderBy">The order.</param>
        public abstract IEnumerable<TEntity> FindAllDescending<TKey>(int offset, int limit, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> orderBy);

		/// <summary>
		/// Counts all entities that matches the filter.
		/// </summary>
		/// <returns>The found entities.</returns>
		/// <param name="filter">Filter.</param>
		public abstract long CountAll(Expression<Func<TEntity, bool>> filter);

		/// <summary>
		/// Sets the unit of work.
		/// </summary>
		/// <param name="unitOfWork">Unit of work.</param>
		public virtual void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            m_unitOfWork = unitOfWork;
        }

		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
        public void Add(TEntity item)
        {
			ExceptionHelper.ThrowIfNull ("item", item);

			ValidateUnitOfWork ();
			m_unitOfWork.RegisterAdded(item, this);
        }

		/// <summary>
		/// Remove the specified entity.
		/// </summary>
		/// <param name="item">The entity.</param>
        public void Remove(TEntity item)
        {
			ExceptionHelper.ThrowIfNull ("item", item);

			ValidateUnitOfWork ();
			m_unitOfWork.RegisterRemoved(item, this);
        }
        

		/// <summary>
		/// Gets or sets the <see cref="Skahal.Infrastructure.Framework.Repositories.RepositoryBase&lt;TEntity, TKey&gt;"/> with the specified key.
		/// </summary>
		/// <param name="key">Key.</param>
		public TEntity this[object key]
        {
            get
            {
                return FindBy(key);
            }
            set
            {
                if (FindBy(key) == null)
                {
                    Add(value);
                }
                else
                {
					ValidateUnitOfWork ();
                    m_unitOfWork.RegisterChanged(value, this);
                }
            }
        }

        #endregion

        #region IUnitOfWorkRepository Members
		/// <summary>
		/// Persists the new item.
		/// </summary>
		/// <param name="item">Item.</param>
		public virtual void PersistNewItem(IAggregateRoot item)
        {
            ExceptionHelper.ThrowIfNull("item", item);

            PersistNewItem((TEntity)item);
        }

		/// <summary>
		/// Persists the updated item.
		/// </summary>
		/// <param name="item">Item.</param>
		public virtual void PersistUpdatedItem(IAggregateRoot item)
        {
            ExceptionHelper.ThrowIfNull("item", item);

            PersistUpdatedItem((TEntity)item);
        }

		/// <summary>
		/// Persists the deleted item.
		/// </summary>
		/// <param name="item">Item.</param>
		public virtual void PersistDeletedItem(IAggregateRoot item)
        {
            ExceptionHelper.ThrowIfNull("item", item);

            PersistDeletedItem((TEntity)item);
        }
        #endregion

        #region Properties
		/// <summary>
		/// Gets the unit of work.
		/// </summary>
		/// <value>The unit of work.</value>
		protected IUnitOfWork UnitOfWork
        {
            get { return m_unitOfWork; }
        }

        #endregion

        #region Methods
		/// <summary>
		/// Persists the new item.
		/// </summary>
		/// <param name="item">Item.</param>
        protected abstract void PersistNewItem(TEntity item);

		/// <summary>
		/// Persists the updated item.
		/// </summary>
		/// <param name="item">Item.</param>
        protected abstract void PersistUpdatedItem(TEntity item);

		/// <summary>
		/// Persists the deleted item.
		/// </summary>
		/// <param name="item">Item.</param>
        protected abstract void PersistDeletedItem(TEntity item);

        #endregion

		#region Helpers
        /// <summary>
        /// Validates the unit of work.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">There is no UnitOfWork configured for the repository '{0}'..With(GetType().Name)</exception>
		protected void ValidateUnitOfWork()
		{
			if (m_unitOfWork == null) {
				throw new InvalidOperationException ("There is no UnitOfWork configured for the repository '{0}'.".With(GetType().Name));
			}
		}
		#endregion
    }
}