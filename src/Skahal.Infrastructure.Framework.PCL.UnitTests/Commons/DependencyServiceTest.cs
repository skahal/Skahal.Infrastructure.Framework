using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.PCL.Commons;
using TestSharp;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests.Commons
{
	[TestFixture()]
	public class DependencyServiceTest
	{
		[Test()]
		public void Register_TypeByFunction_CreateInstance ()
		{
			DependencyService.Register<int>(() => { return 1; });
			var actual = DependencyService.Create<int>();

			Assert.AreEqual(1, actual);
		}

		[Test()]
		public void Register_TypeByFunctionWithArgument_CreateInstance ()
		{
			DependencyService.Register<string>((chars) => { return new String((char[])chars); });
			var actual = DependencyService.Create<string>(new char[] { 't', 'e', 's', 't', 'e' });

			Assert.AreEqual("teste", actual);
		}

		[Test()]
		public void Register_TypeByInstance_CreateInstance ()
		{
			DependencyService.Register<int>(2);
			var actual = DependencyService.Create<int>();
			
			Assert.AreEqual(2, actual);
		}

		[Test()]
		public void Create_TypeNotRegistered_Exception ()
		{
			ExceptionAssert.IsThrowing(typeof(ArgumentException), () => { 
				DependencyService.Create<string>();
			});

		}
	}
}

