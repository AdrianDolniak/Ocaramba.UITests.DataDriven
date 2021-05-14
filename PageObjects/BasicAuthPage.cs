using System;
using System.Globalization;
using System.Linq;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;

namespace Ocaramba.UITests.DataDriven.PageObjects
{
    public class BasicAuthPage : ProjectPageBase
    {
        private readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.XPath, "//h3[.='Basic Auth']"),
            messageCongratulations = new ElementLocator(Locator.XPath, "//*[@id='content']/div/p");

        public BasicAuthPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this BasicAuthPage
        /// </summary>
        public void SignIn(string username, string password)
        {
            this.Driver.Navigate().GoToUrl("http://" + username + ":" + password + "@the-internet.herokuapp.com/basic_auth");
        }

        public bool PageTitle()
        {
            var pageTitle = this.Driver.IsPageTitle("The Internet", 5);
            return pageTitle;
        }

        public string GetHeader()
        {
            var pageHeaderText = this.Driver.GetElement(this.pageHeader).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Header text: {0}", pageHeaderText);
            return pageHeaderText;
        }

        public string GetMessage()
        {
            var messageText = this.Driver.GetElement(this.messageCongratulations, ProjectBaseConfiguration.CustomTimeout, e => e.Displayed).Text;
            Logger.Info(CultureInfo.CurrentCulture, "Message text: {0}", messageText);
            return messageText;
        }
    }
}

