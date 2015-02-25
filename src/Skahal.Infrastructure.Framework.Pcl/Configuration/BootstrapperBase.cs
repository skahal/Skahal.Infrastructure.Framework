#region Usings
using System;
using Skahal.Infrastructure.Framework.Logging;
using Skahal.Infrastructure.Framework.Commons;
using Skahal.Infrastructure.Framework.People;
using Skahal.Infrastructure.Framework.Globalization;
#endregion

namespace Skahal.Infrastructure.Framework.Configuration
{
	/// <summary>
	/// The framework bootstrapper.
	/// </summary>
	public abstract class BootstrapperBase
	{
		#region Fields
		private static bool s_alreadyBooted;
		#endregion

		#region Methods
		/// <summary>
		/// Creates the log strategy.
		/// </summary>
		/// <returns>The log strategy.</returns>
		protected abstract ILogStrategy CreateLogStrategy ();

		/// <summary>
		/// Creates the user repository.
		/// </summary>
		/// <returns>The user repository.</returns>
		protected abstract IUserRepository CreateUserRepository ();

		/// <summary>
		/// Creates the app strategy.
		/// </summary>
		/// <returns>The app strategy.</returns>
		protected abstract IAppStrategy CreateAppStrategy ();

		/// <summary>
		/// Creates the globalization label repository.
		/// </summary>
		/// <returns>The globalization label repository.</returns>
		protected abstract IGlobalizationLabelRepository CreateGlobalizationLabelRepository ();

		/// <summary>
		/// Setup this instance.
		/// </summary>
		public bool Setup()
		{
			if(!s_alreadyBooted)
			{	
				LogService.Debug("Bootstrapper '{0}' setup...", GetType().Name);

				InitializeService ("LogStrategy", CreateLogStrategy(), LogService.Initialize);
				InitializeService ("AppStrategy", CreateAppStrategy(), AppService.Initialize);
				InitializeService ("UserRepository", CreateUserRepository(), UserService.Initialize);
				InitializeService ("GlobalizationLabelRepository", CreateGlobalizationLabelRepository(), GlobalizationService.Initialize);

				s_alreadyBooted = true;
				LogService.Debug("Bootstrapper '{0}' setup done.", GetType().Name);

				return true;
			}

			return false;
		}

		private static void InitializeService<TInitializeArg>(string initializeArgName, TInitializeArg initializeArg, Action<TInitializeArg> initializeAction)
		{
			if (initializeArg == null) {
				LogService.Warning ("{0} not defined on bootstrapper.", initializeArgName);
			} else {
				LogService.Debug ("'{0}' as {1}.", initializeArg.GetType ().Name, initializeArgName);
				initializeAction (initializeArg);
			}
		}
		#endregion
	}
}