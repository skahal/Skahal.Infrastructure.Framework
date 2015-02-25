#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// Defines a player.
	/// </summary>
	public class SGNPlayer
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.SocialGamingNetwork.SGNPlayer"/> class.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public SGNPlayer(string id)
		{
			ID = id;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the ID.
		/// </summary>
		/// <value>The I.</value>
		public string ID { get; private set;}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set;}
		#endregion
		
		#region Methods
		/// <summary>
		/// Serves as a hash function for a <see cref="Skahal.Infrastructure.Framework.SocialGamingNetwork.SGNPlayer"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Skahal.Infrastructure.Framework.SocialGamingNetwork.SGNPlayer"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Skahal.Infrastructure.Framework.SocialGamingNetwork.SGNPlayer"/>.</returns>
		public override string ToString()
		{
			return string.Format("[SGNPlayer: ID={0}, Name={1}]", ID, Name);
		}
		#endregion
	}
}