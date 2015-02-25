#region Usings
using System;
using Skahal.Infrastructure.Framework.PCL.Commons;
using System.Collections.Generic;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.Local
{
	/// <summary>
	/// A local SGN multiplayer manager.
	/// </summary>
	public class SHLocalSGNMultiplayerManager : ISGNMultiplayerManager
	{
		#region ISGNMultiplayerManager implementation
		/// <summary>
		/// Gets a value indicating whether multiplayer is supported.
		/// is supported.
		/// </summary>
		/// <value>
		/// <c>true</c> if supported; otherwise, <c>false</c>.
		/// </value>
		public bool Supported { get { return false; } }
		
		/// <summary>
		/// Occurs when opponent connected.
		/// </summary>
		public event EventHandler<OpponentConnectedEventArgs> OpponentConnected;
		
		/// <summary>
		/// Occurs when opponent disconnected.
		/// </summary>
		public event EventHandler<OpponentDisconnectedEventArgs> OpponentDisconnected;
		
		/// <summary>
		/// Occurs when invite received.
		/// </summary>
		public event EventHandler<InviteReceivedEventArgs> InviteReceived;
		
		/// <summary>
		/// Occurs when activity opponents refreshed.
		/// </summary>
		public event EventHandler<ActivityOpponentsRefreshedEventArgs> ActivityOpponentsRefreshed;
		
		/// <summary>
		/// Initialize this instance.
		/// </summary>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void Initialize ()
		{
			throw new NotImplementedException ();
		}
		
		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name='messageName'>
		/// Message name.
		/// </param>
		/// <param name='messageValue'>
		/// Message value.
		/// </param>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void SendMessage (string messageName, string messageValue)
		{
			throw new NotImplementedException ();
		}
		
		/// <summary>
		/// Closes the session.
		/// </summary>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void CloseSession ()
		{
			throw new NotImplementedException ();
		}
		
		/// <summary>
		/// Shows the available opponents.
		/// </summary>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void ShowAvailableOpponents ()
		{
			throw new NotImplementedException ();
		}
		
		/// <summary>
		/// Refreshs the activity opponents.
		/// </summary>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public void RefreshActivityOpponents ()
		{
			throw new NotImplementedException ();
		}
		
		/// <summary>
		/// Gets a value indicating whether this instance is host.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is host; otherwise, <c>false</c>.
		/// </value>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public bool IsHost {
			get {
				throw new NotImplementedException ();
			}
		}
		
		/// <summary>
		/// Gets the opponents.
		/// </summary>
		/// <value>
		/// The opponents.
		/// </value>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public IList<SGNPlayer> Opponents {
			get {
				throw new NotImplementedException();
			}
		}
		#endregion
	}
}