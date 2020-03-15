// <copyright file="ASTMStaffInternalApplicationVerifyAdminmenuUserlistPageRolesdropdownFilterTest.cs" company="PlaceholderCompany">
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
    public class ASTMStaffInternalApplicationVerifyAdminmenuUserlistPageRolesdropdownFilterTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-895", Name = "ASTM Staff Internal Application – Admin menu – User list Page- Roles drop down Filter")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "RolesDropDownFilter" })]
        public void ASTMStaffInternalApplicationVerifyAdminmenuUserlistPageRolesdropdownFilter(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var userListPage = new InternallStaffUsersPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();

            homePage.IsLoggedInUserDisplayed(uname);
            homePage.SelectUserPermissionFromAdminMenuitem();

            userListPage.IsUserIsAbleToClickOnUserDropDownList();
            string roleName = parameters["roleName"].Trim();
            userListPage.IsAllUserRecordsBasedOnRolesInFilterDrpDwn(roleName);

            userListPage.IsUserRoleDisplayedInAllRecordsBasedOnRoleSelectionFromDropDown(roleName);
        }
    }
}
