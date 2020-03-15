// <copyright file="ASTMInternalVerifyUserListSearchBoxMessageTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalVerifyUserListSearchBoxMessageTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-853", Name = "ASTM Staff Internal Application – Admin menu – User list Page- Search box – Message")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "InternalLoginSearchBoxMessageData" })]
        public void ASTMInternalVerifySearchBoxMessageTest(Dictionary<string, string> parameters)
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

            string searchTextToEnter = parameters["searchTextToEnter"].Trim() + DateHelper.RandomString(3, false);
            userListPage.IsUserableToEnterTextInSearchBox(searchTextToEnter);

            string searchMessageDisplayed = parameters["searchMessageDisplayed"].Trim();
            userListPage.IsSearchMessageDisplayed(searchMessageDisplayed);
        }
    }
}
