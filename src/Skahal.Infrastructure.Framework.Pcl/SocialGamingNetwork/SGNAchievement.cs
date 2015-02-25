#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Defines an achievement.
	/// </summary>
	public class SGNAchievement
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNAchievement"/> class.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public SGNAchievement(string id)
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
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the percent.
		/// </summary>
		/// <value>The percent.</value>
		public float Percent { get; set; }
		#endregion
		
		#region Methods
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNAchievement"/>.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNAchievement"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNAchievement"/>; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var achievement = obj as SGNAchievement;
			
			if (obj == null)
			{
				return false;
			}
			
			return achievement.ID.Equals(ID);
		}
	
		/// <summary>
		/// Serves as a hash function for a <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNAchievement"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNAchievement"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNAchievement"/>.</returns>
		public override string ToString()
		{
			return string.Format("[SGNAchievement: ID={0}, Name={1}, Percent={2}]", ID, Name, Percent);
		}
		#endregion
	}
}