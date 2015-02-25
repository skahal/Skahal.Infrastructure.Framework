using System;

namespace Skahal.Infrastructure.Framework.Pooling
{
	/// <summary>
	/// A Pool base class.
	/// </summary>
	public abstract class PoolBase : IPool
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Pooling.PoolBase"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		protected PoolBase (string name)
		{
			Name = name;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; private set; }

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		public int Size { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is fixed size.
		/// </summary>
		/// <value>true</value>
		/// <c>false</c>
		public bool IsFixedSize { get; set; }

		/// <summary>
		/// Gets or sets the auto disable time.
		/// </summary>
		/// <value>The auto disable time.</value>
		public float AutoDisableTime { get; set; }

		/// <summary>
		/// Gets the items count.
		/// </summary>
		/// <value>The items count.</value>
		public int ItemsCount { get; protected set; }
		#endregion

		#region Methods
		/// <summary>
		/// Creates the items.
		/// </summary>
		public abstract void CreateItems ();

		/// <summary>
		/// Gets the item.
		/// </summary>
		/// <returns>The item.</returns>
		public abstract object GetItem ();

		/// <summary>
		/// Releases the item.
		/// </summary>
		/// <param name="item">Item.</param>
		public abstract void ReleaseItem (object item);

		/// <summary>
		/// Releases all items that fit in release filter specified.
		/// </summary>
		/// <param name="releaseFilter">Release filter.</param>
		public abstract void ReleaseAll (Func<object, bool> releaseFilter);
		#endregion
	}
}