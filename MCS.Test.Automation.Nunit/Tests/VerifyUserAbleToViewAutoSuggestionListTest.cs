// <copyright file="VerifyUserAbleToViewAutoSuggestionListTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyUserAbleToViewAutoSuggestionListTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2- 733", Name =" Rules and Exceptions - User Management - User is able to view auto - suggestions based on the input provided in the Search box")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "UserAutoSuggestionsListData" })]
        public void VerifyUserAbleToViewAutoSuggestionList(Dictionary<string, string> parameters)
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

            string searchTextToEnter = parameters["searchTextToEnter"].Trim();
            userManagementPage.IsUserableToGetCountOfSuggenstionsFromSearchBox(searchTextToEnter, 10);
        }
    }
}