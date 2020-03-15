// <copyright file="VerifyEnterthetextinthesearchboxSystemdisplaystheonUserListpageTest.cs" company="PlaceholderCompany">
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
    public class VerifyEnterthetextinthesearchboxSystemdisplaystheonUserListpageTest : ProjectTestBase
    {
        [Test]
        [Category("smoke")]
        [TestCaseDescription(Id = "MCS2-734", Name = "Rules and Exceptions - User Management - Enter the text in the search box-System displays the record on the User List page")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "UserManagementDetails" })]
        public void VerifyEnterthetextinthesearchboxSystemdisplaystheonUserListpage(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var userManagementPage = new UserManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsUserManagementSectionClickable();
            userManagementPage.IsAddUserButtonClickable();
            string username = parameters["username"].Trim() + DateHelper.CurrentTimeStamp;
            userManagementPage.EnterUserName(username);
            userManagementPage.IsValidateInADButtonClickable();
            userManagementPage.AddPreviligesToUser(0);
            userManagementPage.SaveUserCreation();
            userManagementPage.VerifyCreatedUserIsPresent(username);
            string successmsg = parameters["successmsg"].Trim();
            userManagementPage.IsSuccessfullMessageDisplayedForNewUser(successmsg);
        }
    }
}
