using System;
using System.Collections.Generic;
using System.Linq;
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
	public class MemoryRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey> where TEntity : IAggregateRoot<TKey> 
	{
		#region Fields
		private Func<TEntity, TKey> m_createNewKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Repositories.MemoryRepository&lt;TEntity, TKey&gt;"/> class.
		/// </summary>
		public MemoryRepository(Func<TEntity, TKey> createNewKey)
		{
			m_createNewKey = createNewKey;
			Entities = new List<TEntity> ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Repositories.MemoryRepository&lt;TEntity, TKey&gt;"/> class.
		/// </summary>
		/// <param name="createNewKey">Create new key.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		public MemoryRepository(IUnitOfWork<TKey> unitOfWork, Func<TEntity, TKey> createNewKey) : base(unitOfWork)
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
		public override TEntity FindBy (TKey key)
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
		public override IEnumerable<TEntity> FindAll (int offset, int limit, Func<TEntity, bool> filter)
		{
			ExceptionHelper.ThrowIfNull ("filter", filter);

			return Entities
				.Where (e => filter(e))
				.OrderBy(e => e.Key)
				.Skip(offset).Take(limit);
		}

		/// <summary>
		/// Counts all entities that matches the filter.
		/// </summary>
		/// <returns>The number of the entities that matches the filter.</returns>
		/// <param name="filter">Filter.</param>
		public override long CountAll (Func<TEntity, bool> filter)
		{
			ExceptionHelper.ThrowIfNull ("filter", filter);
			return Entities.Count (e => filter(e));
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

			if (item.Key == null || item.Key.Equals(default(TKey))) {
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
		#endregion
	}
}