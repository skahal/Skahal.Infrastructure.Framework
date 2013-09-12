//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2011 Skahal Studios

#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.Commons
{
	/// <summary>
	/// Defines an interface for a progress indicator.
	/// </summary>
	public interface IProgressIndicator
	{
		#region Events
		/// <summary>
		/// Occurs when progress changed.
		/// </summary>
		event EventHandler ProgressChanged;
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		string Title { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		string Message { get; set; }

		/// <summary>
		/// Gets or sets the progress percent.
		/// </summary>
		/// <value>The progress.</value>
		float Progress { get; set; }
		#endregion
	}
}