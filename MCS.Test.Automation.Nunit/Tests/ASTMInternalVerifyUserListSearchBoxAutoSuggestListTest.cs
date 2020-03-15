// <copyright file="ASTMInternalVerifyUserListSearchBoxAutoSuggestListTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalVerifyUserListSearchBoxAutoSuggestListTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-853", Name = "ASTM Staff Internal Application – Admin menu – User list Page- Search box – Message")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "InternalAutoSuggestionListData" })]
        public void ASTMInternalVerifyUserListSearchBoxAutoSuggestList(Dictionary<string, string> parameters)
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

            string noOfItemsPerPage = parameters["noOfItemsPerPage"].Trim();
            userListPage.IsUserableToSelectNoOfItemsPerPage(noOfItemsPerPage);

            string searchTextToEnter = parameters["searchTextToEnter"].Trim();
            userListPage.IsUserableToGetCountOfSuggenstionsFromSearchBox(searchTextToEnter, 10);
        }
    }
}
