using System;
using Skahal.Infrastructure.Framework.Domain;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// Repository extensions.
	/// </summary>
	public static class RepositoryExtensions
	{
		/// <summary>
		/// Finds all entities that matches the filter.
		/// </summary>
		/// <returns>The found entities.</returns>
		/// <param name="repository">Repository.</param>
		/// <param name="filter">Filter.</param>
		public static IEnumerable<TEntity> FindAll<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> filter)
			where TEntity : IAggregateRoot
		{
			return repository.FindAll(0, int.MaxValue, filter);
		}

		/// <summary>
		/// Finds all entities.
		/// </summary>
		/// <returns>The found entities.</returns>
		/// <param name="repository">Repository.</param>
		/// <param name="offset">Offset.</param>
		/// <param name="limit">Limit.</param>
		public static IEnumerable<TEntity> FindAll<TEntity>(this IRepository<TEntity> repository, int offset, int limit)
			where TEntity : IAggregateRoot
		{
			return repository.FindAll(offset, limit, f => true);
		}

		/// <summary>
		/// Counts all entities.
		/// </summary>
		/// <param name="repository">Repository.</param>
		/// <returns>The number of the entities that matches the filter.</returns>
		public static long CountAll<TEntity>(this IRepository<TEntity> repository)
			where TEntity : IAggregateRoot
		{
			return repository.CountAll (f => true);
		}

        /// <summary>
        /// Finds the first entity that match the filter.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>The first entity that match the filter or null if none match.</returns>
        public static TEntity FindFirst<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> filter)
            where TEntity : IAggregateRoot
        {
            return repository.FindAll(0, 1, filter).FirstOrDefault();
        }

		/// <summary>
		/// Finds the last entity.
		/// </summary>
		/// <returns>The last entity.</returns>
		/// <param name="repository">Repository.</param>
		/// <typeparam name="TEntity">The 1st type parameter.</typeparam>
		/// <typeparam name="TKey">The 2st type parameter.</typeparam>
		public static TEntity FindLast<TEntity>(this IRepository<TEntity> repository) 
			where TEntity : IAggregateRoot
		{
			return repository.FindAll (Convert.ToInt32(repository.CountAll() - 1), 1, f => true).FirstOrDefault ();
		}		
	}
}

