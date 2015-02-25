#region Usings
using System.Collections;
#endregion

namespace Skahal.Infrastructure.Framework.Net.Messaging
{
	/// <summary>
	/// Message received event arguments.
	/// </summary>
	public class MessageEventArgs : System.EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.Net.Messaging.MessageEventArgs"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		public MessageEventArgs (Message message)
		{
			Message = message;
		}

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.Net.Messaging.MessageEventArgs"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="value">Value.</param>
		public MessageEventArgs (string name, string value) : this(new Message(name, value))
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the message.
		/// </summary>
		/// <value>The message.</value>
		public Message Message { get; private set; }
		#endregion
	}
}