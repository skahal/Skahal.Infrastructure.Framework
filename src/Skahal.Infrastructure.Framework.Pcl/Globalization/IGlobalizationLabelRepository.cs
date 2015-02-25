using System;
using Skahal.Infrastructure.Framework.PCL.Repositories;

namespace Skahal.Infrastructure.Framework.PCL.Globalization
{
	/// <summary>
	/// Defines a interface for globalization label repository.
	/// </summary>
	public interface IGlobalizationLabelRepository : IRepository<GlobalizationLabel>
	{
		/// <summary>
		/// Loads the culture labels.
		/// </summary>
		/// <returns><c>true</c>, if culture labels was loaded, <c>false</c> otherwise, already loaded.</returns>
		/// <param name="cultureName">Culture name.</param>
		bool LoadCultureLabels(string cultureName);
	}
}