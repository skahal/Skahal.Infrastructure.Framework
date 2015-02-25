#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{
	/// <summary>
	/// Defines a interface for a player manager.
	/// </summary>
	public interface ISGNPlayerManager
	{
		#region Events
		/// <summary>
		/// Occurs when logged in.
		/// </summary>
		event EventHandler<PlayerLoggedInEventArgs> LoggedIn;
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the player.
		/// </summary>
		/// <value>The player.</value>
		SGNPlayer Player { get;}

		/// <summary>
		/// Gets a value indicating whether the player is logged.
		/// </summary>
		/// <value><c>true</c> if this instance is logged; otherwise, <c>false</c>.</value>
		bool IsLogged {get;}
		#endregion
		
		#region Methods
		/// <summary>
		/// Log in the player.
		/// </summary>
		void Login();
		#endregion
	}
}