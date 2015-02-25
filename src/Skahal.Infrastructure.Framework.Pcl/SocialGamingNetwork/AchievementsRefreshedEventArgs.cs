#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Achievements refreshed event arguments.
	/// </summary>
	public class AchievementsRefreshedEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.AchievementsRefreshedEventArgs"/> class.
		/// </summary>
		/// <param name="achievements">Achievements.</param>
		public AchievementsRefreshedEventArgs(SGNAchievement[] achievements)
		{
			Achievements = achievements;	
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the achievements.
		/// </summary>
		/// <value>The achievements.</value>
		public SGNAchievement[] Achievements
		{
			get;
			private set;
		}
		#endregion
	}
}