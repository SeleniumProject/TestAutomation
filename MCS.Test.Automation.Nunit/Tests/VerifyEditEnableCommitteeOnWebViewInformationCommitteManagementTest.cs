// <copyright file="VerifyEditEnableCommitteeOnWebViewInformationCommitteManagementTest.cs" company="PlaceholderCompany">

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
    public class VerifyEditEnableCommitteeOnWebViewInformationCommitteManagementTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2014", Name = "Rules and Exceptions - Manage Committee Type - Enable Committee on Web - View information to be consumed by an application")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "CheckEnableCommitteTypeViewInfoOnWeb" })]
        public void VerifyEditEnableCommitteeOnWebViewInformationCommitteManagement(Dictionary<string, string> parameters)
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
            string isenableCommitteeTypeonweb = parameters["isenableCommitteeTypeonweb"].Trim();
            manageCommiteeTypePage.IsenableCommitteeTypeonwebCheckBoxClicked(isenableCommitteeTypeonweb);
            manageCommiteeTypePage.IsCommitteeTypeonwebEnablViewInfoDivClick(1);
            string designation = parameters["designation"].Trim();
            string title = parameters["title"].Trim();
            string scope = parameters["scope"].Trim();
            string overview = parameters["overview"].Trim();
            manageCommiteeTypePage.CheckCommitteeTypeonwebEnablViewInfoDivLables(designation, 1);
            manageCommiteeTypePage.CheckCommitteeTypeonwebEnablViewInfoDivLables(title, 1);
            manageCommiteeTypePage.CheckCommitteeTypeonwebEnablViewInfoDivLables(scope, 1);
            manageCommiteeTypePage.CheckCommitteeTypeonwebEnablViewInfoDivLables(overview, 1);
            manageCommiteeTypePage.IsCommitteeTypeonwebEnablViewInfoDivClick(2);
            manageCommiteeTypePage.CheckCommitteeTypeonwebEnablViewInfoDivLables(designation, 2);
            manageCommiteeTypePage.CheckCommitteeTypeonwebEnablViewInfoDivLables(title, 2);
            manageCommiteeTypePage.CheckCommitteeTypeonwebEnablViewInfoDivLables(scope, 2);
            manageCommiteeTypePage.CheckCommitteeTypeonwebEnablViewInfoDivLables(overview, 2);
        }
    }
}
