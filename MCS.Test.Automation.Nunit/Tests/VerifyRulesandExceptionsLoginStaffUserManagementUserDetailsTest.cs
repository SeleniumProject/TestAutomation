// <copyright file="VerifyRulesandExceptionsLoginStaffUserManagementUserDetailsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyRulesandExceptionsLoginStaffUserManagementUserDetailsTest : ProjectTestBase
    {
        [Test]
        [Category("NotReady")]
        [Category("smoke")]
        [TestCaseDescription(Id = "MCS2-1016", Name = "Rules and Exceptions - Login as staff –User Management – User details page -Manage Officer Titles sub menu")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditUserWithErrorMessage" })]
        public void VerifyRulesandExceptionsLoginStaffUserManagementUserDetails(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var userManagementPage = new UserManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsUserManagementSectionClickable();
        }
    }
}
