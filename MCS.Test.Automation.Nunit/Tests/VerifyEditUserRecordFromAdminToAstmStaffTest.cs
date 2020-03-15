// <copyright file="VerifyEditUserRecordFromAdminToAstmStaffTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyEditUserRecordFromAdminToAstmStaffTest : ProjectTestBase
    {
        [Test]
        [Category("NotReady")]
        [TestCaseDescription(Id = "MCS2-763", Name = "Rules and Exceptions - User Management - User List Page - Username column - User Details page - Edit User Type - Change Admin User type to ASTM Staff")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditUseradditionalPrivileges" })]
        public void VerifyEditUserRecordFromAdminToAstmStaff(Dictionary<string, string> parameters)
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
            string userrecordname = parameters["userrecordname"].Trim();
            string headername = parameters["headername"].Trim();
            homePage.IsUsersHeaderVisible(headername);

            homePage.IsUserRecordclickable(userrecordname);
            string headernameforViewpage = parameters["headernameforViewpage"].Trim();
            homePage.IsViewUsersPageDisplayed(headernameforViewpage);
            string headernameforeditUserPage = parameters["headernameforeditUserPage"].Trim();
            userManagementPage.IsEditBtnClickable(headernameforeditUserPage);
            userManagementPage.IsUserAbleToClickOnDropDown();
            userManagementPage.IsUserAbleToClickOnAstmStaffUserType();
            string manageMemebershipType = parameters["manageMemebershipType"].Trim();
            userManagementPage.IsUserAbleToViewCheckBoxIsNotClicked(manageMemebershipType);

            string manageMemebershipFAQ = parameters["manageMemebershipFAQ"].Trim();
            userManagementPage.IsUserAbleToViewCheckBoxIsNotClicked(manageMemebershipFAQ);
            string manageMemebershipDocument = parameters["manageMemebershipDocument"].Trim();
            userManagementPage.IsUserAbleToViewCheckBoxIsNotClicked(manageMemebershipDocument);
            string manageMemebershipClassfication = parameters["manageMemebershipClassfication"].Trim();
            userManagementPage.IsUserAbleToViewCheckBoxIsNotClicked(manageMemebershipClassfication);
            string committeeManagement = parameters["committeeManagement"].Trim();
            userManagementPage.IsUserAbleToClickPermissionDropDown(committeeManagement);
            string manageCommitteeType = parameters["manageCommitteeType"].Trim();
            userManagementPage.IsUserAbleToViewCheckBoxIsNotClicked(manageCommitteeType);
            string manageOfficerTitle = parameters["manageOfficerTitle"].Trim();
            userManagementPage.IsUserAbleToViewCheckBoxIsNotClicked(manageOfficerTitle);
            string applicationManagement = parameters["applicationManagement"].Trim();
            userManagementPage.IsUserAbleToClickPermissionDropDown(applicationManagement);
            string manageApplications = parameters["manageApplications"].Trim();
            userManagementPage.IsUserAbleToViewCheckBoxIsNotClicked(manageApplications);
            string userManagement = parameters["userManagement"].Trim();
            userManagementPage.IsUserAbleToClickPermissionDropDown(userManagement);
            string manageUser = parameters["manageUser"].Trim();
            userManagementPage.IsUserAbleToViewCheckBoxIsNotClicked(manageUser);
        }
    }
}
