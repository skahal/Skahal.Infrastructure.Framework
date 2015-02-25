#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{	
	/// <summary>
	/// Achievement updated event arguments.
	/// </summary>
	public class AchievementUpdatedEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.AchievementUpdatedEventArgs"/> class.
		/// </summary>
		/// <param name="achievement">Achievement.</param>
		public AchievementUpdatedEventArgs(SGNAchievement achievement)
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