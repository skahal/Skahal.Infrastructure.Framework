#region Usings
using System;
using Skahal.Infrastructure.Framework.PCL.Logging;
using System.Diagnostics;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork
{	
	/// <summary>
	/// Social Gaming Network service.
	/// </summary>
	public static class SGNService
	{
		#region Fields
		private static ISGNFactory s_factory;
		private static SGNReliableDataManager s_reliableDataManager; 
		#endregion
		
		#region Methods
		/// <summary>
		/// Initialize the specified factory.
		/// </summary>
		/// <param name="factory">Factory.</param>
		public static void Initialize (ISGNFactory factory)
		{
			if (!Initialized)
			{
				s_factory = factory;
				PlayerManager = factory.CreatePlayerManager ();
				
				MultiplayerManager = factory.CreateMultiplayerManager ();
				
				if(MultiplayerManager.Supported)
				{
					MultiplayerManager.Initialize ();
				}
				
				VoiceChatManager = factory.CreateVoiceChatManager ();
				LeaderboardManager = factory.CreateLeaderboardManager ();
				AchievementManager = factory.CreateAchievementManager ();
			
				UIManager = factory.CreateUIManager ();
			
				
				s_reliableDataManager = new SGNReliableDataManager();
				s_reliableDataManager.Initialize();
				
				PlayerManager.Login ();
				
				Initialized = true;
			}
			else
			{
				LogService.Error (@"SGN: the ISGNFactory can be set only one time. The current call to SetFactory with '{0}' is trying to overwrite the curent factory '{1}'.", factory, s_factory);
			}
		}	
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets a value indicating whether this <see cref="Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.SGNService"/>
		/// is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		public static bool Initialized { get; private set; }

		/// <summary>
		/// Gets the player manager.
		/// </summary>
		/// <value>The player manager.</value>
		public static ISGNPlayerManager PlayerManager { get; private set; }

		/// <summary>
		/// Gets the multiplayer manager.
		/// </summary>
		/// <value>The multiplayer manager.</value>
		public static ISGNMultiplayerManager MultiplayerManager { get; private set; }

		/// <summary>
		/// Gets the voice chat manager.
		/// </summary>
		/// <value>The voice chat manager.</value>
		public static ISGNVoiceChatManager VoiceChatManager { get; private set; }

		/// <summary>
		/// Gets the user interface manager.
		/// </summary>
		/// <value>The user interface manager.</value>
		public static ISGNUIManager UIManager { get; private set; }

		/// <summary>
		/// Gets the leaderboard manager.
		/// </summary>
		/// <value>The leaderboard manager.</value>
		public static ISGNLeaderboardManager LeaderboardManager { get; private set; }

		/// <summary>
		/// Gets the achievement manager.
		/// </summary>
		/// <value>The achievement manager.</value>
		public static ISGNAchievementManager AchievementManager { get; private set; }
		#endregion
	}
}