// <copyright file="ASTMInternalEditRolePermissionsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalEditRolePermissionsTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1368", Name = "ASTM staff internal application - Login as ASTM staff - Update permissions for menus/sub-menus on Edit Role pop up")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AstmInternalEditUserRolePermission" })]
        public void ASTMInternalEditRolePermissions(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            var rolesPage = new InternalStaffManageRolesPage(this.DriverContext);
            var userPage = new InternallStaffUsersPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsCustomerLogoDisplayed();
            internalhomePage.IsLoggedUserDisplayed();
            homePage.SelectUserPermissionFromAdminMenuitem();
            homePage.IsSelectRolesFromAdminMenuitem();
            homePage.PageRefresh();
            rolesPage.IsManageRolessHeaderVisible();
            string roleName = rolesPage.IsGetExistingRoleNameFromRolesList();
            rolesPage.IsEditIconClickOnExistingRole();
            rolesPage.IsUserAbleToViewPopupTitle();
            rolesPage.IsUserAbleToUpdateRolesToExistingUser();
            rolesPage.IsUserableToUpdateRoles();
            string successMsg = parameters["successMsg"].Trim();
            userPage.IsUserUpdatedMessageDisplayedSuccessfully(successMsg);
        }
    }
}
