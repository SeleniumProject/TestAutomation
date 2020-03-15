// <copyright file="ASTMInternalVerifyUserPageSearchResultsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalVerifyUserPageSearchResultsTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-855", Name = "ASTM Staff Internal Application – Admin menu – User list Page- Search box – Search Result")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "InternalUserSearchResultsdata" })]
        public void ASTMInternalVerifyUserPageSearchResults(Dictionary<string, string> parameters)
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

            string searchTextToEnter = parameters["searchTextToEnter"].Trim();
            userListPage.EnterTextAndSelectAutoSuggestion(searchTextToEnter);

            string usernameAfterSearch = parameters["usernameAfterSearch"].Trim();
            userListPage.IsExpectedUserNameDisplayedAfterSearchOperation(usernameAfterSearch);

            string nameAfterSearch = parameters["nameAfterSearch"].Trim();
            userListPage.IsExpectedNameDisplayedAfterSearchOperation(nameAfterSearch);

            string useremailAfterSearch = parameters["useremailAfterSearch"].Trim();
            userListPage.IsExpectedEmailDisplayedAfterSearchOperation(useremailAfterSearch);

            string userRoleAfterSearch = parameters["userRoleAfterSearch"].Trim();
            userListPage.IsExpectedRoleDisplayedAfterSearchOperation(userRoleAfterSearch);
        }
    }
}
