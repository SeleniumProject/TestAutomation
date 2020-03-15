// <copyright file="VerifyAddCommiteeTypeMandatoryFieldsMissingFromCommitteManagementTest.cs" company="PlaceholderCompany">

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
    public class VerifyAddCommiteeTypeMandatoryFieldsMissingFromCommitteManagementTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [Retry(2)]
        [TestCaseDescription(Id = "MCS2-1978", Name = "Rules and Exceptions - Add new Committee Type - Mandatory fields missing")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ManageCommitteeMandatoryFields" })]
        public void VerifyAddCommiteeTypeMandatoryFieldsMissingFromCommitteManagement(Dictionary<string, string> parameters)
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
            string manageCommitteeHierarchyHeader = parameters["manageCommitteeHierarchyHeader"].Trim();
            manageCommiteeTypePage.IsManageCommitteeHierarchyHeaderDisplayed(manageCommitteeHierarchyHeader);
            string membershipTypeEligibleTojoinHeader = parameters["membershipTypeEligibleTojoinHeader"].Trim();
            manageCommiteeTypePage.IsMembershipTypeEligibleTojoinHeaderDisplayed(membershipTypeEligibleTojoinHeader);
            string balanceRequiredHeader = parameters["balanceRequiredHeader"].Trim();
            manageCommiteeTypePage.IsBalanceRequiredHeaderDisplayed(balanceRequiredHeader);
            string enableCommitteeTypeonwebHeader = parameters["enableCommitteeTypeonwebHeader"].Trim();
            manageCommiteeTypePage.IsEnableCommitteeTypeonwebHeaderDisplayed(enableCommitteeTypeonwebHeader);
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            string errorCommitteeTypeName = parameters["errorCommitteeTypeName"].Trim();
            manageCommiteeTypePage.IsNewCommitteeTypeNameErrorMessageDisplayed(errorCommitteeTypeName);
            manageCommiteeTypePage.ScrollToCommitteeNameElement();
            string committeeTypeNameText = parameters["committeeTypeNameText"].Trim() + DateHelper.RandomString(3, false);
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameText);
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            string errorCommitteeTypeLevels = parameters["errorCommitteeTypeLevels"].Trim();
            manageCommiteeTypePage.IsNewCommitteeTypeLevelErrorMessageDisplayed(errorCommitteeTypeLevels);
        }
    }
}