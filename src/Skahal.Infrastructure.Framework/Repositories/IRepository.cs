using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Domain;
using System;
using System.Linq.Expressions;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// Defines the interface of a repository entity.
	/// </summary>
	public interface IRepository<TEntity> where TEntity : IAggregateRoot 
    {
		/// <summary>
		/// Sets the unit of work.
		/// </summary>
		/// <param name="unitOfWork">Unit of work.</param>
		void SetUnitOfWork(IUnitOfWork unitOfWork);

		/// <summary>
		/// Finds the entity by the key.
		/// </summary>
		/// <returns>The found entity.</returns>
		/// <param name="key">Key.</param>
		TEntity FindBy(object key);

		/// <summary>
		/// Finds all entities that matches the filter.
		/// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="offset">The offset to start the result.</param>
        /// <param name="limit">The result count limit.</param>
        /// <param name="filter">The entities filter.</param>
		IEnumerable<TEntity> FindAll(int offset, int limit, Expression<Func<TEntity, bool>> filter);

        /// <summary>
		/// Finds all entities that matches the filter in a ascending order.
		/// </summary>
		/// <returns>The found entities.</returns>
		/// <param name="offset">The offset to start the result.</param>
		/// <param name="limit">The result count limit.</param>
		/// <param name="filter">The entities filter.</param>
        /// <param name="orderBy">The order.</param>
        IEnumerable<TEntity> FindAllAscending<TOrderByKey>(int offset, int limit, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderByKey>> orderBy);

        /// <summary>
        /// Finds all entities that matches the filter in a descending order.
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="offset">The offset to start the result.</param>
        /// <param name="limit">The result count limit.</param>
        /// <param name="filter">The entities filter.</param>
        /// <param name="orderBy">The order.</param>
        IEnumerable<TEntity> FindAllDescending<TOrderByKey>(int offset, int limit, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderByKey>> orderBy);

		/// <summary>
		/// Counts all entities that matches the filter.
		/// </summary>
		/// <returns>The number of the entities that matches the filter.</returns>
		/// <param name="filter">Filter.</param>
		long CountAll(Expression<Func<TEntity, bool>> filter);

		/// <summary>
		/// Add the specified entity.
		/// </summary>
		/// <param name="item">The entity.</param>
		void Add(TEntity item);

		/// <summary>
		/// Gets or sets the <see cref="Skahal.Infrastructure.Framework.Repositories.IRepository&lt;TEntity, TKey&gt;"/> with the specified key.
		/// </summary>
		/// <param name="key">Key.</param>
		TEntity this[object key] { get; set; }

		/// <summary>
		/// Remove the specified entity.
		/// </summary>
		/// <param name="item">The entity.</param>
		void Remove(TEntity item);
    }
}
