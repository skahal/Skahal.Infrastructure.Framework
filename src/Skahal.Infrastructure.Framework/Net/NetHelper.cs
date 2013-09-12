using System;

namespace Skahal.Infrastructure.Framework
{
	/// <summary>
	/// Net helper.
	/// </summary>
	public static class NetHelper
	{
		/// <summary>
		/// Determines whether is a valid tcp port number the specified portNumber.
		/// </summary>
		/// <returns><c>true</c> if is a valid tcp port number the specified portNumber; otherwise, <c>false</c>.</returns>
		/// <param name="portNumber">Port number.</param>
		public static bool IsValidTcpPortNumber(int portNumber)
		{
			return portNumber > 0 && portNumber <= 65535;
		}

		/// <summary>
		/// Throws a exception if invalid tcp port number.
		/// </summary>
		/// <param name="portNumber">Port number.</param>
		public static void ThrowIfInvalidTcpPortNumber(int portNumber)
		{
			if(!IsValidTcpPortNumber(portNumber))
			{
				var msg = String.Format("The port '{0}' is a invalid TCP port number.", portNumber);
				throw new InvalidOperationException(msg);
			}
		}
	}
}

