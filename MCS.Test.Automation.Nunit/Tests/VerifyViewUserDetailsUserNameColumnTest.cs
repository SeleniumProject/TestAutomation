// <copyright file="VerifyViewUserDetailsUserNameColumnTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyViewUserDetailsUserNameColumnTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-741", Name = "Rules and Exceptions - User Management - View User List Page - View User Records in tabular format - Username column")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewUserDetails" })]
        public void VerifyViewUserDetailsUserNameColumn(Dictionary<string, string> parameters)
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
            string username = userManagementPage.IsUserIsAbleToSelectUserNameFromList(0);
            string viewDetails = parameters["viewDetails"].Trim();
            userManagementPage.IsUserAbleToViewUserDetails(viewDetails);
            userManagementPage.IsUserAbleToUserNameFieldValueInView(username);
        }
    }
}
