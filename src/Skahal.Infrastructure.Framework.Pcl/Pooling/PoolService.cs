using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Skahal.Infrastructure.Framework.PCL.Commons;

namespace Skahal.Infrastructure.Framework.PCL.Pooling
{
	/// <summary>
	/// Pool service.
	/// </summary>
	public static class PoolService
	{
		#region Fields
		private static Dictionary<string, IPool> s_pools = new Dictionary<string, IPool> ();
		#endregion

		#region Properties
		/// <summary>
		/// Gets the pools count.
		/// </summary>
		/// <value>The pools count.</value>
		public static int PoolsCount {
			get {
				return s_pools.Count;
			}
		}
		#endregion

		#region Public methods
		/// <summary>
		/// Gets the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="poolName">Pool name.</param>
		public static object GetItem(string poolName)
		{
			return GetPool(poolName).GetItem();
		}

		/// <summary>
		/// Gets the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="poolName">Pool name.</param>
		/// <typeparam name="TItem">The 1st type parameter.</typeparam>
		public static TItem GetItem<TItem>(string poolName)
		{
			return (TItem) GetPool(poolName).GetItem();
		}

		/// <summary>
		/// Releases the item.
		/// </summary>
		/// <param name="poolName">Pool name.</param>
		/// <param name="item">Item.</param>
		public static void ReleaseItem(string poolName, object item)
		{
			GetPool(poolName).ReleaseItem(item);
		}

		/// <summary>
		/// Releases all items in all pools that fit in release filter specified.
		/// </summary>
		/// <param name='releaseFilter'>
		/// Release filter.
		/// </param>
		public static void ReleaseAll (Func<object, bool> releaseFilter)
		{
			if(releaseFilter == null)
			{
				ReleaseAll();
			}

			foreach (var p in s_pools) {
				p.Value.ReleaseAll(releaseFilter);
			}
		}

		/// <summary>
		/// Releases all items in all pools.
		/// </summary>
		public static void ReleaseAll()
		{
			ReleaseAll((i) => true);
		}

		/// <summary>
		/// Gets all available pools.
		/// </summary>
		/// <returns>The all pools.</returns>
		public static IList<IPool> GetAllPools()
		{
			return s_pools.Values.ToList();
		}
		#endregion

		#region Private methods
		/// <summary>
		/// Registers the pool.
		/// </summary>
		/// <param name="pool">Pool.</param>
		internal static void RegisterPool(IPool pool)
		{
			if(pool == null)
			{
				throw new ArgumentNullException("pool");
			}
			
			if(s_pools.ContainsKey(pool.Name))
			{
				var msg = String.Format(CultureInfo.InvariantCulture, "Already exists a registered pool with name '{0}'. The pool names must be unique.", pool.Name);
				throw new InvalidOperationException(msg);
			}
			
			s_pools.Add(pool.Name, pool);
		}
		
		/// <summary>
		/// Unregisters all pools.
		/// </summary>
		internal static void UnregisterAllPools()
		{
			ReleaseAll();
			ClearAllPools();
		}

		internal static void ClearAllPools()
		{
			s_pools.Clear();
		}

		/// <summary>
		/// Gets the pool.
		/// </summary>
		/// <returns>The pool.</returns>
		/// <param name="poolName">Pool name.</param>
		private static IPool GetPool (string poolName)
		{
			if(!s_pools.ContainsKey(poolName))
			{
				var msg = string.Format("The pool with name '{0}' was not found.", poolName);
				throw new InvalidOperationException(msg);
			}

			return s_pools [poolName];			
		}
		#endregion
	}
}