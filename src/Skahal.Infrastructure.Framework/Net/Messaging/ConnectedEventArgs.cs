#region Usings
using System.Collections;
#endregion

namespace Skahal.Infrastructure.Framework.Net.Messaging
{
	/// <summary>
	/// Connected event arguments.
	/// </summary>
	public class ConnectedEventArgs : System.EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Net.Messaging.ConnectedEventArgs"/> class.
		/// </summary>
		/// <param name="connectionOrder">Connection order.</param>
		public ConnectedEventArgs (int connectionOrder)
		{
			ConnectionOrder = connectionOrder;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the connection order.
		/// </summary>
		/// <value>The connection order.</value>
		public int ConnectionOrder { get; private set; }
		#endregion
	}
}