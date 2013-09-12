//  Author: Diego Giacomelli <giacomelli@gmail.com>
//  Copyright (c) 2011 Skahal Studios

#region Usings
using System;
#endregion

namespace Skahal.Infrastructure.Framework.Commons
{
	/// <summary>
	/// A basic progress indicator.
	/// </summary>
	public class ProgressIndicator : IProgressIndicator
	{
		#region Events
		/// <summary>
		/// Occurs when progress changed.
		/// </summary>
		public event EventHandler ProgressChanged;
		#endregion
		
		#region Fields
		private string m_title;
		private string m_message;
		private float m_progress;
		#endregion 
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Skahal.Infrastructure.Framework.Commons.ProgressIndicator"/> class.
		/// </summary>
		public ProgressIndicator()
		{
			m_title = "";
			m_message = "";
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title 
		{ 
			get
			{
				return m_title;
			}
			
			set
			{
				if(m_title != value)
				{
					m_title = value;
				
					OnProgressChanged(EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message 
		{ 
			get
			{
				return m_message;
			}
			
			set
			{
				if(m_message != value)
				{
					m_message = value;
				
					OnProgressChanged(EventArgs.Empty);
				}
			}
		}
			
		/// <summary>
		/// Gets or sets the progress percent.
		/// </summary>
		/// <value>The progress.</value>
		public float Progress 
		{ 
			get
			{
				return m_progress;
			}
			
			set
			{
				if(m_progress != value)
				{
					m_progress = value;
				
					OnProgressChanged(EventArgs.Empty);
				}
			}
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Raises the progress changed event.
		/// </summary>
		/// <param name="args">Arguments.</param>
		protected virtual void OnProgressChanged(EventArgs args)
		{
			if(ProgressChanged != null)
			{
				ProgressChanged(this, args);
			}
		}
		#endregion
	}
}