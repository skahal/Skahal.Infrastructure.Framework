using NUnit.Framework;
using System;
using Skahal.Infrastructure.Framework.Pooling;
using Rhino.Mocks;
using TestSharp;

namespace Skahal.Infrastructure.Framework.UnitTests.Pooling
{
	[TestFixture()]
	public class PoolServiceTest
	{
		[SetUp]
		public void TestSetUp()
		{
			PoolService.ClearAllPools();
		}

		[Test()]
		public void RegisterPool_NullPool_Exception ()
		{		
			ExceptionAssert.IsThrowing(new ArgumentNullException("pool"), () => {
				PoolService.RegisterPool(null);
			});
		}

		[Test()]
		public void RegisterPool_DuplicatePoolName_Exception ()
		{
			var pool = MockRepository.GenerateMock<PoolBase>("pool");
			PoolService.RegisterPool(pool);

			ExceptionAssert.IsThrowing(new InvalidOperationException("Already exists a registered pool with name 'pool'. The pool names must be unique."), () => {
				PoolService.RegisterPool(pool);
			});
		}

		[Test()]
		public void RegisterPool_PoolDiffNames_Registered ()
		{
			var pool1 = MockRepository.GenerateMock<PoolBase>("pool1");
			PoolService.RegisterPool(pool1);

			Assert.AreEqual(1, PoolService.PoolsCount);

			var pool2 = MockRepository.GenerateMock<PoolBase>("pool2");
			PoolService.RegisterPool(pool2);
			Assert.AreEqual(2, PoolService.PoolsCount);
		}

		[Test()]
		public void GetItem_InvalidPoolName_Exception()
		{
			ExceptionAssert.IsThrowing(new InvalidOperationException("The pool with name 'poll-1' was not found."), () => {
				PoolService.GetItem("poll-1");
			});
		}

		[Test()]
		public void GetItem_PoolName_Item ()
		{
			var pool1 = MockRepository.GenerateMock<PoolBase>("pool1");
			PoolService.RegisterPool(pool1);

			pool1.Expect(p => p.GetItem()).Return(1);
			Assert.AreEqual(1, PoolService.GetItem("pool1"));

			var pool2 = MockRepository.GenerateMock<PoolBase>("pool2");
			PoolService.RegisterPool(pool2);

			pool2.Expect(p => p.GetItem()).Return(2);
			Assert.AreEqual(2, PoolService.GetItem("pool2"));

			pool1.VerifyAllExpectations();
			pool2.VerifyAllExpectations();
		}

		[Test()]
		public void ReleaseItem_PoolName_Item ()
		{
			var pool1 = MockRepository.GenerateMock<PoolBase>("pool1");
			PoolService.RegisterPool(pool1);
			
			pool1.Expect(p => p.ReleaseItem(1));
			PoolService.ReleaseItem("pool1", 1);
			
			var pool2 = MockRepository.GenerateMock<PoolBase>("pool2");
			PoolService.RegisterPool(pool2);
			
			pool2.Expect(p => p.ReleaseItem(2));
			PoolService.ReleaseItem("pool2", 2);

			pool1.VerifyAllExpectations();
			pool2.VerifyAllExpectations();
		}

		[Test()]
		public void ReleaseAll_FilterNull_ReleaseAll ()
		{
			Func<object, bool> filter = null;
			var pool1 = MockRepository.GenerateMock<PoolBase>("pool1");
			PoolService.RegisterPool(pool1);			
			pool1.Expect(p => p.ReleaseAll(filter));

			var pool2 = MockRepository.GenerateMock<PoolBase>("pool2");
			PoolService.RegisterPool(pool2);			
			pool2.Expect(p => p.ReleaseAll(filter));

			PoolService.ReleaseAll(null);

			pool1.VerifyAllExpectations();
			pool2.VerifyAllExpectations();
		}

		[Test()]
		public void ReleaseAll_NoArguments_ReleaseAll ()
		{
			var pool1 = MockRepository.GenerateMock<PoolBase>("pool1");
			PoolService.RegisterPool(pool1);			
			pool1.Expect(p => p.ReleaseAll(null)).IgnoreArguments();
			
			var pool2 = MockRepository.GenerateMock<PoolBase>("pool2");
			PoolService.RegisterPool(pool2);			
			pool2.Expect(p => p.ReleaseAll(null)).IgnoreArguments ();
			
			PoolService.ReleaseAll();
			
			pool1.VerifyAllExpectations();
			pool2.VerifyAllExpectations();
		}

		[Test()]
		public void ReleaseAll_WithFilter_ReleaseFilteredOnes ()
		{
			Func<object, bool> filter = (o) => false;
			var pool1 = MockRepository.GenerateMock<PoolBase>("pool1");
			PoolService.RegisterPool(pool1);	
			pool1.Expect(p => p.ReleaseAll(filter));

			var pool2 = MockRepository.GenerateMock<PoolBase>("pool2");
			PoolService.RegisterPool(pool2);			
			pool2.Expect(p => p.ReleaseAll(filter));
			
			PoolService.ReleaseAll(filter);
			
			pool1.VerifyAllExpectations();
			pool2.VerifyAllExpectations();
		}
	}
}

