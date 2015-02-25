using System;
using Skahal.Infrastructure.Framework.Domain;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// Defines an unit of work repository.
	/// </summary>
    public interface IUnitOfWorkRepository
    {
		/// <summary>
		/// Persists the new item.
		/// </summary>
		/// <param name="item">Item.</param>
		void PersistNewItem(IAggregateRoot item);

		/// <summary>
		/// Persists the updated item.
		/// </summary>
		/// <param name="item">Item.</param>
		void PersistUpdatedItem(IAggregateRoot item);

		/// <summary>
		/// Persists the deleted item.
		/// </summary>
		/// <param name="item">Item.</param>
		void PersistDeletedItem(IAggregateRoot item);
    }
}