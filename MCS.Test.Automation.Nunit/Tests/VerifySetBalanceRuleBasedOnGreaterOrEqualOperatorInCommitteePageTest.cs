// <copyright file="VerifySetBalanceRuleBasedOnGreaterOrEqualOperatorInCommitteePageTest.cs" company="PlaceholderCompany">
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
    public class VerifySetBalanceRuleBasedOnGreaterOrEqualOperatorInCommitteePageTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2221", Name = "Rules and Exceptions - Manage Committee Type - Set Balance Rule based on Greater or equal Operator")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "SetBalanceRuleForGreaterOrEqualOperator" })]
        public void VerifySetBalanceRuleBasedOnGreaterOrEqualOperatorInCommitteePage(Dictionary<string, string> parameters)
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

            string committeeTypeNameText = DateHelper.RandomString(3, false) + parameters["committeeTypeNameText"].Trim();
            string manageCommitteeHierarchyText = parameters["manageCommitteeHierarchy"].Trim();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameText);
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeHierarcyInTextBox(manageCommitteeHierarchyText);
            manageCommiteeTypePage.IsAddLevelButtonClickable();

            manageCommiteeTypePage.IsUserAbleToClickYesButtonForBalancerequired();
            manageCommiteeTypePage.SelectMembershipTypefromFirstListInBalanceRequired();
            string condition = parameters["operatorCondition"].Trim();
            manageCommiteeTypePage.IsOperatorSelectable(condition);
            manageCommiteeTypePage.SelectMembershipTypefromSecondListInBalanceRequired();
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();

            string successmsg = parameters["message"].Trim();
            manageCommiteeTypePage.IsNewCommitteeTypeaddedsuccessfullyDisplayed(successmsg);

            manageCommiteeTypePage.IsEditNewCommitteeTypeClickable(committeeTypeNameText);
            manageCommiteeTypePage.IsOperatorConditionVisibleAsExpected(condition);
        }
    }
}