using System;
using System.Globalization;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using Ocaramba.UITests.DataDriven;
using OpenQA.Selenium;

namespace Ocaramba.UITests1.PageObjects
{
    public class FormAuthenticationPage : ProjectPageBase
    {
        private readonly NLog.Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            userNameLoc = new ElementLocator(Locator.CssSelector, "Input[id={0}]"),
            passwordLoc = new ElementLocator(Locator.CssSelector, "Input[id={0}]"),
            loginButtonLoc = new ElementLocator(Locator.XPath, "//form[@id='login']/button"),
            messageSecure = new ElementLocator(Locator.XPath, "//*[@id='flash']");

        public FormAuthenticationPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        /// <summary>
        /// Methods for this HomePage
        /// </summary>
        public string GetMessageSecure()
        {
            var messageSecureText = this.Driver.GetElement(this.messageSecure, ProjectBaseConfiguration.CustomTimeout, e => e.Displayed).Text;
            messageSecureText = messageSecureText.Split('\r')[0];
            Logger.Info(CultureInfo.CurrentCulture, "Message text: {0}", messageSecureText);
            return messageSecureText;
        }
        public void EnterPassword(string password)
        {
            Logger.Info(CultureInfo.CurrentCulture, "Password '{0}'", password);
            this.Driver.GetElement(this.passwordLoc.Format("password"), BaseConfiguration.ShortTimeout).SendKeys(password);
        }
        public void EnterUserName(string userName)
        {
            Logger.Info(CultureInfo.CurrentCulture, "User name '{0}'", userName);
            this.Driver.GetElement(this.userNameLoc.Format("username"), BaseConfiguration.ShortTimeout).SendKeys(userName);
        }
        public void LogIn()
        {
            Logger.Info(CultureInfo.CurrentCulture, "Click on Login Button");
            this.Driver.GetElement(this.loginButtonLoc).Click();
        }
    }
}

