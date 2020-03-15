// <copyright file="VerifyViewApplicationColumnsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyViewApplicationColumnsTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-462", Name = "Rules and Exceptions � View application list � Columns")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewApplicationColumns" })]
        public void VerifyViewApplicationColumns(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            var applicationManagementPage = new ApplicationManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsLoggedUserDisplayed();
            homePage.IsApplicationManagementSectionClickable();
            applicationManagementPage.IsUserAbleToViewApplicationListColumns();
            applicationManagementPage.IsUserAbleToViewApplicationList();
        }
    }
}