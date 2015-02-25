#region Usings
using System;
using Skahal.Infrastructure.Framework.Commons;
using System.Collections.Generic;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork.Local
{
	/// <summary>
	/// A local SGN achievment manager.
	/// </summary>
	public class SHLocalSGNAchievementManager : ISGNAchievementManager
	{
		#region ISGNAchievementManager implementation
		/// <summary>
		/// Gets a value indicating whether achievements are supported.
		/// is supported.
		/// </summary>
		/// <value>
		/// <c>true</c> if supported; otherwise, <c>false</c>.
		/// </value>
		public bool Supported { get { return false; } }
		
		/// <summary>
		/// Occurs when achievement unlocked.
		/// </summary>
		public event EventHandler<AchievementUnlockedEventArgs> AchievementUnlocked;
		
		/// <summary>
		/// Occurs when achievements refreshed.
		/// </summary>
		public event EventHandler<AchievementsRefreshedEventArgs> AchievementsRefreshed;
		
		/// <summary>
		/// Occurs when achievement updating.
		/// </summary>
		public event EventHandler<AchievementUpdatingEventArgs> AchievementUpdating;
		
		/// <summary>
		/// Occurs when achievement updating failed.
		/// </summary>
		public event EventHandler<AchievementUpdatingFailedEventArgs> AchievementUpdatingFailed;
		
		/// <summary>
		/// Occurs when achievement updated.
		/// </summary>
		public event EventHandler<AchievementUpdatedEventArgs> AchievementUpdated;
		
		/// <summary>
		/// Updates the achievement.
		/// </summary>
		/// <param name='achievement'>
		/// Achievement.
		/// </param>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void UpdateAchievement (SGNAchievement achievement)
		{
			AchievementUpdated.Raise (this, new AchievementUpdatedEventArgs (achievement));

			if (achievement.Percent == 1) {
			
			}
		}
		
		/// <summary>
		/// Resets the achievements.
		/// </summary>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void ResetAchievements ()
		{
		}
		
		/// <summary>
		/// Refreshs the achievements.
		/// </summary>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void RefreshAchievements()
		{
			AchievementsRefreshed.Raise (this, new AchievementsRefreshedEventArgs (new SGNAchievement[0]));
		}
		#endregion
	}
}