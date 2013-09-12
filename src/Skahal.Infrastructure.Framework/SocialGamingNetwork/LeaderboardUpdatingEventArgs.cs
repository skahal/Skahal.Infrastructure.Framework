#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// Leaderboard updating event arguments.
	/// </summary>
	public class LeaderboardUpdatingEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.SocialGamingNetwork.LeaderboardUpdatingEventArgs"/> class.
		/// </summary>
		/// <param name="leaderboard">Leaderboard.</param>
		public LeaderboardUpdatingEventArgs(SGNLeaderboard leaderboard)
		{
			Leaderboard = leaderboard;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the leaderboard.
		/// </summary>
		/// <value>The leaderboard.</value>
		public SGNLeaderboard Leaderboard
		{
			get; 
			private set;
		}
		#endregion
	}
}