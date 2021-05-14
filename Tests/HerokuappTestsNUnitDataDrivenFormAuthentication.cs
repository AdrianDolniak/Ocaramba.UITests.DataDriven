// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using NUnit.Framework;
using Ocaramba.UITests.DataDriven;
using Ocaramba.UITests.DataDriven.PageObjects;
using Ocaramba.UITests.PageObjects;
using System.Collections.Generic;

namespace Ocaramba.UITests1.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HerokuappTestsNUnitDataDrivenFormAuthentication : ProjectTestBase
    {
        [Test]
        [TestCaseSource(typeof(TestData), "Credentials")]
        public void FormAuthenticationPageTestXml(IDictionary<string, string> parameters)
        {
            var basicAuthPage = new InternetPage(this.DriverContext);
            basicAuthPage.OpenHomePage();
            basicAuthPage.GoToPage("login");
            var formFormAuthentication = new FormAuthenticationPage(this.DriverContext);
            formFormAuthentication.EnterUserName(parameters["user"]);
            formFormAuthentication.EnterPassword(parameters["password"]);
            formFormAuthentication.LogIn();
            Verify.That(
                this.DriverContext,
                () => Assert.True(formFormAuthentication.PageTitle()), // tytul
                () => Assert.AreEqual(parameters["message"], formFormAuthentication.GetMessageSecure())); // message
        }

        [Test]
        [TestCaseSource(typeof(TestData), "CredentialsExcel")]
        public void FormAuthenticationPageTestExcel(IDictionary<string, string> parameters)
        {
            var basicAuthPage = new InternetPage(this.DriverContext);
            basicAuthPage.OpenHomePage();
            basicAuthPage.GoToPage("login");
            var formFormAuthentication = new FormAuthenticationPage(this.DriverContext);
            formFormAuthentication.EnterUserName(parameters["user"]);
            formFormAuthentication.EnterPassword(parameters["password"]);
            formFormAuthentication.LogIn();
            Verify.That(
                this.DriverContext,
                () => Assert.True(formFormAuthentication.PageTitle()), // tytul
                () => Assert.AreEqual(parameters["message"], formFormAuthentication.GetMessageSecure())); // message
        }

        [Test]
        [TestCaseSource(typeof(TestData), "CredentialsCSV")]
        public void FormAuthenticationPageTestCSV(IDictionary<string, string> parameters)
        {
            var basicAuthPage = new InternetPage(this.DriverContext);
            basicAuthPage.OpenHomePage();
            basicAuthPage.GoToPage("login");
            var formFormAuthentication = new FormAuthenticationPage(this.DriverContext);
            formFormAuthentication.EnterUserName(parameters["user"]);
            formFormAuthentication.EnterPassword(parameters["password"]);
            formFormAuthentication.LogIn();
            Verify.That(
                this.DriverContext,
                () => Assert.True(formFormAuthentication.PageTitle()), // tytul
                () => Assert.AreEqual(parameters["message"], formFormAuthentication.GetMessageSecure())); // message
        }
    }
}
