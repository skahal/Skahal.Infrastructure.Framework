#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// SGN leaderboard.
	/// </summary>
	public class SGNLeaderboard
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNLeaderboard"/> class.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public SGNLeaderboard(string id)
		{
			ID = id;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the ID.
		/// </summary>
		/// <value>The D..</value>
		public string ID { get; private set;}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the score.
		/// </summary>
		/// <value>The score.</value>
		public long Score { get; set; }
		#endregion
		
		#region Methods
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNLeaderboard"/>.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNLeaderboard"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNLeaderboard"/>; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var leaderboad = obj as SGNLeaderboard;
			
			if (obj == null)
			{
				return false;
			}
			
			return leaderboad.ID.Equals(ID);
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNLeaderboard"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNLeaderboard"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNLeaderboard"/>.</returns>
		public override string ToString()
		{
			return string.Format("[SGNLeaderboard: ID={0}, Name={1}, Score={2}]", ID, Name, Score);
		}
		#endregion
	}
}