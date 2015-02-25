#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Opponent connected event arguments.
	/// </summary>
	public class OpponentConnectedEventArgs : System.EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.OpponentConnectedEventArgs"/> class.
		/// </summary>
		/// <param name="opponent">Opponent.</param>
		public OpponentConnectedEventArgs(SGNPlayer opponent)
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