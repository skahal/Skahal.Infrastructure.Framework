#region Usings
using System;
using System.Collections.Generic;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// Defines a interface for a multiplayer manager.
	/// </summary>
	public interface ISGNMultiplayerManager
	{
		#region Events
		/// <summary>
		/// Occurs when opponent connected.
		/// </summary>
		event EventHandler<OpponentConnectedEventArgs> OpponentConnected;

		/// <summary>
		/// Occurs when opponent disconnected.
		/// </summary>
		event EventHandler<OpponentDisconnectedEventArgs> OpponentDisconnected;

		/// <summary>
		/// Occurs when invite received.
		/// </summary>
		event EventHandler<InviteReceivedEventArgs> InviteReceived;

		/// <summary>
		/// Occurs when activity opponents refreshed.
		/// </summary>
		event EventHandler<ActivityOpponentsRefreshedEventArgs> ActivityOpponentsRefreshed;
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets a value indicating whethe multiplayer is supported.
		/// </summary>
		/// <value><c>true</c> if supported; otherwise, <c>false</c>.</value>
		bool Supported { get; }

		/// <summary>
		/// Gets a value indicating whether this instance is host.
		/// </summary>
		/// <value><c>true</c> if this instance is host; otherwise, <c>false</c>.</value>
		bool IsHost { get; }

		/// <summary>
		/// Gets the opponents.
		/// </summary>
		/// <value>The opponents.</value>
		IList<SGNPlayer> Opponents { get; }
		#endregion
	
		#region Methods
		/// <summary>
		/// Initialize this instance.
		/// </summary>
		void Initialize();

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="messageName">Message name.</param>
		/// <param name="messageValue">Message value.</param>
		void SendMessage(string messageName, string messageValue);

		/// <summary>
		/// Closes the session.
		/// </summary>
		void CloseSession();

		/// <summary>
		/// Shows the available opponents.
		/// </summary>
		void ShowAvailableOpponents();

		/// <summary>
		/// Refreshs the activity opponents.
		/// </summary>
		void RefreshActivityOpponents();
		#endregion
	}
}