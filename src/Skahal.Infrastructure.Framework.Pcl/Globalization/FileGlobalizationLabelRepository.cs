using System;

namespace Skahal.Infrastructure.Framework.Globalization
{
    /// <summary>
    /// A TextGlobalizationLabelRepositoryBase using file.
    /// </summary>
    public class FileGlobalizationLabelRepository : TextGlobalizationLabelRepositoryBase
    {
        #region Fields
        private string m_filesDirectory;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FileGlobalizationLabelRepository"/> class.
        /// </summary>
        /// <param name="filesDirectory">The files directory.</param>
        public FileGlobalizationLabelRepository(string filesDirectory)
        {
            m_filesDirectory = filesDirectory;
        }
        #endregion

        #region implemented abstract members of TextGlobalizationLabelRepositoryBase
        /// <summary>
        /// Gets the culture text.
        /// </summary>
        /// <returns>The culture text.</returns>
        /// <param name="cultureName">Culture name.</param>
        protected internal override string GetCultureText(string cultureName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}