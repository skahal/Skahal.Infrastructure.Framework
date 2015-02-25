#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.Net.Messaging
{
	#region Enums
	/// <summary>
	/// Messenger state.
	/// </summary>
	public enum MessengerState
	{
		/// <summary>
		/// Messenger is connected.
		/// </summary>
		Connected,

		/// <summary>
		/// Messenger is disconnected
		/// </summary>
		Disconnected
	}

	/// <summary>
	/// Disconnection reason.
	/// </summary>
	public enum DisconnectionReason
	{
		/// <summary>
		/// Disconnected  by a connection lost.
		/// </summary>
		ConnectionLost,

		/// <summary>
		/// Disconnected by current messenger quit.
		/// </summary>
		LocalQuit,

		/// <summary>
		/// Disconnected by remote messenger quit.
		/// </summary>
		RemoteQuit
	}
	#endregion

	/// <summary>
	/// Defines the interface for a basic messenger.
	/// </summary>
	public interface IMessenger
	{
		#region Events
		/// <summary>
		/// Occurs when connected.
		/// </summary>
		event EventHandler<ConnectedEventArgs> Connected;

		/// <summary>
		/// Occurs when message was sent.
		/// </summary>
		event EventHandler<MessageEventArgs> MessageSent;

		/// <summary>
		/// Occurs when message received.
		/// </summary>
		event EventHandler<MessageEventArgs> MessageReceived;

		/// <summary>
		/// Occurs when disconnected.
		/// </summary>
		event EventHandler<DisconnectedEventArgs> Disconnected;
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the state.
		/// </summary>
		/// <value>The state.</value>
		MessengerState State { get; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance can receive messages.
		/// </summary>
		/// <value><c>true</c> if this instance can receive messages; otherwise, <c>false</c>.</value>
		bool CanReceiveMessages { get; set; }
		#endregion
		
		#region Methods
		/// <summary>
		/// Connect the messenger.
		/// </summary>
		void Connect ();

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="name">The message name.</param>
		/// <param name="value">The message value.</param>
		void SendMessage (string name, string value);

		/// <summary>
		/// Disconnect the messenger.
		/// </summary>
		void Disconnect();
		#endregion
	}
}