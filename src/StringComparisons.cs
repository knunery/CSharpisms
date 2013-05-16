using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace CSharpisms
{
    // Jon Skeet example from Tekpub
    public class StringComparisons
    {
        public void Example()
        {
            string string1 = "";
            string string2 = "";
        }

        [Test]
        public void CultureBug()
        {
            CultureInfo turkish = CultureInfo.CreateSpecificCulture("tr");

            Thread.CurrentThread.CurrentCulture = turkish;

            string input = "mime type";

            Assert.AreEqual("MIME TYPE", input.ToUpper());

        }

        [Test]
        public void CultureBug_Fixed()
        {
            CultureInfo turkish = CultureInfo.CreateSpecificCulture("tr");

            Thread.CurrentThread.CurrentCulture = turkish;

            string input = "mime type";

            Assert.IsTrue(input.Equals("MIME TYPE", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
