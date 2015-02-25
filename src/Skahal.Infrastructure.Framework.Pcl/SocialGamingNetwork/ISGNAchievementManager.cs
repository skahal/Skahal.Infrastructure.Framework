#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// Defines a interface for a SGN achievement manager.
	/// </summary>
	public interface ISGNAchievementManager
	{
		#region Events
		/// <summary>
		/// Occurs when achievement unlocked.
		/// </summary>
		event EventHandler<AchievementUnlockedEventArgs> AchievementUnlocked;
		
		/// <summary>
		/// Occurs when achievements refreshed.
		/// </summary>
		event EventHandler<AchievementsRefreshedEventArgs> AchievementsRefreshed;
		
		/// <summary>
		/// Occurs when achievement updating.
		/// </summary>
		event EventHandler<AchievementUpdatingEventArgs> AchievementUpdating;
		
		/// <summary>
		/// Occurs when achievement updating failed.
		/// </summary>
		event EventHandler<AchievementUpdatingFailedEventArgs> AchievementUpdatingFailed;
		
		/// <summary>
		/// Occurs when achievement updated.
		/// </summary>
		event EventHandler<AchievementUpdatedEventArgs> AchievementUpdated;
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets a value indicating whether achievements are supported.
		/// </summary>
		/// <value>
		/// <c>true</c> if supported; otherwise, <c>false</c>.
		/// </value>
		bool Supported { get; }
		#endregion
		
		#region Methods
		/// <summary>
		/// Updates the achievement.
		/// </summary>
		/// <param name='achievement'>
		/// Achievement.
		/// </param>
		void UpdateAchievement(SGNAchievement achievement);
		
		/// <summary>
		/// Resets the achievements.
		/// </summary>
		void ResetAchievements();
		
		/// <summary>
		/// Refreshs the achievements.
		/// </summary>
		void RefreshAchievements();
		#endregion
	}
}