#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// Defines a interface for a SGN leaderboard manager.
	/// </summary>
	public interface ISGNLeaderboardManager
	{
		#region Events
		/// <summary>
		/// Occurs when leaderboard updating.
		/// </summary>
		event EventHandler<LeaderboardUpdatingEventArgs> LeaderboardUpdating;
		
		/// <summary>
		/// Occurs when leaderboard updating failed.
		/// </summary>
		event EventHandler<LeaderboardUpdatingFailedEventArgs> LeaderboardUpdatingFailed;
		
		/// <summary>
		/// Occurs when leaderboard updated.
		/// </summary>
		event EventHandler<LeaderboardUpdatedEventArgs> LeaderboardUpdated;
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets a value indicating whether leadearboards are supported.
		/// </summary>
		/// <value>
		/// <c>true</c> if supported; otherwise, <c>false</c>.
		/// </value>
		bool Supported { get; }
		#endregion
		
		#region Methods
		/// <summary>
		/// Updates the leaderboard.
		/// </summary>
		/// <param name='leaderboard'>
		/// Leaderboard.
		/// </param>
		void UpdateLeaderboard(SGNLeaderboard leaderboard);
		
		/// <summary>
		/// Gets the player score.
		/// </summary>
		/// <param name='leaderboard'>
		/// Leaderboard.
		/// </param>
		/// <param name='player'>
		/// Player.
		/// </param>
		/// <param name='scoreReceived'>
		/// Score received.
		/// </param>
		void GetPlayerScore(SGNLeaderboard leaderboard, SGNPlayer player, Action<int> scoreReceived);
		
		/// <summary>
		/// Gets the player rank.
		/// </summary>
		/// <param name='leaderboard'>
		/// Leaderboard.
		/// </param>
		/// <param name='player'>
		/// Player.
		/// </param>
		/// <param name='rankReceived'>
		/// Rank received.
		/// </param>
		void GetPlayerRank(SGNLeaderboard leaderboard, SGNPlayer player, Action<int> rankReceived);
		#endregion
	}
}