// <copyright file="REVerifyErrorMessageForNotSelectingOperatorInCommitteeTypeTest.cs" company="PlaceholderCompany">
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
    public class REVerifyErrorMessageForNotSelectingOperatorInCommitteeTypeTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2235", Name = "Rules and Exceptions - Set Balance Rule - Error message for not selecting operator")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ErrorMessageForCommitteeOperator" })]
        public void REVerifyErrorMessageForNotSelectingOperatorInCommitteeType(Dictionary<string, string> parameters)
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
            string committeeTypeNameText = parameters["committeeTypeNameText"].Trim() + DateHelper.RandomString(3, false);
            string manageCommitteeHierarchyText = parameters["manageCommitteeHierarchy"].Trim();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameText);
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeHierarcyInTextBox(manageCommitteeHierarchyText);
            manageCommiteeTypePage.IsAddLevelButtonClickable();
            manageCommiteeTypePage.IsUserAbleToClickYesButtonForBalancerequired();
            manageCommiteeTypePage.SelectMembershipTypefromFirstListInBalanceRequired();
            manageCommiteeTypePage.SelectMembershipTypefromSecondListInBalanceRequired();
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            string errorMessage = parameters["errorMessage"].Trim();
            manageCommiteeTypePage.IsErrorMessageDisplayedForNotSelectingOperator(errorMessage);
        }
    }
}