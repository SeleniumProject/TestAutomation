// <copyright file="ASTMInternalAddUserRolePrivilegesSectionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalAddUserRolePrivilegesSectionTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1398", Name = "ASTM staff internal application - Login as ASTM staff - View privileges section on Add Role pop up")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AstmInternalAddRolePrivileges" })]
        public void ASTMInternalAddUserRolePrivilegesSection(Dictionary<string, string> parameters)
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
            string membershipManagement = parameters["membershipManagement"].Trim();
            rolesPage.IsUseAbleToViewMembershipManagementPrivilegesSection(membershipManagement);
            string committeeManagement = parameters["committeeManagement"].Trim();
            rolesPage.IsUseAbleToViewMembershipManagementPrivilegesSection(committeeManagement);
            string adminPrivileges = parameters["adminPrivileges"].Trim();
            rolesPage.IsUseAbleToViewMembershipManagementPrivilegesSection(adminPrivileges);
            string renewalTask = parameters["renewalTask"].Trim();
            rolesPage.IsUseAbleToViewMembershipManagementPrivilegesSection(renewalTask);
        }
    }
}
