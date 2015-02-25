#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// Activity opponents refreshed event arguments.
	/// </summary>
	public class ActivityOpponentsRefreshedEventArgs : EventArgs
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.SocialGamingNetwork.ActivityOpponentsRefreshedEventArgs"/> class.
		/// </summary>
		/// <param name="activityOpponentsCount">Activity opponents count.</param>
		public ActivityOpponentsRefreshedEventArgs(int activityOpponentsCount)
		{
			ActivityOpponentsCount = activityOpponentsCount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the activity opponents count.
		/// </summary>
		/// <value>The activity opponents count.</value>
		public int ActivityOpponentsCount
		{
			get;
			private set;
		}
		#endregion
	}
}