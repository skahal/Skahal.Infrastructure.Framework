using System;
using Skahal.Infrastructure.Framework.PCL.Repositories;
using Skahal.Infrastructure.Framework.PCL.Logging;
using System.Collections.Generic;

namespace Skahal.Infrastructure.Framework.PCL.Globalization
{
	/// <summary>
	/// Text globalization label repository base class.
	/// </summary>
	public abstract class TextGlobalizationLabelRepositoryBase 
		: MemoryGlobalizationLabelRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.PCL.Globalization.TextGlobalizationLabelRepositoryBase"/> class.
		/// </summary>
		protected TextGlobalizationLabelRepositoryBase()
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// Loads the culture labels.
		/// </summary>
		/// <returns>true</returns>
		/// <c>false</c>
		/// <param name="cultureName">Culture name.</param>
		public override bool LoadCultureLabels (string cultureName)
		{
			if (CountAll(f => f.CultureName.Equals(cultureName, StringComparison.OrdinalIgnoreCase)) == 0) {
				LogService.Debug ("TextGlobalizationLabelRepositoryBase :: Loading texts for language '{0}'...", cultureName);

				var lines = GetCultureText(cultureName).Split (new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

				LogService.Debug ("TextGlobalizationLabelRepositoryBase :: {0} texts founds...", lines.Length);

				foreach (var line in lines) {
					var lineParts = line.Split ('=');
					Entities.Add(new GlobalizationLabel() 
					             {
						EnglishText = lineParts [0].Trim (),
						CultureText = lineParts [1].Trim ().Replace(@"\n", System.Environment.NewLine),
						CultureName = cultureName
					});
				}

				return true;
			}

			return false;
		}

		/// <summary>
		/// Gets the culture text.
		/// </summary>
		/// <returns>The culture text.</returns>
		/// <param name="cultureName">Culture name.</param>
        protected internal abstract string GetCultureText (string cultureName);
		#endregion
	}
}

