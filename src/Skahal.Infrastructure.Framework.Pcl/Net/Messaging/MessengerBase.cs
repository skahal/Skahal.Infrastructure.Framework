#region Usings
using System;
using Skahal.Infrastructure.Framework.Commons;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Logging;


#endregion

namespace Skahal.Infrastructure.Framework.Net.Messaging
{
	/// <summary>
	/// The base class for IMessenger's
	/// </summary>
	public abstract class MessengerBase : IMessenger
	{
		#region Fields
		/// <summary>
		/// The name of the disconnect message.
		/// </summary>
		private const string DisconnectMessageName = "__MESSENGERBASE__DISCONNECT__";

		/// <summary>
		/// The disconnect message quit value.
		/// </summary>
		private const string DisconnectMessageQuitValue = "__MESSENGERBASE__QUIT__";

		/// <summary>
		/// The messages received buffer.
		/// </summary>
		private Queue<MessageEventArgs> m_messagesReceivedBuffer = new Queue<MessageEventArgs>();
		private bool m_canReceiveMessages;
		#endregion
		
		#region Events
		/// <summary>
		/// Occurs when connected.
		/// </summary>
		public event EventHandler<ConnectedEventArgs> Connected;

		/// <summary>
		/// Occurs when message was sent.
		/// </summary>
		public event EventHandler<MessageEventArgs> MessageSent;

		/// <summary>
		/// Occurs when message received.
		/// </summary>
		public event EventHandler<MessageEventArgs> MessageReceived;

		/// <summary>
		/// Occurs when disconnected.
		/// </summary>
		public event EventHandler<DisconnectedEventArgs> Disconnected;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Net.Messaging.MessengerBase"/> class.
		/// </summary>
		protected MessengerBase ()
		{
			State = MessengerState.Disconnected;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the state.
		/// </summary>
		/// <value>The state.</value>
		public MessengerState State { get; internal protected set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance can receive messages.
		/// </summary>
		/// <value><c>true</c> if this instance can receive messages; otherwise, <c>false</c>.</value>
		public virtual bool CanReceiveMessages 
		{ 
			get { return m_canReceiveMessages; }
			set { 
				m_canReceiveMessages = value;

				if (m_canReceiveMessages) {
					while(m_messagesReceivedBuffer.Count > 0)
					{
						OnMessageReceived (m_messagesReceivedBuffer.Dequeue());
					}
				}
			}
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Connect the messenger.
		/// </summary>
		public abstract void Connect ();

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="name">The message name.</param>
		/// <param name="value">The message value.</param>
		public void SendMessage (string name, string value)
		{
			if(State == MessengerState.Connected)
			{
				LogService.Debug ("MessengerBase.SendMessage: {0} = {1}.", name, value);
				PerformSendMessage(name, value);
				MessageSent.Raise (this, new MessageEventArgs(name, value));
			}
		}

		/// <summary>
		/// Performs the send message.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="value">Value.</param>
		internal protected abstract void PerformSendMessage(string name, string value);

		/// <summary>
		/// Disconnect the messenger.
		/// </summary>
		public void Disconnect ()
		{
			SendMessage (DisconnectMessageName, DisconnectMessageQuitValue);	
			OnDisconnected(new DisconnectedEventArgs(DisconnectionReason.LocalQuit));
			PerformDisconnect ();
		}

		/// <summary>
		/// Performs the disconnect.
		/// </summary>
		internal protected abstract void PerformDisconnect();

		/// <summary>
		/// Raises the connected event.
		/// </summary>
		internal protected virtual void OnConnected (ConnectedEventArgs e)
		{
			if (State == MessengerState.Disconnected) {
				State = MessengerState.Connected;
				Connected.Raise (this, e);
			}
		}

		/// <summary>
		/// Raises the message received event.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		internal protected virtual void OnMessageReceived (MessageEventArgs e)
		{
			if (CanReceiveMessages) {
				var msg = e.Message;

				LogService.Debug ("MessengerBase.OnMessageReceived: {0} = {1}.", msg.Name, msg.Value);

				if (msg.Name.Equals (DisconnectMessageName)) {
					OnDisconnected (new DisconnectedEventArgs(DisconnectionReason.RemoteQuit));
				} else {
					MessageReceived.Raise (this, e);
				}
			} else {
				m_messagesReceivedBuffer.Enqueue (e);
			}
		}

		/// <summary>
		/// Raises the disconnected event.
		/// </summary>
		/// <param name="e">The event argumetns</param>    
		internal protected virtual void OnDisconnected (DisconnectedEventArgs e)
		{
			if (State == MessengerState.Connected) {
				State = MessengerState.Disconnected;
				Disconnected.Raise (this, e);
			}
		}
		#endregion
	}
}