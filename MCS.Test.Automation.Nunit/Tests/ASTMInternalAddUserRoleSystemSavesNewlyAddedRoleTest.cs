// <copyright file="ASTMInternalAddUserRoleSystemSavesNewlyAddedRoleTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalAddUserRoleSystemSavesNewlyAddedRoleTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1415", Name = "ASTM staff internal application - Login as ASTM staff -  Add User Role - System saves newly added Role")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "SystemSavesNewlyAddedUserRoleTest" })]
        public void ASTMInternalAddUserRoleSystemSavesNewlyAddedRole(Dictionary<string, string> parameters)
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
            rolesPage.IsAddRoleBtnClickable();
            rolesPage.IsAddRolePopupVisible();
            string roleName = parameters["roleName"].Trim() + DateHelper.RandomString(3, false);
            string descriptionText = parameters["descriptionText"].Trim();
            rolesPage.IsUserableToEnterRoleName(roleName);
            rolesPage.IsUserAbleToEnterTextInRoleDescription(descriptionText);
            renewalTasksPage.IsUserableToSaveTask();
            string successmsg = parameters["successmsg"].Trim();
            renewalTasksPage.IsSuccessMessageDisplayed(successmsg);
            rolesPage.AreNewlyAddedRoleInInAlphabeticalOrder();
        }
    }
}
