// <copyright file="ASTMInternalViewUserPageHintTextInSearchBoxTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalViewUserPageHintTextInSearchBoxTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-850", Name = "ASTM Staff Internal Application – Admin menu – User list Page - Hint text in search box")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "InternalLoginUserPageSearchData" })]
        public void ASTMInternalViewUserPageHintTextInSearchBox(Dictionary<string, string> parameters)
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
            string searchBoxHintText = parameters["searchBoxHintText"].Trim();
            userListPage.IsHintTextVisibleInSearchBox(searchBoxHintText);
        }
    }
}
