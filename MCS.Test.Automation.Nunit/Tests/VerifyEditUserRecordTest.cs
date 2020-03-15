// <copyright file="VerifyEditUserRecordTest.cs" company="PlaceholderCompany">
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
    public class VerifyEditUserRecordTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-", Name = "Rules and Exceptions - ")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditUserDetails" })]
        public void VerifyEditUserRecord(Dictionary<string, string> parameters)
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
            string userrecordname = parameters["userrecordname"].Trim();
            string headername = parameters["headername"].Trim();
            homePage.IsUsersHeaderVisible(headername);

            homePage.IsUserRecordclickable(userrecordname);
            string headernameforViewpage = parameters["headernameforViewpage"].Trim();
            homePage.IsViewUsersPageDisplayed(headernameforViewpage);
            string headernameforeditUserPage = parameters["headernameforeditUserPage"].Trim();
            userManagementPage.IsEditBtnClickable(headernameforeditUserPage);

            userManagementPage.AddPreviligesToUser(2);

            // userManagementPage.IsUpdateBtnClickable();
            // string successmsg = parameters["successmsg"].Trim();
            // userManagementPage.IsSuccessfullMessageDisplayedForNewUser(successmsg);
        }
    }
}
