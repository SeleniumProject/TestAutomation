// <copyright file="ASTMInternalUserAddandSaveAdditionalPrevilegesTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalUserAddandSaveAdditionalPrevilegesTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-872", Name = "ASTM Staff Internal Application – Admin menu – User list Page- Edit and save additional privileges")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "InternalLoginUserlistPrivilegeData" })]
        public void ASTMInternalUserAddandSaveAdditionalPrevileges(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var internalStaffUsersPage = new InternallStaffUsersPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();

            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);

            homePage.IsLoggedInUserDisplayed(uname);
            homePage.SelectUserPermissionFromAdminMenuitem();

            internalStaffUsersPage.IsUserIsAbleToSelectUsersFromList(0);
            internalStaffUsersPage.IsUserAbleToClickOnEditIcon();

            internalStaffUsersPage.IsUserIsAbleToClickOnUserDropDownList();
            internalStaffUsersPage.SelectRoleFromList(0);

            internalStaffUsersPage.IsUserAbleToAddPrivilegesToExistingUser();
            internalStaffUsersPage.IsUserIsAbleToClickOnUpdateButton();

            string successMessage = parameters["successMessage"].Trim();
            internalStaffUsersPage.IsUserUpdatedMessageDisplayedSuccessfully(successMessage);
        }
    }
}
