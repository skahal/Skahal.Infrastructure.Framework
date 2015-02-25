#region Usings
using System.Collections;
#endregion

namespace Skahal.Infrastructure.Framework.Net.Messaging
{
	/// <summary>
	/// Represents a message.
	/// </summary>
	public sealed class Message
	{		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Net.Messaging.Message"/> class.
		/// </summary>
		public Message ()
		{	
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Net.Messaging.Message"/> class.
		/// </summary>
		/// <param name="name">The message name.</param>
		/// <param name="value">The message value.</param>
		public Message (string name, string value)
		{
			Name = name;
			Value = value;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public string Value { get; set; }
		#endregion
	}
}