#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.SocialGamingNetwork
{
	/// <summary>
	/// Defines a interface for a voice chat manager.
	/// </summary>
	public interface ISGNVoiceChatManager
	{
		/// <summary>
		/// Gets a value indicating whether voice chat is supported.
		/// </summary>
		/// <value><c>true</c> if supported; otherwise, <c>false</c>.</value>
		bool Supported { get; }

		/// <summary>
		/// Gets or sets a value indicating whether voice chat is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		bool Enabled { get; set; }
	}
}