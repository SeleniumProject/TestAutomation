// <copyright file="VerifyNoPermissionAssignedErrorMessageForAddUserCreateTest.cs" company="PlaceholderCompany">
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
    public class VerifyNoPermissionAssignedErrorMessageForAddUserCreateTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1077", Name = "Rules and Exceptions - User List – Add User – Search User search box  - Mandatory fields missing-Permissions")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "Userpermissiondata" })]
        public void VerifyNoPermissionAssignedErrorMessageForAddUserCreate(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var userManagementPage = new UserManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsUserManagementSectionClickable();
            string headername = parameters["headername"].Trim();

            homePage.IsUsersHeaderVisible(headername);
            userManagementPage.IsAddUserButtonClickable();
            string username = parameters["username"].Trim() + DateHelper.RandomString(4, false);
            userManagementPage.EnterUserName(username);
            userManagementPage.IsValidateInADButtonClickable();
            userManagementPage.IsAddUserSaveButtonClickable();

            string errormessage = parameters["errormessage"].Trim();
            userManagementPage.IsNoPermissionAssignedErrorMessageDisplayed(errormessage);
        }
    }
}
