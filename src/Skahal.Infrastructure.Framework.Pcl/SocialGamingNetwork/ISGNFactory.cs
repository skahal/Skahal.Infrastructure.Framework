#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Defines a interface for an abstract factory for Social Gaming Network.
	/// </summary>
	public interface ISGNFactory
	{	
		/// <summary>
		/// Creates the player manager.
		/// </summary>
		/// <returns>The player manager.</returns>
		ISGNPlayerManager CreatePlayerManager();

		/// <summary>
		/// Creates the multiplayer manager.
		/// </summary>
		/// <returns>The multiplayer manager.</returns>
		ISGNMultiplayerManager CreateMultiplayerManager();

		/// <summary>
		/// Creates the voice chat manager.
		/// </summary>
		/// <returns>The voice chat manager.</returns>
		ISGNVoiceChatManager CreateVoiceChatManager();

		/// <summary>
		/// Creates the user interface manager.
		/// </summary>
		/// <returns>The user interface manager.</returns>
		ISGNUIManager CreateUIManager();

		/// <summary>
		/// Creates the leaderboard manager.
		/// </summary>
		/// <returns>The leaderboard manager.</returns>
		ISGNLeaderboardManager CreateLeaderboardManager();

		/// <summary>
		/// Creates the achievement manager.
		/// </summary>
		/// <returns>The achievement manager.</returns>
		ISGNAchievementManager CreateAchievementManager();
	}
}