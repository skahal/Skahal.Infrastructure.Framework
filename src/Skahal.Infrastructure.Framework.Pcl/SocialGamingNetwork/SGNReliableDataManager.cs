#region Usings
using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Commons;
using System.Text;
using Skahal.Infrastructure.Framework.Logging;
using Skahal.Infrastructure.Framework.People;


#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// A manager for SGN (Social Game Network) that keeps data reliable and 
	/// guarantees that any local update will reach the SGN server.
	/// </summary>
	public class SGNReliableDataManager
	{
		#region Fields
		private List<SGNLeaderboard> m_pendingLeaderboardsUpdate;
		private List<SGNAchievement> m_pendingAchievementsUpdate;
		
		private SGNLeaderboard m_currentProcessingLeaderboard;
		private SGNAchievement m_currentProcessingAchievement;
		
		private bool m_pendingUpdatesRestored;
		#endregion
		
		#region Methods
		
		#region Life cycle
		/// <summary>
		/// Initialize this instance.
		/// </summary>
		public void Initialize()
		{
			m_pendingLeaderboardsUpdate = new List<SGNLeaderboard>();
			m_pendingAchievementsUpdate = new List<SGNAchievement>();
			
			// Player.
			SGNService.PlayerManager.LoggedIn += delegate(object sender, PlayerLoggedInEventArgs e) 
			{
				Log("User logged. Processing pending updates...");
				RestorePendingUpdates();
				ProcessPendingLeaderboardsUpdate();
				ProcessPendingAchievementsUpdate();
			};
			
			// Leaderboards.
			SGNService.LeaderboardManager.LeaderboardUpdating += delegate(object sender, LeaderboardUpdatingEventArgs e) 
			{
				AddPendingLeaderboardUpdate(e.Leaderboard);
			};
			
			SGNService.LeaderboardManager.LeaderboardUpdatingFailed += delegate(object sender, LeaderboardUpdatingFailedEventArgs e) 
			{
				m_currentProcessingLeaderboard = null; 
			};
			
			SGNService.LeaderboardManager.LeaderboardUpdated += delegate(object sender, LeaderboardUpdatedEventArgs e) 
			{
				RemovePendingLeaderboardUpdate(e.Leaderboard);
			};
			
			// Achievements.
			SGNService.AchievementManager.AchievementUpdating += delegate(object sender, AchievementUpdatingEventArgs e) 
			{ 
				AddPendingAchievementUpdate(e.Achievement); 
			};
			
			SGNService.AchievementManager.AchievementUpdatingFailed += delegate(object sender, AchievementUpdatingFailedEventArgs e) 
			{
				m_currentProcessingAchievement = null;
			};
			
			SGNService.AchievementManager.AchievementUpdated += delegate(object sender, AchievementUpdatedEventArgs e) 
			{
				RemovePendingAchievementUpdate(e.Achievement);
			};
			
			AppService.BackgroundBegin += delegate {
				SavePendingUpdates();
			};
		}
		
		#endregion
		
		#region Save/Restore pending upates
		string GetLeaderboardsPlayerPrefsKey()
		{
			return "SGNReliableDataManager_Leaderborads_" + SGNService.PlayerManager.Player.ID;
		}
		
		string GetAchievementsPlayerPrefsKey()
		{
			return "SGNReliableDataManager_Achievements" + SGNService.PlayerManager.Player.ID;
		}
		
		void SavePendingUpdates()
		{
			Log("Saving pending updates...");
			
			// Leaderboards.
			var data = new StringBuilder();
		
			foreach (var leaderboard in m_pendingLeaderboardsUpdate)
			{
				data.AppendFormat("{0}|{1};", leaderboard.ID, leaderboard.Score);
			}
			
			var serializableData = data.ToString();
			UserService.SetPreference(GetLeaderboardsPlayerPrefsKey(), serializableData);
			Log(serializableData);
			
			
			// Achievements.
			data = new StringBuilder();
			
			foreach (var achievement in m_pendingAchievementsUpdate)
			{
				data.AppendFormat("{0}|{1};", achievement.ID, achievement.Percent);
			}
			
			serializableData = data.ToString();
			UserService.SetPreference(GetAchievementsPlayerPrefsKey(), serializableData);
			Log(serializableData);
		}
		
		void RestorePendingUpdates()
		{
			if (m_pendingUpdatesRestored)
			{
				return;
			}
			
			// Leaderboards.
			var data = UserService.GetPreference(GetLeaderboardsPlayerPrefsKey(), "").Value.ToString();
			
			if (!String.IsNullOrEmpty(data))
			{
				var leaderboards = data.Split(';');
				
				foreach (var l in leaderboards)
				{
					var parts = l.Split('|');
					if (parts.Length == 2)
					{
						var leaderboard = new SGNLeaderboard(parts[0]);
						leaderboard.Score = Convert.ToInt64(parts[1]);
						AddPendingLeaderboardUpdate(leaderboard);
					}
				}
			}
			
			// Achievements.
			data = UserService.GetPreference(GetAchievementsPlayerPrefsKey(), "").ToString();
			
			if (!String.IsNullOrEmpty(data))
			{
				var achievements = data.Split(';');
				
				foreach (var l in achievements)
				{
					var parts = l.Split('|');
					
					if (parts.Length == 2)
					{
						var achievement = new SGNAchievement(parts[0]);
						achievement.Percent = Convert.ToSingle(parts[1]);
						m_pendingAchievementsUpdate.Add(achievement);
					}
				}
			}
			
			m_pendingUpdatesRestored = true;
		}
		#endregion
		
		#region Add/remove pending updates
		void AddPendingLeaderboardUpdate(SGNLeaderboard leaderboard)
		{
			lock (this)
			{
				Log("Adding leaderboard {0} as pending update...", leaderboard);
				
				if (m_pendingLeaderboardsUpdate.Contains(leaderboard))
				{
					m_pendingLeaderboardsUpdate.Remove(leaderboard);
				}
				
				m_pendingLeaderboardsUpdate.Add(leaderboard);
			}
		}
		
		void AddPendingAchievementUpdate(SGNAchievement achievement)
		{
			lock (this)
			{
				Log("Adding achievement {0} as pending update...", achievement);
				
				if (m_pendingAchievementsUpdate.Contains(achievement))
				{
					m_pendingAchievementsUpdate.Remove(achievement);
				}
				
				m_pendingAchievementsUpdate.Add(achievement);
			}
		}
		
		void RemovePendingLeaderboardUpdate(SGNLeaderboard leaderboard)
		{
			lock (this)
			{
				Log("Removing leaderboard {0} as pending update...", leaderboard);
				
				m_pendingLeaderboardsUpdate.Remove(leaderboard);
				
				if (leaderboard.Equals(m_currentProcessingLeaderboard))
				{
					m_currentProcessingLeaderboard = null;
				}
			}
		}
		
		void RemovePendingAchievementUpdate(SGNAchievement achievement)
		{
			lock (this)
			{
				Log("Removing achievement {0} as pending update...", achievement);
				
				m_pendingAchievementsUpdate.Remove(achievement);
				
				if (achievement.Equals(m_currentProcessingAchievement))
				{
					m_currentProcessingAchievement = null;
				}
			}
		}
		#endregion
		
		#region Process pending updates
		void ProcessPendingLeaderboardsUpdate()
		{
			lock (this)
			{
				var count = m_pendingLeaderboardsUpdate.Count;
				
				Log("There are {0} pending leaderboards update.", count);
				
				if (m_currentProcessingLeaderboard == null && count > 0)
				{
					m_currentProcessingLeaderboard = m_pendingLeaderboardsUpdate[0];
					
					Log("Updating pending leaderboard {0} update.", m_currentProcessingLeaderboard);
					
					SGNService.LeaderboardManager.UpdateLeaderboard(m_currentProcessingLeaderboard);
				}
			}
		}
		
		void ProcessPendingAchievementsUpdate()
		{
			lock (this)
			{
				var count = m_pendingAchievementsUpdate.Count;
				
				Log("There are {0} pending achievements update.", count);
				
				if (m_currentProcessingAchievement == null && count > 0)
				{
					m_currentProcessingAchievement = m_pendingAchievementsUpdate[0];
					
					Log("Updating pending achievement {0} update.", m_currentProcessingAchievement);
					
					SGNService.AchievementManager.UpdateAchievement(m_currentProcessingAchievement);
				}
			}
		}
		#endregion
		
		#region Log
		void Log (string message, params object[] args)
		{
			LogService.Debug ("[SGNReliableDataManager] " + message, args);
		}
		#endregion
		
		#endregion
	}
}