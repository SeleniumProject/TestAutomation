// <copyright file="ASTMInternalViewUserPageListColumnsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalViewUserPageListColumnsTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-829", Name = "ASTM Staff Internal Application – Admin menu – User list Page - Columns")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "InternalLoginUserlistPagedata" })]
        public void ASTMInternalViewUserPageListColumns(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var userListPage = new InternallStaffUsersPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();

            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);

            homePage.IsLoggedInUserDisplayed(uname);
            homePage.SelectUserPermissionFromAdminMenuitem();
            string userNameText = parameters["userNameText"].Trim();
            userListPage.IsUserNameColumnVisibleInUsersPageList(userNameText);

            string nameText = parameters["nameText"].Trim();
            userListPage.IsNameColumnVisibleInUserspageList(nameText);

            string emailID = parameters["emailID"].Trim();
            userListPage.IsEmailColumnVisibleInUserspageList(emailID);

            string roleText = parameters["roleText"].Trim();
            userListPage.IsRoleColumnVisibleInUserspageList(roleText);

            string actionText = parameters["actionText"].Trim();
            userListPage.IsActionColumnVisibleInUserspageList(actionText);
        }
    }
}
