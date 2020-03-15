// <copyright file="ASTMStaffInternalErrorMessageDisplayedWhenRoleNameIsNotUniqueTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Extensions;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMStaffInternalErrorMessageDisplayedWhenRoleNameIsNotUniqueTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1369", Name = "ASTM staff internal application - Login as ASTM staff - System displays an error message when Role Name is not unique")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ErrorMessageDisplayedWhenRoleNameIsNotUnique" })]
        public void ASTMStaffInternalErrorMessageDisplayedWhenRoleNameIsNotUnique(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            var rolesPage = new InternalStaffManageRolesPage(this.DriverContext);
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
            rolesPage.IsUserableToEnterRoleName(roleName);
            rolesPage.IsUserableToUpdateTask();
            string errorMsg = parameters["errorMsg"].Trim();
            rolesPage.IsRoleNameErrorMessageDisplayed(errorMsg);
        }
    }
}
