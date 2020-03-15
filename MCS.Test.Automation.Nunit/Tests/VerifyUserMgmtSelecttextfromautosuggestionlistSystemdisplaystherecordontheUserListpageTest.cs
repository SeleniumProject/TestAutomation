// <copyright file="VerifyUserMgmtSelecttextfromautosuggestionlistSystemdisplaystherecordontheUserListpageTest.cs" company="PlaceholderCompany">
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
    public class VerifyUserMgmtSelecttextfromautosuggestionlistSystemdisplaystherecordontheUserListpageTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-735", Name = "Rules and Exceptions - User Management - Select text from auto-suggestion list-System displays the record on the User List page")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "userSearchBoxAutoSuggest" })]
        public void VerifyUserMgmtSelecttextfromautosuggestionlistSystemdisplaystherecordontheUserListpage(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var userManagementPage = new UserManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsLoggedUserDisplayed();

            homePage.IsUserManagementSectionClickable();

            string searchboxPlaceHolder = parameters["searchboxplaceholder"].Trim();
            userManagementPage.IsHintTextVisibleInSearchBox(searchboxPlaceHolder);

            string username = parameters["username"].Trim();
            userManagementPage.EnterUserNameAndSelectAutoSuggestion(username);

            string usernameAfterSearch = parameters["usernameAfterSearch"].Trim();
            userManagementPage.IsExpectedUserNameDisplayedAfterSearchOperation(usernameAfterSearch);

            string nameAfterSearch = parameters["nameAfterSearch"].Trim();
            userManagementPage.IsExpectedNameDisplayedAfterSearchOperation(nameAfterSearch);

            string useremailAfterSearch = parameters["useremailAfterSearch"].Trim();
            userManagementPage.IsExpectedEmailDisplayedAfterSearchOperation(useremailAfterSearch);

            string userRoleAfterSearch = parameters["userRoleAfterSearch"].Trim();
            userManagementPage.IsExpectedRoleDisplayedAfterSearchOperation(userRoleAfterSearch);
        }
    }
}
