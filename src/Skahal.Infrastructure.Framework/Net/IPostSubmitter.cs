//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2011 Skahal Studios
using System;
using System.Net;
using System.Collections.Specialized;

namespace Skahal.Infrastructure.Framework.Net
{
	/// <summary>
    /// Determines what type of post to perform.
    /// </summary>
    public enum PostType
    {
        /// <summary>
        /// Does a get against the source.
        /// </summary>
        Get,
        /// <summary>
        /// Does a post against the source.
        /// </summary>
        Post,

		/// <summary>
		/// Doeas a json get against the source.
		/// </summary>
		Json
    }

	/// <summary>
	/// Defines a interface for a post submitter.
	/// </summary>
	public interface IPostSubmitter
	{
		#region Properties
		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>The URL.</value>
		string Url { get; set; } 

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		PostType Type { get; set; }

		/// <summary>
		/// Gets or sets the post items.
		/// </summary>
		/// <value>The post items.</value>
		NameValueCollection PostItems { get; set; }

		/// <summary>
		/// Gets or sets the cookie container.
		/// </summary>
		/// <value>The cookie container.</value>
		CookieContainer CookieContainer { get; set; }

		/// <summary>
		/// Gets the response headers.
		/// </summary>
		/// <value>The response headers.</value>
		WebHeaderCollection ResponseHeaders { get; }

		/// <summary>
		/// Gets or sets the response encoding.
		/// </summary>
		/// <value>The response encoding.</value>
		string ResponseEncoding { get; set; }

		/// <summary>
		/// Gets or sets the referer.
		/// </summary>
		/// <value>The referer.</value>
		string Referer { get; set; }

		/// <summary>
		/// Gets or sets the timeout in milliseconds.
		/// </summary>
		/// <value>
		/// The timeout.
		/// </value>
		int Timeout { get; set; }
		#endregion
		
		#region Methods
		/// <summary>
		/// Performs the post.
		/// </summary>
		string Post();
		#endregion
	}
}