#region Usings
using System.Collections;
using System.Text;
using System.Collections.Generic;
#endregion

namespace Skahal.Infrastructure.Framework.Collections
{
	/// <summary>
	/// Extensions methods to collections.
	/// </summary>
	public static class CollectionExtensions
	{
		#region AddRange
		/// <summary>
		/// Adds the list to this.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="newItems">New items.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static void AddRange<T>(this IList<T> source, IEnumerable<T> newItems)
		{
			foreach(var i in newItems)
			{
				source.Add(i);
			}
		}

		/// <summary>
		/// Adds the list to this.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="newItems">New items.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static void AddRange<T>(this IList<T> source, params T[] newItems)
		{
			foreach(var i in newItems)
			{
				source.Add(i);
			}
		}
		#endregion
		
		#region AddIfNotExists
		/// <summary>
		/// Adds if not exists.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="item">Item.</param>
		/// <typeparam name="TItem">The 1st type parameter.</typeparam>
		public static void AddIfNotExists<TItem>(this IList<TItem> source, TItem item)
		{
			if(!source.Contains(item))
			{
				source.Add(item);
			}
		}
		#endregion
		
		#region Joins
        /// <summary>
        /// Faz a união dos itens de uma coleção numa string.
        /// Utiliza "," como separador dos itens.
        /// </summary>
        /// <param name="collection">Os itens a serem unidos numa string.</param>
        /// <returns>A string com os itens unidos.</returns>
        public static string Join(this ICollection collection)
        {
            return Join(collection, ",", ",");
        }

        /// <summary>
        /// Faz a união dos itens de uma coleção numa string.
        /// Utiliza "," como separador dos itens.
        /// </summary>
        /// <param name="collection">Os itens a serem unidos numa string.</param>
        /// <param name="separator">Separador utilizado entre os itens.</param>
        /// <returns>A string com os itens unidos.</returns>
        public static string Join(this ICollection collection, string separator)
        {
            return Join(collection, separator, separator);
        }

        /// <summary>
        /// Faz a união dos itens de uma coleção numa string.
        /// Utiliza "," como separador dos itens.
        /// </summary>
        /// <param name="collection">Os itens a serem unidos numa string.</param>
        /// <param name="separator">Separador utilizado entre os itens.</param>
        /// <param name="lastSeparator">Separador entre o penúltimo e o último item.</param>
        /// <returns>A string com os itens unidos.</returns>
        public static string Join(this ICollection collection, string separator, string lastSeparator)
        {
            if (collection == null)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            bool isFirst = true;
            int i = 0;

            foreach (object item in collection)
            {
                if (isFirst)
                {
                    sb.Append(item);
                    isFirst = false;
                }
                else
                {
                    if (i == collection.Count - 1)
                    {
                        sb.AppendFormat("{0}{1}", lastSeparator, item);
                    }
                    else
                    {
                        sb.AppendFormat("{0}{1}", separator, item);
                    }
                }
                i++;
            }

            return sb.ToString();
        }
        #endregion    
	}
}

