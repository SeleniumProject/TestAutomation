// <copyright file="ASTMStaffInternalValidateSystemGeneratedUniqueTaskIdForNewRenewalTaskTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Extensions;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMStaffInternalValidateSystemGeneratedUniqueTaskIdForNewRenewalTaskTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1215", Name = "ASTM staff internal application - Login as ASTM staff - Renewal Tasks header menu - Renewal Tasks List page - Add and Save a New Renewal Task - System generates unique Task ID when a new Task record is created in the system")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "SystemGeneratedUniqueIdForRenewalTask" })]
        public void ASTMStaffInternalValidateSystemGeneratedUniqueTaskIdForNewRenewalTask(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            internalhomePage.IsCustomerLogoDisplayed();
            internalhomePage.IsLoggedUserDisplayed();
            internalhomePage.IsRenewalTasksMenuClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            renewalTasksPage.IsAddTasksBtnClickable();
            renewalTasksPage.IsAddTasksPopupVisible();
            string title = parameters["title"].Trim() + DateHelper.RandomString(3, false);
            string startDate = DateHelper.CurrentDateInMMDDYYYY;
            string endDate = DateHelper.TomorrowDateInMMDDYYYY;
            string descriptionText = parameters["descriptionText"].Trim();
            string assigneeName = parameters["assigneeName"].Trim();
            renewalTasksPage.IsUserableToEnterTitle(title);
            string defaultRenewalYear = renewalTasksPage.IsGetDefaultRenewalYear();
            renewalTasksPage.IsUserAbleToSelectStartDate(startDate);
            renewalTasksPage.IsUserAbleToSelectEndDate(endDate);
            renewalTasksPage.IsUserAbleToEnterTextInDescription(descriptionText);
            renewalTasksPage.IsUserAbleToEnterAssigneeName(assigneeName);
            renewalTasksPage.IsUserableToSaveTask();
            string successmsg = parameters["successmsg"].Trim();
            renewalTasksPage.IsSuccessMessageDisplayed(successmsg);
            renewalTasksPage.IsEnterTextInRenewalTaskSearchBoxAndClickSearchIcon(title);
            string systemGeneratedRenewalTaskID = renewalTasksPage.IsSystemGeneratedUniqueTaskID();
            bool isPrefixREN = renewalTasksPage.IsSystemGeneratedUniqueTaskIdWithPrefixREN(systemGeneratedRenewalTaskID);
            renewalTasksPage.IsUniqueIDWithSelectedYear(systemGeneratedRenewalTaskID, defaultRenewalYear);
        }
    }
}
