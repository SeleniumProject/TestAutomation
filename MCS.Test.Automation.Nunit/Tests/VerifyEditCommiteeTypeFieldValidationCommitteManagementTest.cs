// <copyright file="VerifyEditCommiteeTypeFieldValidationCommitteManagement.cs" company="PlaceholderCompany">

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
    public class VerifyEditCommiteeTypeFieldValidationCommitteManagementTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2007", Name = "Rules and Exceptions - Edit Committee Type Details - Field Validation - Committee Type Name")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ManageCommitteeTypesValidationBlank" })]
        public void VerifyEditCommiteeTypeFieldValidationCommitteManagement(Dictionary<string, string> parameters)
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
            string manageCommitteeHierarchyHeader = parameters["manageCommitteeHierarchyHeader"].Trim();
            manageCommiteeTypePage.IsManageCommitteeHierarchyHeaderDisplayed(manageCommitteeHierarchyHeader);
            string membershipTypeEligibleTojoinHeader = parameters["membershipTypeEligibleTojoinHeader"].Trim();
            manageCommiteeTypePage.IsMembershipTypeEligibleTojoinHeaderDisplayed(membershipTypeEligibleTojoinHeader);
            string balanceRequiredHeader = parameters["balanceRequiredHeader"].Trim();
            manageCommiteeTypePage.IsBalanceRequiredHeaderDisplayed(balanceRequiredHeader);
            string enableCommitteeTypeonwebHeader = parameters["enableCommitteeTypeonwebHeader"].Trim();
            manageCommiteeTypePage.IsEnableCommitteeTypeonwebHeaderDisplayed(enableCommitteeTypeonwebHeader);
            string committeeTypeNameText = parameters["committeeTypeNameText"].Trim() + DateHelper.RandomString(4, false);
            string manageCommitteeHierarchyText = parameters["manageCommitteeHierarchy"].Trim();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameText);
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeHierarcyInTextBox(manageCommitteeHierarchyText);
            manageCommiteeTypePage.IsAddLevelButtonClickable();
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            string successmgs = parameters["message"].Trim();
            manageCommiteeTypePage.IsNewCommitteeTypeaddedsuccessfullyDisplayed(successmgs);
            manageCommiteeTypePage.IsAddCommitteeTypeButtonClickable();
            string committeeTypeNameSecondText = parameters["committeeTypeNameText"].Trim() + DateHelper.RandomString(4, false);
            string manageCommitteeHierarchySecondText = parameters["manageCommitteeHierarchy"].Trim();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameSecondText);
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeHierarcyInTextBox(manageCommitteeHierarchySecondText);
            manageCommiteeTypePage.IsAddLevelButtonClickable();
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            manageCommiteeTypePage.IsEditNewCommitteeTypeClickable(committeeTypeNameSecondText);
            manageCommiteeTypePage.IsEditButtonCommitteeTypeClickable();
            manageCommiteeTypePage.IsCommitteeTypeTextAttributeDisplayed();
            string errormessageCommiteeInputBlank = parameters["errormessageCommiteeInputBlank"].Trim();
            manageCommiteeTypePage.IsCommitteeTypeTextBlankErrorMessageDisplayed(errormessageCommiteeInputBlank);
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameText);
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            string errorMessageCommiteeAlreadyExists = parameters["errorMessageCommiteeAlreadyExists"].Trim();
            manageCommiteeTypePage.IsCommitteeTypeTextAlreadyExistsErrorMessageDisplayed(errorMessageCommiteeAlreadyExists);
            string committeeTypeNameThirdText = parameters["committeeTypeNameText"].Trim() + DateHelper.RandomString(4, false) + DateHelper.RandomInteger();
            manageCommiteeTypePage.ScrollToTopWebPage();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameThirdText);
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
        }
    }
}
