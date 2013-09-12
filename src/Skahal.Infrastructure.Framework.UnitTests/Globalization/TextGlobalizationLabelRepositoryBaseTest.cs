using System;
using NUnit.Framework;
using Rhino.Mocks;
using Skahal.Infrastructure.Framework.Globalization;
using System.Linq;

namespace Skahal.Infrastructure.Framework.UnitTests
{
	[TestFixture()]
	public class TextGlobalizationLabelRepositoryBaseTest
	{
		[Test()]
		public void FindAll_DiffCultures_DiffResults ()
		{
			var target = MockRepository.GeneratePartialMock<TextGlobalizationLabelRepositoryBase> ();
			target.Expect (t => t.GetCultureText("pt-BR")).Return ("name = nome" + Environment.NewLine + "first=primeiro");
			target.Expect (t => t.GetCultureText("es-ES")).Return ("name = nombre" + Environment.NewLine + "first=primero");

			// pt-BR labels not loaded yet.
			var actual = target.FindAll (0, 5, f => f.CultureName.Equals("pt-BR")).ToList ();
			Assert.AreEqual (0, actual.Count);

			Assert.IsTrue(target.LoadCultureLabels ("es-ES"));
			actual = target.FindAll(0, 5, f => f.CultureName.Equals("pt-BR")).ToList ();
			Assert.AreEqual (0, actual.Count);

			// pt-BR labels loaded.
			Assert.IsTrue(target.LoadCultureLabels ("pt-BR"));
			actual = target.FindAll(0, 5, f => f.CultureName.Equals("pt-BR")).ToList ();
			Assert.AreEqual (2, actual.Count);
			var label = actual [0];
			Assert.AreEqual ("name", label.EnglishText);
			Assert.AreEqual ("nome", label.CultureText);
			Assert.AreSame ("pt-BR", label.CultureName);

			label = actual [1];
			Assert.AreEqual ("first", label.EnglishText);
			Assert.AreEqual ("primeiro", label.CultureText);
			Assert.AreSame ("pt-BR", label.CultureName);

			// es-ES labels loaded.
			Assert.IsFalse(target.LoadCultureLabels ("es-ES"));
			actual = target.FindAll(0, 5, f => f.CultureName.Equals("es-ES")).ToList ();
			Assert.AreEqual (2, actual.Count);
			label = actual [0];
			Assert.AreEqual ("name", label.EnglishText);
			Assert.AreEqual ("nombre", label.CultureText);
			Assert.AreSame ("es-ES", label.CultureName);

			label = actual [1];
			Assert.AreEqual ("first", label.EnglishText);
			Assert.AreEqual ("primero", label.CultureText);
			Assert.AreSame ("es-ES", label.CultureName);
		}
	}
}

