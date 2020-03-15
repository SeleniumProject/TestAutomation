// <copyright file="VerifyUserabletoChangeBalanceRuleWhileUpdatingRecordInCommitteeTypeTest.cs" company="PlaceholderCompany">
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
    public class VerifyUserabletoChangeBalanceRuleWhileUpdatingRecordInCommitteeTypeTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2230", Name = "Rules and Exceptions - Change Balance Rule when updating the record")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditRecordBalanceRule" })]
        public void VerifyUserabletoChangeBalanceRuleWhileUpdatingRecordInCommitteeType(Dictionary<string, string> parameters)
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

            manageCommiteeTypePage.IsUserAbleToClickYesButtonForBalancerequired();
            manageCommiteeTypePage.SelectMembershipTypefromFirstListInBalanceRequired();
            manageCommiteeTypePage.SelectMembershipTypefromSecondListInBalanceRequired();
            string condition = parameters["operatorCondition"].Trim();
            manageCommiteeTypePage.IsOperatorSelectable(condition);
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();

            string updateSuccessMsg = parameters["updateSuccessMsg"].Trim();
            manageCommiteeTypePage.IsNewCommitteeTypeaddedsuccessfullyDisplayed(updateSuccessMsg);
        }
    }
}