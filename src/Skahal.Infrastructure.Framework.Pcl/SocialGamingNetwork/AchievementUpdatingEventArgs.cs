#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Achievement updating event arguments.
	/// </summary>
	public class AchievementUpdatingEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.AchievementUpdatingEventArgs"/> class.
		/// </summary>
		/// <param name="achievement">Achievement.</param>
		public AchievementUpdatingEventArgs(SGNAchievement achievement)
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