using System;
using System.Linq;
using Skahal.Infrastructure.Framework.Logging;
using Skahal.Infrastructure.Framework.Repositories;

namespace Skahal.Infrastructure.Framework.People
{
	/// <summary>
	/// Infrastructure framework user service.
	/// </summary>
	public static class UserService
	{
		#region Fields
		private static IUserRepository s_repository;
		private static IUnitOfWork<string> s_unitOfWork;
		private static User s_currentUser;
		#endregion

		#region Methods
		/// <summary>
		/// Initialize the services.
		/// </summary>
		/// <param name="userRepository">User repository.</param>
		public static void Initialize (IUserRepository userRepository)
		{
			s_unitOfWork = new MemoryUnitOfWork<string> ();
			s_repository = userRepository;
			s_repository.SetUnitOfWork (s_unitOfWork);
		}

	 	/// <summary>
		/// Gets the current user.
		/// </summary>
		/// <returns>The current user.</returns>
		public static User GetCurrentUser()
		{
			if(s_currentUser == null)
			{
				LogService.Debug("GetCurrentUser: there is no current user. Looking for the first one available on repository...");
				s_currentUser = s_repository.FindAll ((u) => true).FirstOrDefault();

				if(s_currentUser == null)
				{
					LogService.Debug("GetCurrentUser: there is no users on repository. Creating the first one and marking as current..");
					s_currentUser = new User();
					s_currentUser.Name = "Default user";
					s_repository.Add(s_currentUser);
					s_unitOfWork.Commit ();
				}
				else {
					LogService.Debug("GetCurrentUser: first user found on repository: {0}-{1}.", s_currentUser.Key, s_currentUser.Name);
				}
			}

			return s_currentUser;
		}

		/// <summary>
		/// Sets the current user.
		/// </summary>
		/// <param name="user">User.</param>
		public static void SaveCurrentUser(User user)
		{
			s_currentUser = user;

			var oldUser = s_repository.FindAll(u => u.Key == user.Key).FirstOrDefault();
			
			if(oldUser == null)
			{
				LogService.Debug("SaveCurrentUser: creating the current user: {0}-{1}", user.Key, user.Name);
				s_repository.Add(user);
			}
			else 
			{
				LogService.Debug("SaveCurrentUser: updating the current user: {0}-{1}", user.Key, user.Name);
				s_repository[user.Key] = user;
			}

			s_unitOfWork.Commit ();
		}

		/// <summary>
		/// Determines if the current user has the preference.
		/// </summary>
		/// <param name="name">Name.</param>
		public static bool HasPreference(string name)
		{
			return GetCurrentUser ().HasPreference (name);
		}

		/// <summary>
		/// Sets the preference for current user.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="value">Value.</param>
		public static bool SetPreference(string name, object value)
		{
			return GetCurrentUser().SetPreference(name, value);
		}

		/// <summary>
		/// Gets the preference for current user.
		/// </summary>
		/// <returns>The preference.</returns>
		/// <param name="name">Name.</param>
		public static UserPreference GetPreference(string name)
		{
			return GetCurrentUser().GetPreference(name);
		}

		/// <summary>
		/// Gets the preference value for current user.
		/// </summary>
		/// <returns>The preference value.</returns>
		/// <param name="name">Name.</param>
		public static TValue GetPreferenceValue<TValue>(string name)
		{
			return GetCurrentUser().GetPreferenceValue<TValue>(name);
		}

		/// <summary>
		/// Gets the preference for current user.
		/// </summary>
		/// <returns>The preference.</returns>
		/// <param name="name">Name.</param>
		/// <param name="defaultValue">A default value in the case the preference does not exists.</param> 
		public static UserPreference GetPreference(string name, object defaultValue)
		{
			return GetCurrentUser().GetPreference(name, defaultValue);
		}

		/// <summary>
		/// Gets the preference value for current user.
		/// </summary>
		/// <returns>The preference value.</returns>
		/// <param name="name">Name.</param>
		/// <param name="defaultValue">A default value in the case the preference does not exists.</param> 
		public static TValue GetPreferenceValue<TValue>(string name, TValue defaultValue)
		{
			return GetCurrentUser().GetPreferenceValue<TValue>(name, defaultValue);
		}
		#endregion
	}
}

