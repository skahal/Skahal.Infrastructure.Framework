using System.IO.Abstractions;
using HelperSharp;
using Skahal.Infrastructure.Framework.Logging;

namespace Skahal.Infrastructure.Framework.IO
{
    /// <summary>
    /// File system.
    /// </summary>
    public static class FileSystem
    {
        #region Methods
        /// <summary>
        /// Initialize the file system.
        /// </summary>
        /// <param name="fileSystem">File system.</param>
        public static void Initialize(IFileSystem fileSystem)
        {
            ExceptionHelper.ThrowIfNull("fileSystem", fileSystem);

            Current = fileSystem;
            LogService.Debug("FileSystem :: Initialized with {0}.", fileSystem);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current  file system.
        /// </summary>
        /// <value>The current.</value>
        public static IFileSystem Current { get; private set; }
        #endregion
    }
}