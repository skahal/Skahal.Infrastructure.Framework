#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// Player logged in event arguments.
	/// </summary>
	public class PlayerLoggedInEventArgs : System.EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.SocialGamingNetwork.PlayerLoggedInEventArgs"/> class.
		/// </summary>
		/// <param name="player">Player.</param>
		public PlayerLoggedInEventArgs(SGNPlayer player)
		{
			Player = player;	
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the player.
		/// </summary>
		/// <value>The player.</value>
		public SGNPlayer Player
		{
			get;
			private set;
		}
		#endregion
	}
}