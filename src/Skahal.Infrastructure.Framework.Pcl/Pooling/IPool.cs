using System;

namespace Skahal.Infrastructure.Framework.PCL.Pooling
{
	/// <summary>
	/// Defines an interface for a pool.
	/// </summary>
	public interface IPool
	{
		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; }

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		int Size { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is fixed size.
		/// </summary>
		/// <value><c>true</c> if this instance is fixed size; otherwise, <c>false</c>.</value>
		bool IsFixedSize { get; set; }

		/// <summary>
		/// Gets or sets the auto disable time.
		/// </summary>
		/// <value>The auto disable time.</value>
		float AutoDisableTime { get; set; }

		/// <summary>
		/// Gets the items count.
		/// </summary>
		/// <value>The items count.</value>
		int ItemsCount { get; }
		#endregion

		#region Methods
		/// <summary>
		/// Creates the items.
		/// </summary>
		void CreateItems();

		/// <summary>
		/// Gets the item.
		/// </summary>
		/// <returns>The item.</returns>
		object GetItem();

		/// <summary>
		/// Releases the item.
		/// </summary>
		/// <param name="item">Item.</param>
		void ReleaseItem(object item);

		/// <summary>
		/// Releases all items that fit in release filter specified.
		/// </summary>
		/// <param name='releaseFilter'>
		/// Release filter.
		/// </param>
		void ReleaseAll (Func<object, bool> releaseFilter);
		#endregion
	}
}