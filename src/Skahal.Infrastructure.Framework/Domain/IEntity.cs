namespace Skahal.Infrastructure.Framework.Domain
{
	/// <summary>
	/// Defines a basic interface for a domain entity.
	/// </summary>
	public interface IEntity
	{
		#region Properties
		/// <summary>
		/// Gets the id.
		/// </summary>
		object Key { get; set; }
		#endregion
	}
}
