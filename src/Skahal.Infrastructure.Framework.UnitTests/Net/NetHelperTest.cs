using System;
using NUnit.Framework;
using TestSharp;

namespace Skahal.Infrastructure.Framework.UnitTests
{
	[TestFixture()]
	public class NetHelperTest
	{
		[Test()]
		public void IsValidTcpPortNumber_InvalidPort_False ()
		{
			Assert.IsFalse(NetHelper.IsValidTcpPortNumber(-1));
			Assert.IsFalse(NetHelper.IsValidTcpPortNumber(0));
			Assert.IsFalse(NetHelper.IsValidTcpPortNumber(65536));
		}

		[Test()]
		public void IsValidTcpPortNumber_ValidPort_True ()
		{
			Assert.IsTrue(NetHelper.IsValidTcpPortNumber(1));
			Assert.IsTrue(NetHelper.IsValidTcpPortNumber(1000));
			Assert.IsTrue(NetHelper.IsValidTcpPortNumber(65535));
		}

		[Test()]
		public void ThrowInvalidTcpPortNumber_InvalidPort_Exception ()
		{
			ExceptionAssert.IsThrowing(new InvalidOperationException("The port '66666' is a invalid TCP port number."), () => {
				NetHelper.ThrowIfInvalidTcpPortNumber(66666);
			});
		}
		
		[Test()]
		public void ThrowInvalidTcpPortNumber_InvalidPort_NoException ()
		{
			NetHelper.ThrowIfInvalidTcpPortNumber(1);
		}
	}
}

