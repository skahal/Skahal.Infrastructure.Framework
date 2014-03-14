using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Skahal.Infrastructure.Framework.Domain;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// Repository extensions.
	/// </summary>
	public static class RepositoryExtensions
    {
        #region FindAll
        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">Repository.</param>
        /// <param name="filter">Filter.</param>
        public static IEnumerable<TEntity> FindAll<TEntity>(this IRepository<TEntity> repository)
            where TEntity : IAggregateRoot
        {
            return repository.FindAll(0, int.MaxValue, null);
        }

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
			return repository.FindAll(offset, limit, null);
		}

        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">Repository.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        public static IEnumerable<TEntity> FindAll<TEntity>(this IRepository<TEntity> repository, int offset, long limit)
            where TEntity : IAggregateRoot
        {
            return repository.FindAll(offset, Convert.ToInt32(limit), null);
        }
        #endregion

        #region FindAllAscending
        /// <summary>
        /// Finds all entities  in a ascending order
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">The repository.</param>
        /// <param name="orderBy">The order.</param>
        public static IEnumerable<TEntity> FindAllAscending<TEntity, TOrderByKey>(this IRepository<TEntity> repository, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllAscending(0, int.MaxValue, null, orderBy);
        }

        /// <summary>
        /// Finds all entities that matches the filter in a ascending order
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">The repository.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order.</param>
        public static IEnumerable<TEntity> FindAllAscending<TEntity, TOrderByKey>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllAscending(0, int.MaxValue, filter, orderBy);
        }

        /// <summary>
        /// Finds all entities in a ascending order
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">Repository.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="orderBy">The order.</param>
        public static IEnumerable<TEntity> FindAllAscending<TEntity, TOrderByKey>(this IRepository<TEntity> repository, int offset, int limit, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllAscending(offset, limit, null, orderBy);
        }

        /// <summary>
        /// Finds all entities in a ascending order
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">Repository.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="orderBy">The order.</param>
        public static IEnumerable<TEntity> FindAll<TEntity, TOrderByKey>(this IRepository<TEntity> repository, int offset, long limit, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllAscending(offset, Convert.ToInt32(limit), null, orderBy);
        }
        #endregion

        #region FindAllDescending
        /// <summary>
        /// Finds all entities  in a descending order
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">The repository.</param>
        /// <param name="orderBy">The order.</param>
        public static IEnumerable<TEntity> FindAllDescending<TEntity, TOrderByKey>(this IRepository<TEntity> repository, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllDescending(0, int.MaxValue, (f) => true, orderBy);
        }

        /// <summary>
        /// Finds all entities that matches the filter in a descending order
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">The repository.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order.</param>
        public static IEnumerable<TEntity> FindAllDescending<TEntity, TOrderByKey>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllDescending(0, int.MaxValue, filter, orderBy);
        }

        /// <summary>
        /// Finds all entities in a descending order
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">Repository.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="orderBy">The order.</param>
        public static IEnumerable<TEntity> FindAllDescending<TEntity, TOrderByKey>(this IRepository<TEntity> repository, int offset, int limit, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllDescending(offset, limit, null, orderBy);
        }

        /// <summary>
        /// Finds all entities in a descending order
        /// </summary>
        /// <returns>The found entities.</returns>
        /// <param name="repository">Repository.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="orderBy">The order.</param>
        public static IEnumerable<TEntity> FindAllDescending<TEntity, TOrderByKey>(this IRepository<TEntity> repository, int offset, long limit, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllDescending(offset, Convert.ToInt32(limit), null, orderBy);
        }
        #endregion

        #region CountAll
        /// <summary>
		/// Counts all entities.
		/// </summary>
		/// <param name="repository">Repository.</param>
		/// <returns>The number of the entities that matches the filter.</returns>
		public static long CountAll<TEntity>(this IRepository<TEntity> repository)
			where TEntity : IAggregateRoot
		{
			return repository.CountAll (null);
		}
        #endregion

        #region FindFirst
        /// <summary>
        /// Finds the first entity.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <returns>The first entity.</returns>
        public static TEntity FindFirst<TEntity>(this IRepository<TEntity> repository)
            where TEntity : IAggregateRoot
        {
            return repository.FindAll(0, 1).FirstOrDefault();
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
        /// Finds the first entity that match the filter in an ascending order.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order.</param>
        /// <returns>The first entity that match the filter or null if none match.</returns>
        public static TEntity FindFirstAscending<TEntity, TOrderByKey>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllAscending(0, 1, filter, orderBy).FirstOrDefault();
        }

        /// <summary>
        /// Finds the first entity that match the filter in an descending order.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order.</param>
        /// <returns>The first entity that match the filter or null if none match.</returns>
        public static TEntity FindFirstDescending<TEntity, TOrderByKey>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderByKey>> orderBy)
            where TEntity : IAggregateRoot
        {
            return repository.FindAllDescending(0, 1, filter, orderBy).FirstOrDefault();
        }
        #endregion

        #region FindLast
        /// <summary>
		/// Finds the last entity.
		/// </summary>
		/// <returns>The last entity.</returns>
		/// <param name="repository">Repository.</param>
		/// <typeparam name="TEntity">The 1st type parameter.</typeparam>
		public static TEntity FindLast<TEntity>(this IRepository<TEntity> repository) 
			where TEntity : IAggregateRoot
		{
			return repository.FindAll (Convert.ToInt32(repository.CountAll() - 1), 1).FirstOrDefault ();
        }
        #endregion
    }
}

