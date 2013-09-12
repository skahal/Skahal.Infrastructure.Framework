using System;
using NUnit.Framework;
using Rhino.Mocks;
using Skahal.Infrastructure.Framework.Commons;
using TestSharp;

namespace Skahal.Infrastructure.Framework.UnitTests
{
	[TestFixture()]
	public class AppServiceTest
	{
		[Test()]
		public void Initialize_NullStrategy_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("strategy"), () => {
				AppService.Initialize (null);
			});
		}

		[Test()]
		public void Started_NoListener_NoEventTriggered ()
		{
			var strategy = MockRepository.GenerateMock<IAppStrategy> ();
			AppService.Initialize (strategy);
			strategy.Raise (a => a.Started += null, strategy, EventArgs.Empty);
		}

		[Test()]
		public void Started_Listener_EventTriggered ()
		{
			var strategy = MockRepository.GenerateMock<IAppStrategy> ();
			AppService.Initialize (strategy);

			var raised = false;
			AppService.Started += delegate {
				raised = true;
			};
			strategy.Raise (a => a.Started += null, strategy, EventArgs.Empty);
			Assert.IsTrue (raised);
		}

		[Test()]
		public void BackgroundBegin_NoListener_NoEventTriggered ()
		{
			var strategy = MockRepository.GenerateMock<IAppStrategy> ();
			AppService.Initialize (strategy);
			strategy.Raise (a => a.BackgroundBegin += null, strategy, EventArgs.Empty);
		}

		[Test()]
		public void BackgroundBegin_Listener_EventTriggered ()
		{
			var strategy = MockRepository.GenerateMock<IAppStrategy> ();
			AppService.Initialize (strategy);

			var raised = false;
			AppService.BackgroundBegin += delegate {
				raised = true;
			};
			strategy.Raise (a => a.BackgroundBegin += null, strategy, EventArgs.Empty);
			Assert.IsTrue (raised);
		}

		[Test()]
		public void ForegroundBegin_NoListener_NoEventTriggered ()
		{
			var strategy = MockRepository.GenerateMock<IAppStrategy> ();
			AppService.Initialize (strategy);
			strategy.Raise (a => a.ForegroundBegin += null, strategy, EventArgs.Empty);
		}

		[Test()]
		public void ForegroundBegin_Listener_EventTriggered ()
		{
			var strategy = MockRepository.GenerateMock<IAppStrategy> ();
			AppService.Initialize (strategy);

			var raised = false;
			AppService.ForegroundBegin += delegate {
				raised = true;
			};
			strategy.Raise (a => a.ForegroundBegin += null, strategy, EventArgs.Empty);
			Assert.IsTrue (raised);
		}

		[Test()]
		public void Exited_NoListener_NoEventTriggered ()
		{
			var strategy = MockRepository.GenerateMock<IAppStrategy> ();
			AppService.Initialize (strategy);
			strategy.Raise (a => a.Exited += null, strategy, EventArgs.Empty);
		}

		[Test()]
		public void Exited_Listener_EventTriggered ()
		{
			var strategy = MockRepository.GenerateMock<IAppStrategy> ();
			AppService.Initialize (strategy);

			var raised = false;
			AppService.Exited += delegate {
				raised = true;
			};
			strategy.Raise (a => a.Exited += null, strategy, EventArgs.Empty);
			Assert.IsTrue (raised);
		}
	}
}