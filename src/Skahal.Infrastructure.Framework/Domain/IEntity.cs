namespace Skahal.Infrastructure.Framework.Domain
{
	/// <summary>
	/// Defines a basic interface for a domain entity.
	/// </summary>
	public interface IEntity<TKey>
	{
		#region Properties
		/// <summary>
		/// Gets the id.
		/// </summary>
		TKey Key { get; set; }
		#endregion
	}
}
