// <copyright file="VerifyViewUserDetailsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyViewUserDetailsTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-747", Name = "Rules and Exceptions - User Management - View User List Page - Username column - View User Details page")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewUserDetails" })]
        public void VerifyViewUserDetails(Dictionary<string, string> parameters)
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
            string userNameColumn = parameters["userNameColumn"].Trim();
            userManagementPage.IsUserAbleToViewUserNameColumn(userNameColumn);
            string nameColumn = parameters["nameColumn"].Trim();
            userManagementPage.IsUserAbleToViewNameColumn(nameColumn);
            string emailColumn = parameters["emailColumn"].Trim();
            userManagementPage.IsUserAbleToViewEmailColumn(emailColumn);
            string userTypeColumn = parameters["userTypeColumn"].Trim();
            userManagementPage.IsUserAbleToViewUserTypeColumn(userTypeColumn);
            string statusColumn = parameters["statusColumn"].Trim();
            userManagementPage.IsUserAbleToViewStatusColumn(statusColumn);
            string username = userManagementPage.IsUserIsAbleToSelectUserNameFromList(1);
            string viewDetails = parameters["viewDetails"].Trim();
            userManagementPage.IsUserAbleToViewUserDetails(viewDetails);
            string userName = parameters["userNameField"].Trim();
            userManagementPage.IsUserAbleToViewUserName(userName);
            string lastLogin = parameters["lastLogin"].Trim();
            userManagementPage.IsUserAbleToViewLastLogin(lastLogin);
            string emailField = parameters["EmailField"].Trim();
            userManagementPage.IsUserAbleToViewEmail(emailField);
            string lastNameField = parameters["lastNameField"].Trim();
            userManagementPage.IsUserAbleToViewLastName(lastNameField);
            string firstNameField = parameters["firstNameField"].Trim();
            userManagementPage.IsUserAbleToViewFirstName(firstNameField);
            string phone = parameters["phone"].Trim();
            userManagementPage.IsUserAbleToViewPhone(phone);
            string status = parameters["status"].Trim();
            userManagementPage.IsUserAbleToViewStatus(status);
            string userTypeField = parameters["userType"].Trim();
            userManagementPage.IsUserAbleToViewUserType(userTypeField);
            string privileges = parameters["privileges"].Trim();
            userManagementPage.IsUserAbleToViewPrivileges(privileges);
        }
    }
}
