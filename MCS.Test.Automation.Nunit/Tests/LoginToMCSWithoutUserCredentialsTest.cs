// <copyright file="LoginToMCSWithoutUserCredentialsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class LoginToMCSWithoutUserCredentialsTest : ProjectTestBase
    {
        [Test]
        [Category("smoke")]
        [TestCaseDescription(Id = "MCS2-482", Name = "Rules and Exceptions - Login as Admin - Application Management")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "mcsloginEmpty" })]
        public void LoginToMCSWithoutUserCredentials(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string username = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(username, password);
            string unameError = parameters["unameerror"].Trim();
            string passworderror = parameters["passworderror"].Trim();
            loginPage.IsUsernameAndPasswordErrorMessagesDisplayed(unameError, passworderror);
        }
    }
}
