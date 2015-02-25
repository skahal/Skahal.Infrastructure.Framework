#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Opponent disconnected event arguments.
	/// </summary>
	public class OpponentDisconnectedEventArgs : System.EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.OpponentDisconnectedEventArgs"/> class.
		/// </summary>
		/// <param name="opponent">Opponent.</param>
		public OpponentDisconnectedEventArgs(SGNPlayer opponent)
		{
			Opponent = opponent;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the opponent.
		/// </summary>
		/// <value>The opponent.</value>
		public SGNPlayer Opponent
		{
			get;
			private set;
		}
		#endregion
	}
}