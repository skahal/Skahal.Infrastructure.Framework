#region Usings
using System;
using Skahal.Infrastructure.Framework.Commons;
using System.Collections.Generic;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork.Local
{
	/// <summary>
	/// A local SGN leaderboard manager.
	/// </summary>
	public class SHLocalSGNLeaderboardManager : ISGNLeaderboardManager
	{
		#region ISGNLeaderboardManager implementation
		/// <summary>
		/// Gets a value indicating whether leadearboards are supported.
		/// </summary>
		/// <value>
		/// <c>true</c> if supported; otherwise, <c>false</c>.
		/// </value>
		public bool Supported { get { return false; } }
		
		/// <summary>
		/// Occurs when leaderboard updating.
		/// </summary>
		public event EventHandler<LeaderboardUpdatingEventArgs> LeaderboardUpdating;
		
		/// <summary>
		/// Occurs when leaderboard updating failed.
		/// </summary>
		public event EventHandler<LeaderboardUpdatingFailedEventArgs> LeaderboardUpdatingFailed;
		
		/// <summary>
		/// Occurs when leaderboard updated.
		/// </summary>
		public event EventHandler<LeaderboardUpdatedEventArgs> LeaderboardUpdated;
		
		/// <summary>
		/// Updates the leaderboard.
		/// </summary>
		/// <param name='leaderboard'>
		/// Leaderboard.
		/// </param>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void UpdateLeaderboard (SGNLeaderboard leaderboard)
		{
			throw new NotImplementedException ();
		}
		
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
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void GetPlayerScore (SGNLeaderboard leaderboard, SGNPlayer player, Action<int> scoreReceived)
		{
			throw new NotImplementedException ();
		}
		
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
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void GetPlayerRank(SGNLeaderboard leaderboard, SGNPlayer player, Action<int> rankReceived)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}