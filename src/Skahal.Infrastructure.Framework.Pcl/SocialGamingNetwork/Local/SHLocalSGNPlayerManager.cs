#region Usings
using System;
using Skahal.Infrastructure.Framework.PCL.Commons;
using Skahal.Infrastructure.Framework.PCL.People;


#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.Local
{
	/// <summary>
	/// A local SGN player manager.
	/// </summary>
	public class SHLocalSGNPlayerManager : ISGNPlayerManager
	{
		#region Events
		/// <summary>
		/// Occurs when logged in.
		/// </summary>
		public event EventHandler<PlayerLoggedInEventArgs> LoggedIn;
		#endregion
		
		#region Constants
		/// <summary>
		/// Key used to reference player id on PlayerPrefs.
		/// </summary>
		private const string PlayerIdPrefsKey = "SHLocalSGNPlayerManager_PlayerId";
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the player.
		/// </summary>
		/// <value>
		/// The player.
		/// </value>
		public SGNPlayer Player { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the player is 'logged'.
		/// </summary>
		/// <value>
		/// <c>true</c> if the player is logged; otherwise, <c>false</c>.
		/// </value>
		public bool IsLogged { get; private set; }
		
		/// <summary>
		/// Gets the player identifier.
		/// </summary>
		/// <value>
		/// The player identifier.
		/// </value>
		private string PlayerId {
			get {
				if (!UserService.HasPreference (PlayerIdPrefsKey))
				{
					UserService.SetPreference(PlayerIdPrefsKey, Guid.NewGuid ().ToString ());
				}
				
				return UserService.GetPreference(PlayerIdPrefsKey).ToString();
			}
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Realizes the player 'login'.
		/// </summary>
		public void Login ()
		{
			Player = new SGNPlayer (PlayerId);
			IsLogged = true;
			LoggedIn.Raise(this, new PlayerLoggedInEventArgs(Player));
		}
		#endregion
	}
}
