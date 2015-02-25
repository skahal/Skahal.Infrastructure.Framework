#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Achievement updating failed event arguments.
	/// </summary>
	public class AchievementUpdatingFailedEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.AchievementUpdatingFailedEventArgs"/> class.
		/// </summary>
		/// <param name="achievement">Achievement.</param>
		public AchievementUpdatingFailedEventArgs(SGNAchievement achievement)
		{
			Achievement = achievement;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the achievement.
		/// </summary>
		/// <value>The achievement.</value>
		public SGNAchievement Achievement
		{
			get;
			private set;
		}
		#endregion
	}
}