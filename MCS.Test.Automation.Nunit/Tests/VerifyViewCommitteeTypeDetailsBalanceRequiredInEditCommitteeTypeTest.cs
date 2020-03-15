// <copyright file="VerifyViewCommitteeTypeDetailsBalanceRequiredInEditCommitteeTypeTest.cs" company="PlaceholderCompany">
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
    public class VerifyViewCommitteeTypeDetailsBalanceRequiredInEditCommitteeTypeTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2024", Name = "Rules and Exceptions - Manage Committee Type - View Committee Type Details - Balance Required")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditRecordBalanceRulecheckinviewPage" })]
        public void VerifyViewCommitteeTypeDetailsBalanceRequiredInEditCommitteeType(Dictionary<string, string> parameters)
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
            string committeeTypeNameText = parameters["committeeTypeNameText"].Trim() + DateHelper.RandomString(4, false);
            string manageCommitteeHierarchyText = parameters["manageCommitteeHierarchy"].Trim();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameText);
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeHierarcyInTextBox(manageCommitteeHierarchyText);
            manageCommiteeTypePage.IsAddLevelButtonClickable();
            manageCommiteeTypePage.IsUserAbleToClickYesButtonForBalancerequired();
            manageCommiteeTypePage.SelectMembershipTypefromFirstListInBalanceRequired();
            string membershipTypeSelectionTextFirst = manageCommiteeTypePage.GetTextSelectMembershipTypefromFirstListInBalanceRequired();
            manageCommiteeTypePage.SelectMembershipTypefromSecondListInBalanceRequired();
            string membershipTypeSelectionTextSecond = manageCommiteeTypePage.GetTextSelectMembershipTypefromSecondListInBalanceRequired();
            string condition = parameters["operatorCondition"].Trim();
            manageCommiteeTypePage.IsOperatorSelectable(condition);
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            string successmsg = parameters["message"].Trim();
            manageCommiteeTypePage.IsNewCommitteeTypeaddedsuccessfullyDisplayed(successmsg);
            manageCommiteeTypePage.IsEditNewCommitteeTypeClickable(committeeTypeNameText);
            string balancerequiredRadioText = parameters["balancerequiredRadioText"].Trim();
            manageCommiteeTypePage.IsbalanceRequiredYesDisplayed(balancerequiredRadioText);
            manageCommiteeTypePage.IsnmbalanceRequiredOperatorDisplayed(condition);
            manageCommiteeTypePage.IsmemberClassificationTypeFirstSecond(membershipTypeSelectionTextFirst);
            manageCommiteeTypePage.IsmemberClassificationTypeFirstSecond(membershipTypeSelectionTextSecond);
        }
    }
}