﻿// <copyright file="VerifyOfficerTitleslistAddOfficersTitleErrormessageforalreadyexistTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MCS.Test.Automation.Nunit.Tests
{
    using System.Collections.Generic;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;
    using NUnit.Framework;

    [TestFixture]
    public class VerifyOfficerTitleslistAddOfficersTitleErrormessageforalreadyexistTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1514", Name = "Rules and Exceptions - Officer Titles list –   Add Officers Title – Error message for already exist")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewOfficerDataFields" })]
        public void VerifyOfficerTitleslistAddOfficersTitleErrormessageforalreadyexist(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var committeManagementPage = new CommitteManagementPage(this.DriverContext);
            var manageOfficerTitlePage = new ManageOfficerTitlePage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);

            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedInUserDisplayed(uname);
            homePage.IsCommitteeManagementSectionClickable();

            string manageofficerTitlelink = parameters["manageofficerTitlelink"].Trim();

            committeManagementPage.IsManageOffierTitlesClickable(manageofficerTitlelink);

            string cardtitletext = manageOfficerTitlePage.IsuserabletoGetTextofOfficerTitle(3);
            manageOfficerTitlePage.IsAddOfficerTitleButtonClickable();
            manageOfficerTitlePage.IsUserAbletoEnterOfficerTitleInTextBox(cardtitletext.Trim());
            manageOfficerTitlePage.IsAddNewOfficerSaveButtonClickable();
            string officerAlredyExistMessage = parameters["officerTitleAlredyExistmsg"].Trim();
            manageOfficerTitlePage.IsOfficerAlredyExistMessageDisplayed(officerAlredyExistMessage);
            manageOfficerTitlePage.ClickOnCloseButtonOfAddOfficerTitlePopUpWindow();

            string signouttext = parameters["signouttext"].Trim();
            homePage.IsSignOutClickable(signouttext);
        }
    }
}
