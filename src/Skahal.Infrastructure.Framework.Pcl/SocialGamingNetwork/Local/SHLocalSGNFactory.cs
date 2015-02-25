#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.Local
{
	/// <summary>
	/// A local SGN factory.
	/// </summary>
	public class SHLocalSGNFactory : ISGNFactory
	{
		#region ISGNFactory implementation
		/// <summary>
		/// Creates the player manager.
		/// </summary>
		/// <returns>
		/// The player manager.
		/// </returns>
		public ISGNPlayerManager CreatePlayerManager ()
		{
			return new SHLocalSGNPlayerManager ();
		}
		
		/// <summary>
		/// Creates the multiplayer manager.
		/// </summary>
		/// <returns>
		/// The multiplayer manager.
		/// </returns>
		public ISGNMultiplayerManager CreateMultiplayerManager ()
		{
			return new SHLocalSGNMultiplayerManager ();
		}
		
		/// <summary>
		/// Creates the voice chat manager.
		/// </summary>
		/// <returns>
		/// The voice chat manager.
		/// </returns>
		public ISGNVoiceChatManager CreateVoiceChatManager ()
		{
			return new SHLocalSGNVoiceChatManager ();
		}
		
		/// <summary>
		/// Creates the user interface manager.
		/// </summary>
		/// <returns>
		/// The user interface manager.
		/// </returns>
		public ISGNUIManager CreateUIManager ()
		{
			return new SHLocalSGNUIManager ();
		}
		
		/// <summary>
		/// Creates the leaderboard manager.
		/// </summary>
		/// <returns>
		/// The leaderboard manager.
		/// </returns>
		public ISGNLeaderboardManager CreateLeaderboardManager ()
		{
			return new SHLocalSGNLeaderboardManager();
		}
		
		/// <summary>
		/// Creates the achievement manager.
		/// </summary>
		/// <returns>
		/// The achievement manager.
		/// </returns>
		public ISGNAchievementManager CreateAchievementManager ()
		{
			return new SHLocalSGNAchievementManager();
		}
		#endregion
	}
}