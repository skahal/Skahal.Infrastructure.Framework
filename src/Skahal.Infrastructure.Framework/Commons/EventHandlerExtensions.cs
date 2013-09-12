#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.Commons
{
	/// <summary>
	/// Extensions methods for EventHandler.
	/// </summary>
	public static class EventHandlerExtensions
	{
		#region Methods
		/// <summary>
		/// Raise event.
		/// </summary>
		/// <param name='handler'>
		/// Handler.
		/// </param>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		public static bool Raise (this EventHandler handler, object sender)
		{
			if (handler != null)
			{
				handler (sender, EventArgs.Empty);
				return true;
			}

			return false;
		}
		
		/// <summary>
		/// Raise the event.
		/// </summary>
		/// <param name='handler'>
		/// Handler.
		/// </param>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// E.
		/// </param>
		/// <typeparam name='TEventArgs'>
		/// The 1st type parameter.
		/// </typeparam>
		public static bool Raise<TEventArgs> (this EventHandler<TEventArgs> handler, object sender, TEventArgs e) 
			where TEventArgs : EventArgs
		{
			if (handler != null) {
				handler (sender, e);
				return true;
			}

			return false;
		}
		#endregion
	}
}