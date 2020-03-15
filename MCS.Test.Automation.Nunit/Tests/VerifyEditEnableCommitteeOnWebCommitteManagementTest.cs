// <copyright file="VerifyEditEnableCommitteeOnWebCommitteManagement.cs" company="PlaceholderCompany">

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
    public class VerifyEditEnableCommitteeOnWebCommitteManagementTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2016", Name = "Rules and Exceptions - Manage Committee Type - Enable Committee on Web - Update the details")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "CheckEnableCommitteTypeOnWeb" })]
        public void VerifyEditEnableCommitteeOnWebCommitteManagement(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var committeManagementPage = new CommitteManagementPage(this.DriverContext);
            var manageCommiteeTypePage = new ManageCommitteeTypesPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedInUserDisplayed(uname);
            homePage.IsCommitteeManagementSectionClickable();
            string manageCommiteeTypesTitlelink = parameters["manageCommiteeTypesTitlelink"].Trim();
            committeManagementPage.IsManageCommitteTypeClickable(manageCommiteeTypesTitlelink);
            string header = parameters["header"].Trim();
            manageCommiteeTypePage.IsManageCommitteTypeHeaderDisplayed(header);
            manageCommiteeTypePage.IsAddCommitteeTypeButtonClickable();
            string committeeTypeNameText = parameters["committeeTypeNameText"].Trim() + DateHelper.RandomString(4, false);
            string manageCommitteeHierarchyText = parameters["manageCommitteeHierarchy"].Trim();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameText);
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeHierarcyInTextBox(manageCommitteeHierarchyText);
            manageCommiteeTypePage.IsAddLevelButtonClickable();
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            string successmgs = parameters["message"].Trim();
            manageCommiteeTypePage.IsNewCommitteeTypeaddedsuccessfullyDisplayed(successmgs);
            manageCommiteeTypePage.IsEditNewCommitteeTypeClickable(committeeTypeNameText);
            manageCommiteeTypePage.IsEditButtonCommitteeTypeClickable();
            string isenableCommitteeTypeonweb = parameters["isenableCommitteeTypeonweb"].Trim();
            manageCommiteeTypePage.IsenableCommitteeTypeonwebCheckBoxClicked(isenableCommitteeTypeonweb);
            manageCommiteeTypePage.IsenableCommitteeTypeonwebCheckBoxDiv();
            manageCommiteeTypePage.IsenableCommitteeTypeonwebCheckBoxClicked(isenableCommitteeTypeonweb);
            manageCommiteeTypePage.IsenableCommitteeTypeonwebCheckBoxDiv();
        }
    }
}
