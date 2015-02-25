using System;
using Skahal.Infrastructure.Framework.Repositories;

namespace Skahal.Infrastructure.Framework.Globalization
{
	/// <summary>
	/// An in-memory globalization label repository.
	/// </summary>
	public class MemoryGlobalizationLabelRepository : MemoryRepository<GlobalizationLabel>, IGlobalizationLabelRepository
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.Globalization.MemoryGlobalizationLabelRepository"/> class.
		/// </summary>
		public MemoryGlobalizationLabelRepository () : base((l) => { return Guid.NewGuid().ToString(); })
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// Loads the culture labels.
		/// </summary>
		/// <returns><c>true</c>, if culture labels was loaded, <c>false</c> otherwise, already loaded.</returns>
		/// <param name="cultureName">Culture name.</param>
		public virtual bool LoadCultureLabels(string cultureName)
		{
			return false;
		}
		#endregion
	}
}

