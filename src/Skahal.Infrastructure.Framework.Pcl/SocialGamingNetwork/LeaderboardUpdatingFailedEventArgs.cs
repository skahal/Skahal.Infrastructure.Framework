#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Leaderboard updating failed event arguments.
	/// </summary>
	public class LeaderboardUpdatingFailedEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.LeaderboardUpdatingFailedEventArgs"/> class.
		/// </summary>
		/// <param name="leaderboard">Leaderboard.</param>
		public LeaderboardUpdatingFailedEventArgs(SGNLeaderboard leaderboard)
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