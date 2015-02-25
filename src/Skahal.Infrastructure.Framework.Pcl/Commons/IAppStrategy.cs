using System;

namespace Skahal.Infrastructure.Framework.Commons
{
	/// <summary>
	/// Defines an interface for a strategy to expose platform specific app events and operations.
	/// </summary>
	public interface IAppStrategy
	{
		#region Events
		/// <summary>
		/// Occurs when application has started.
		/// </summary>
		event EventHandler Started;

		/// <summary>
		/// Occurs when applications gos to background.
		/// </summary>
		event EventHandler BackgroundBegin;

		/// <summary>
		/// Occurs when application come back to foreground.
		/// </summary>
		event EventHandler ForegroundBegin;

		/// <summary>
		/// Occurs when application has been exited.
		/// </summary>
		event EventHandler Exited;
		#endregion
	}
}

