// <copyright file="VerifyMandatoryFieldsInAddOfficerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MCS.Test.Automation.Nunit.Tests
{
    using System.Collections.Generic;
    using MCS.Test.Automation.Tests.NUnit;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;
    using NUnit.Framework;

    [TestFixture]
    public class VerifyMandatoryFieldsInAddOfficerTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1519 ", Name = "Rules and Exceptions - Officer Titles list – Add Officers Title – Mandatory Field")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewOfficerMandatoryField" })]
        public void VerifyMandatoryFieldsInAddOfficer(Dictionary<string, string> parameters)
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
            string officerTitle = parameters["officerTitle"].Trim();
            manageOfficerTitlePage.IsUserAbletoEnterOfficerTitleInTextBox(officerTitle);
            manageOfficerTitlePage.IsAddNewOfficerSaveButtonClickable();
            string officerMandatoryMessage = parameters["officerMandatoryMessage"].Trim();
            manageOfficerTitlePage.IsOfficerTitleMandatory(officerMandatoryMessage);
            manageOfficerTitlePage.ClickOnCloseButtonOfAddOfficerTitlePopUpWindow();
        }
    }
}
