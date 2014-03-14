using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HelperSharp;
using Skahal.Infrastructure.Framework.Domain;
using Skahal.Infrastructure.Framework.Repositories;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// A basic repository on memory.
	/// <remarks>
	/// In most of cases will be used for tests purposes.
	/// </remarks>
	/// </summary>
	public class MemoryRepository<TEntity> : RepositoryBase<TEntity> where TEntity : IAggregateRoot 
	{
		#region Fields
		private Func<TEntity, object> m_createNewKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Repositories.MemoryRepository&lt;TEntity, TKey&gt;"/> class.
		/// </summary>
        public MemoryRepository(Func<TEntity, object> createNewKey)
		{
			m_createNewKey = createNewKey;
			Entities = new List<TEntity> ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Repositories.MemoryRepository&lt;TEntity, TKey&gt;"/> class.
		/// </summary>
		/// <param name="createNewKey">Create new key.</param>
		/// <param name="unitOfWork">Unit of work.</param>
        public MemoryRepository(IUnitOfWork unitOfWork, Func<TEntity, object> createNewKey)
            : base(unitOfWork)
		{
			m_createNewKey = createNewKey;
			Entities = new List<TEntity> ();
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the entities.
		/// </summary>
		/// <value>The entities.</value>
		protected List<TEntity> Entities { get; private set; }
		#endregion

		#region implemented abstract members of RepositoryBase
		/// <summary>
		/// Finds the entity by the key.
		/// </summary>
		/// <returns>The found entity.</returns>
		/// <param name="key">Key.</param>
		public override TEntity FindBy (object key)
		{
			return FindAll(0, 1, e => e.Key.Equals(key)).FirstOrDefault();
		}

		/// <summary>
		/// Finds all entities that matches the filter.
		/// </summary>
		/// <returns>The found entities.</returns>
		/// <param name="offset">Offset.</param>
		/// <param name="limit">Limit.</param>
		/// <param name="filter">Filter.</param>
		public override IEnumerable<TEntity> FindAll (int offset, int limit, Expression<Func<TEntity, bool>> filter)
		{
			return InitializeQuery(filter)
				.OrderBy(e => e.Key)
				.Skip(offset)
                .Take(limit);
		}

        /// <summary>
        /// Finds all entities that matches the filter in a ascending order.
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="offset">The offset to start the result.</param>
        /// <param name="limit">The result count limit.</param>
        /// <param name="filter">The entities filter.</param>
        /// <param name="orderBy">The order.</param>
        public override IEnumerable<TEntity> FindAllAscending<TOrderByKey>(int offset, int limit, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderByKey>> orderBy)
        {            
            ExceptionHelper.ThrowIfNull("orderBy", orderBy);

            return InitializeQuery(filter)
                .OrderBy(e => orderBy.Compile()(e))
                .Skip(offset)
                .Take(limit);
        }

        /// <summary>
        /// Finds all entities that matches the filter in a descending order.
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="offset">The offset to start the result.</param>
        /// <param name="limit">The result count limit.</param>
        /// <param name="filter">The entities filter.</param>
        /// <param name="orderBy">The order.</param>
        public override IEnumerable<TEntity> FindAllDescending<TOrderByKey>(int offset, int limit, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderByKey>> orderBy)
        {            
            ExceptionHelper.ThrowIfNull("orderBy", orderBy);

            return InitializeQuery(filter)
                .OrderByDescending(e => orderBy.Compile()(e))
                .Skip(offset)
                .Take(limit);
        }

		/// <summary>
		/// Counts all entities that matches the filter.
		/// </summary>
		/// <returns>The number of the entities that matches the filter.</returns>
		/// <param name="filter">Filter.</param>
        public override long CountAll(Expression<Func<TEntity, bool>> filter)
		{
            if (filter == null)
            {
                return Entities.Count();
            }
            else
            {
                return Entities.Count(e => filter.Compile()(e));
            }
		}

		/// <summary>
		/// Persists the new item.
		/// </summary>
		/// <param name="item">Item.</param>
		protected override void PersistNewItem (TEntity item)
		{
			ExceptionHelper.ThrowIfNull ("item", item);

			if (Entities.FirstOrDefault (e => e.Key.Equals(item.Key)) != null) {
				throw new InvalidOperationException ("There is another entity with id '{0}'.".With(item.Key));
			}

			if (item.Key == null || (item.Key.GetType().IsValueType && Activator.CreateInstance(item.Key.GetType()).Equals(item.Key))) {
				item.Key = m_createNewKey (item);
			}

			Entities.Add (item);
		}

		/// <summary>
		/// Persists the updated item.
		/// </summary>
		/// <param name="item">Item.</param>
		protected override void PersistUpdatedItem (TEntity item)
		{
			ExceptionHelper.ThrowIfNull ("item", item);
			
			PersistDeletedItem (item);
			PersistNewItem (item);
		}

		/// <summary>
		/// Persists the deleted item.
		/// </summary>
		/// <param name="item">Item.</param>
		protected override void PersistDeletedItem (TEntity item)
		{
			ExceptionHelper.ThrowIfNull ("item", item);

			var old = Entities.FirstOrDefault (e => e.Key.Equals(item.Key));

			if (old == null) {
				throw new InvalidOperationException ("There is no entity with id '{0}'.".With(item.Key));
			}

			Entities.Remove (old);
		}

        private IEnumerable<TEntity> InitializeQuery(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                return Entities;
            }
            else
            {
                return Entities.Where(e => filter.Compile()(e));
            }
        }
		#endregion       
    }
}