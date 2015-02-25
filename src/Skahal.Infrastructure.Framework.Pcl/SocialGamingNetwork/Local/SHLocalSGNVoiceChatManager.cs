#region Usings
using System;
using Skahal.Infrastructure.Framework.PCL.Commons;
using System.Collections.Generic;
#endregion

namespace Skahal.Infrastructure.Framework.PCL.SocialGamingNetwork.Local
{
	/// <summary>
	/// A local SGN voice chat manager.
	/// </summary>
	public class SHLocalSGNVoiceChatManager : ISGNVoiceChatManager
	{
		#region ISGNVoiceChatManager implementation
		/// <summary>
		/// Gets a value indicating whether voice chat is supported.
		/// </summary>
		/// <value>
		/// <c>true</c> if supported; otherwise, <c>false</c>.
		/// </value>
		public bool Supported { get { return false; } }
		
		/// <summary>
		/// Gets or sets a value indicating whether the voice chat is enabled.
		/// </summary>
		/// <value>
		/// <c>true</c> if enabled; otherwise, <c>false</c>.
		/// </value>
		/// <exception cref='NotImplementedException'>
		/// Is thrown when a requested operation is not implemented for a given type.
		/// </exception>
		public bool Enabled {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}
		#endregion
		
	}
}