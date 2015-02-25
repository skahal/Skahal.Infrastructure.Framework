#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// Defines a interface for am UI manager.
	/// </summary>
	public interface ISGNUIManager
	{
		#region Properties
		/// <summary>
		/// Gets or sets a value indicating whether this
		/// <see cref="Skahal.Infrastructure.Framework.SocialGamingNetwork.ISGNUIManager"/> allow notifications.
		/// </summary>
		/// <value><c>true</c> if allow notifications; otherwise, <c>false</c>.</value>
		bool AllowNotifications
		{
			get;
			set;
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Shows the leaderboards.
		/// </summary>
		void ShowLeaderboards();

		/// <summary>
		/// Shows the achievements.
		/// </summary>
		void ShowAchievements();
		#endregion
	}
}