using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Globalization;
using Rhino.Mocks;
using System.IO.Abstractions;
using System.Linq;
using Skahal.Infrastructure.Framework.Logging;
using System.IO.Abstractions.TestingHelpers;
using System.Collections.Generic;

namespace Skahal.Infrastructure.Framework.UnitTests
{
	[TestFixture()]
	public class FileGlobalizationLabelRepositoryTest
	{
		[Test()]
        [Ignore("Not yet implemented")]
		public void FindAll_DiffCultures_DiffResults ()
		{
			var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
			{                                  
				{ @"c:\labels\pt-BR.labels", new MockFileData("name = nome\nfirst=primeiro") },
				{ @"c:\labels\es-ES.labels", new MockFileData("name = nombre\nfirst=primero") },
			});

			Skahal.Infrastructure.Framework.IO.FileSystem.Initialize (fileSystem);

			var target = new FileGlobalizationLabelRepository (@"c:\labels");

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

