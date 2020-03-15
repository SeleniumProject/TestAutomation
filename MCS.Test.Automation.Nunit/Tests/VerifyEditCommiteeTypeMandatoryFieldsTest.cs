// <copyright file="VerifyEditCommiteeTypeMandatoryFieldsTest.cs" company="PlaceholderCompany">

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
    public class VerifyEditCommiteeTypeMandatoryFieldsTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [Retry(2)]
        [TestCaseDescription(Id = "MCS2-2004", Name = "Rules and Exceptions - Edit and Save Committee Type Details")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditCommitteeMandatoryFields" })]
        public void VerifyEditCommiteeTypeMandatoryFields(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var committeManagementPage = new CommitteManagementPage(this.DriverContext);
            var manageCommiteeTypePage = new ManageCommitteeTypesPage(this.DriverContext);
            loginPage.OpenLandingPage();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsLoggedInUserDisplayed(uname);
            homePage.IsCommitteeManagementSectionClickable();

            string manageCommiteeTypesTitlelink = parameters["manageCommiteeTypesTitlelink"].Trim();
            committeManagementPage.IsManageCommitteTypeClickable(manageCommiteeTypesTitlelink);
            string header = parameters["header"].Trim();
            manageCommiteeTypePage.IsManageCommitteTypeHeaderDisplayed(header);

            manageCommiteeTypePage.IsAddCommitteeTypeButtonClickable();
            string committeeTypeNameText = DateHelper.RandomString(3, false) + parameters["committeeTypeNameText"].Trim();
            string manageCommitteeHierarchyText = parameters["manageCommitteeHierarchy"].Trim();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameText);
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeHierarcyInTextBox(manageCommitteeHierarchyText);
            manageCommiteeTypePage.IsAddLevelButtonClickable();
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            string successmsg = parameters["message"].Trim();
            manageCommiteeTypePage.IsNewCommitteeTypeaddedsuccessfullyDisplayed(successmsg);

            manageCommiteeTypePage.IsEditNewCommitteeTypeClickable(committeeTypeNameText);
            manageCommiteeTypePage.IsEditButtonCommitteeTypeClickable();
            string committeeTypeNameSecondText = DateHelper.RandomString(3, false) + parameters["committeeTypeNameText"].Trim();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameSecondText);
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();

            string updateSuccessMsg = parameters["updateSuccessMsg"].Trim();
            manageCommiteeTypePage.IsNewCommitteeTypeaddedsuccessfullyDisplayed(updateSuccessMsg);
        }
    }
}