using System;
using HelperSharp;

namespace Skahal.Infrastructure.Framework.Commons
{
	/// <summary>
	/// Represents the application current running.
	/// </summary>
	public static class AppService
	{
		#region Events
		/// <summary>
		/// Occurs when application has started.
		/// </summary>
		public static event EventHandler Started;

		/// <summary>
		/// Occurs when applications gos to background.
		/// </summary>
		public static event EventHandler BackgroundBegin;

		/// <summary>
		/// Occurs when application come back to foreground.
		/// </summary>
		public static event EventHandler ForegroundBegin;

		/// <summary>
		/// Occurs when application has been exited.
		/// </summary>
		public static event EventHandler Exited;
		#endregion

		#region Fields
		private static IAppStrategy s_strategy;
		#endregion

		#region Methods
		/// <summary>
		/// Initialize the service.
		/// </summary>
		/// <param name="strategy">Strategy.</param>
		public static void Initialize(IAppStrategy strategy)
		{
			ExceptionHelper.ThrowIfNull ("strategy", strategy);
			s_strategy = strategy;

			s_strategy.BackgroundBegin += delegate {
				BackgroundBegin.Raise (typeof(AppService));
			};

			s_strategy.Exited += delegate {
				Exited.Raise (typeof(AppService));
			};

			s_strategy.ForegroundBegin += delegate {
				ForegroundBegin.Raise (typeof(AppService));
			};

			s_strategy.Started += delegate {
				Started.Raise (typeof(AppService));
			};
		}
		#endregion
	}
}

