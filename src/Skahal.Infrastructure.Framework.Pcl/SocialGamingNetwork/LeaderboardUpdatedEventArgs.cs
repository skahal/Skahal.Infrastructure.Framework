#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Leaderboard updated event arguments.
	/// </summary>
	public class LeaderboardUpdatedEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.LeaderboardUpdatedEventArgs"/> class.
		/// </summary>
		/// <param name="leaderboard">Leaderboard.</param>
		public LeaderboardUpdatedEventArgs(SGNLeaderboard leaderboard)
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