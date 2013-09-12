using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Globalization;
using TestSharp;
using Rhino.Mocks;
using Skahal.Infrastructure.Framework.Repositories;
using Skahal.Infrastructure.Framework.People;

namespace Skahal.Infrastructure.Framework.UnitTests
{
	[TestFixture()]
	public class GlobalizationServiceTest
	{
		#region Fields
		#endregion

		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			var repository = MockRepository.GenerateMock<IUserRepository> ();
			repository.Expect (r => r.FindAll(null)).IgnoreArguments ().Return (new User[] { new User("1") });
			UserService.Initialize (repository);

		}
		#endregion

		#region Tests
		[Test()]
		public void Translate_NullOrEmpty_Exception ()
		{
			GlobalizationService.Initialize (MockRepository.GenerateMock<IGlobalizationLabelRepository> ());

			ExceptionAssert.IsThrowing (new ArgumentNullException("englishText"), () => {
				GlobalizationService.Translate (null);
			});

			ExceptionAssert.IsThrowing (new ArgumentNullException("englishText"), () => {
				GlobalizationService.Translate ("");
			});
		}

		[Test()]
		public void Translate_NoTranslation_SameText ()
		{

			var repository = MockRepository.GenerateMock<IGlobalizationLabelRepository> ();
			repository.Expect (r => r.FindAll(null)).IgnoreArguments ().Return (new GlobalizationLabel[0]);
			GlobalizationService.Initialize (repository);

			var actual = GlobalizationService.Translate ("TEST");
			Assert.AreEqual ("TEST", actual);

			repository.VerifyAllExpectations ();
		}

		[Test()]
		public void Translate_HasTranslationForCulture_TranslatedTestToCulture ()
		{
			var repository = MockRepository.GeneratePartialMock<TextGlobalizationLabelRepositoryBase> ();
			repository.Expect (t => t.GetCultureText("en-US")).Return ("");
			repository.Expect (t => t.GetCultureText("pt-BR")).Return ("TEST = Teste" + Environment.NewLine + "first=primeiro");
			repository.Expect (t => t.GetCultureText("es-ES")).Return ("TEST = prueba" + Environment.NewLine + "first=primero");
			repository.Expect (t => t.GetCultureText("en-US")).Return ("");
			GlobalizationService.Initialize (repository);

			GlobalizationService.ChangeCulture ("pt-BR");
			var actual = GlobalizationService.Translate ("TEST");
			Assert.AreEqual ("Teste", actual);

			GlobalizationService.ChangeCulture ("es-ES");
			actual = GlobalizationService.Translate ("TEST");
			Assert.AreEqual ("prueba", actual);

			GlobalizationService.ChangeCulture ("en-US");
			actual = GlobalizationService.Translate ("TEST");
			Assert.AreEqual ("TEST", actual);
		}
		#endregion
	}
}

