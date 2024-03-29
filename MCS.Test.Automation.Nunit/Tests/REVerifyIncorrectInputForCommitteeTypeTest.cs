﻿// <copyright file="REVerifyIncorrectInputForCommitteeTypeTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System;
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class REVerifyIncorrectInputForCommitteeTypeTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1979", Name = "ASTM staff internal application - Login as ASTM staff - View Renewal Task header menu - Renewal Task List page - Renewal Task Details page - View Inactive tag on Banner present at the top on Renewal Task Details Page If the Renewal Task is Inactive")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "RECommitteeIncorrectInput" })]
        public void REVerifyIncorrectInputForCommitteeType(Dictionary<string, string> parameters)
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
            string committeeTypeNameText = parameters["committeeTypeNameText"].Trim() + DateHelper.RandomString(3, false);
            string manageCommitteeHierarchyText = parameters["manageCommitteeHierarchy"].Trim();
            manageCommiteeTypePage.IsUserAbletoEnterCommitteeTypeInTextBox(committeeTypeNameText);
            manageCommiteeTypePage.IsLimitedPersonsSelectedAndEnterNumber("-23");
            manageCommiteeTypePage.IsAddNewCommitteeTypeSaveButtonClickable();
            string errorMessage = parameters["errorMessage"].Trim();
            manageCommiteeTypePage.IserrorMsgDisplayedForIncorrectInput(errorMessage);
         }
    }
}