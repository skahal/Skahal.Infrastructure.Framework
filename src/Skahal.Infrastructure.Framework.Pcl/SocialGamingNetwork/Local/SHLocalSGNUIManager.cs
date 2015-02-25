#region Usings
using System;
using Skahal.Infrastructure.Framework.PCL.Commons;
using System.Collections.Generic;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.Local
{
	/// <summary>
	/// A local SGN UI manager.
	/// </summary>
	public class SHLocalSGNUIManager : ISGNUIManager
	{
		#region ISGNUIManager implementation
		/// <summary>
		/// Shows the leaderboards.
		/// </summary>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void ShowLeaderboards ()
		{
			throw new NotImplementedException ();
		}
		
		/// <summary>
		/// Shows the achievements.
		/// </summary>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void ShowAchievements ()
		{
			throw new NotImplementedException ();
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.Local.SHLocalSGNUIManager"/>
		/// allow notifications.
		/// </summary>
		/// <value>
		/// <c>true</c> if allow notifications; otherwise, <c>false</c>.
		/// </value>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public bool AllowNotifications {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		#endregion
	}
}