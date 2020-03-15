// <copyright file="ASTMInternalEditUserPermissionsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalEditUserPermissionsTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-876", Name = "ASTM Staff Internal Application – Admin menu – User list Page- Edit and save Role drop down")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternalEditUserRole" })]
        public void ASTMInternalEditUserPermissions(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var internalStaffUsersPage = new InternallStaffUsersPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedInUserDisplayed(uname);
            homePage.SelectUserPermissionFromAdminMenuitem();
            internalStaffUsersPage.IsUserIsAbleToSelectUsersFromList(1);
            internalStaffUsersPage.IsUserAbleToClickOnEditIcon();
            internalStaffUsersPage.IsUserIsAbleToClickOnUserDropDownList();
            internalStaffUsersPage.SelectRoleFromList(1);
            internalStaffUsersPage.IsUserIsAbleToClickOnUpdateButton();
            string successMsg = parameters["successMsg"].Trim();
            internalStaffUsersPage.IsUserUpdatedMessageDisplayedSuccessfully(successMsg);
        }
    }
}
