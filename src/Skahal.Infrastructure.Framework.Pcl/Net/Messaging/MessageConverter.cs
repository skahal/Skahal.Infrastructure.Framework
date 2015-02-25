#region Usings
using System.Collections;
using Skahal.Infrastructure.Framework.Net.Messaging;
#endregion

namespace Skahal.Infrastructure.Framework.Net.Messaging
{
	/// <summary>
	/// A message converter helper.
	/// </summary>
	internal static class MessageConverter
	{
		#region Constants
		/// <summary>
		/// The fields separator in a message value.
		/// </summary>
		private const string FieldsSeparator = "__MSG__";
		#endregion

		#region Methods
		/// <summary>
		/// Converts the message to a string.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="name">Name.</param>
		/// <param name="value">Value.</param>
		public static string ToString (string name, string value)
		{
			return string.Format ("{0}{1}{2}", name, FieldsSeparator, value);
		}

		/// <summary>
		/// Converts the string to a Message.
		/// </summary>
		/// <returns>The message.</returns>
		/// <param name="messageAsString">Message as string.</param>
		public static Message ToMessage (string messageAsString)
		{
			Message msg = null;

			if(messageAsString != null)
			{
				msg = new Message ();
				var parts = messageAsString.Split (new string[]{FieldsSeparator}, System.StringSplitOptions.None);
				
				msg.Name = parts [0];

				if(parts.Length > 1)
				{
					msg.Value = parts [1];
				}
			}

			return msg;
		}
		#endregion
	}
}