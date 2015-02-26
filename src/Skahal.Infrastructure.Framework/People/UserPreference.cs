using System;

namespace Skahal.Infrastructure.Framework.People
{
	/// <summary>
	/// Represents an user preference.
	/// </summary>
	#if !PCL
	[Serializable] 
	#endif
	public class UserPreference
	{
		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public object Value { get; set; }
		#endregion
	}
}