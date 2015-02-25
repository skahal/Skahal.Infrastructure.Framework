#region Usings
using System.Collections;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.Net.Messaging
{
	/// <summary>
	/// Disconnected event arguments.
	/// </summary>
	public class DisconnectedEventArgs : System.EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.Net.Messaging.DisconnectedEventArgs"/> class.
		/// </summary>
		/// <param name="reason">Reason.</param>
		public DisconnectedEventArgs (DisconnectionReason reason)
		{
			Reason = reason;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the reason.
		/// </summary>
		/// <value>The reason.</value>
		public DisconnectionReason Reason { get; private set; }
		#endregion
	}
}