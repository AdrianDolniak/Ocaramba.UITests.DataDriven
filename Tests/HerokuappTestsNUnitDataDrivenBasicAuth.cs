// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests.DataDriven.PageObjects;
using System.Collections.Generic;

namespace Ocaramba.UITests.DataDriven.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HerokuappTestsNUnitDataDrivenBasicAuth : ProjectTestBase
    {
        [Test]
        [TestCaseSource(typeof(TestData), "CredentialsBasicAuthCSV")]
        public void BasicAuthPageTestXml(IDictionary<string, string> parameters)
        {
            var basicAuthPage = new InternetPage(this.DriverContext);
            basicAuthPage.OpenHomePage();
            basicAuthPage.GoToPage("basic_auth");
            var basicAuthPageNextPage = new BasicAuthPage(DriverContext);
            basicAuthPageNextPage.SignIn(parameters["user"], parameters["password"]);
            Verify.That(
                this.DriverContext,
                () => Assert.True(basicAuthPageNextPage.PageTitle()), // tytul
                () => Assert.AreEqual("Basic Auth", basicAuthPageNextPage.GetHeader()), // header
                () => Assert.AreEqual(parameters["message"], basicAuthPageNextPage.GetMessage())); // message

        }
    }
}