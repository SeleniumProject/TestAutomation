// <copyright file="ASTMInternalAddNewRenewalTaskCheckBannerTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalAddNewRenewalTaskCheckBannerTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1235", Name = "ASTM staff internal application - Login as ASTM staff - View Renewal Task header menu - Renewal Task List page - Renewal Task Details page - View Inactive tag on Banner present at the top on Renewal Task Details Page If the Renewal Task is Inactive")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternalAddNewTask" })]
        public void ASTMInternalAddNewRenewalTaskCheckBanner(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            internalhomePage.IsLoggedUserDisplayed();

            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            renewalTasksPage.IsAddTasksBtnClickable();
            renewalTasksPage.IsAddTasksPopupVisible();
            string title = parameters["title"].Trim() + DateHelper.RandomString(3, false);
            string startDate = DateHelper.CurrentDateInMMDDYYYY;
            string endDate = DateHelper.GetFutureDateInMMDDYYYY(201);

            string descriptionText = parameters["descriptionText"].Trim();
            string assigneeName = parameters["assigneeName"].Trim();
            renewalTasksPage.IsUserableToEnterTitle(title);
            renewalTasksPage.IsUserAbleToSelectStartDate(startDate);
            renewalTasksPage.IsUserAbleToSelectEndDate(endDate);
            renewalTasksPage.IsUserAbleToEnterTextInDescription(descriptionText);
            renewalTasksPage.IsUserAbleToEnterAssigneeName(assigneeName);
            renewalTasksPage.IsUserableToSaveTask();
            string successmsg = parameters["successmsg"].Trim();
            renewalTasksPage.IsSuccessMessageDisplayed(successmsg);
            renewalTasksPage.IsOpenSortBtnClickable();
            renewalTasksPage.IsOpenSortEndDateBtnClickable();
            renewalTasksPage.IsOpenRenewalTaskTitleDisplayed(title);
            renewalTasksPage.IsRenewalTaskTitleBtnClickable(title);

            renewalTasksPage.IsBannerStatusDisplayed();
            renewalTasksPage.IsBannerTaskIdDisplayed();
            renewalTasksPage.IsBannerRenewalYearDisplayed();
            renewalTasksPage.IsBannerAssigneeDisplayed();
            renewalTasksPage.IsBannerTaskOwnerDisplayed();
            renewalTasksPage.IsBannerWatchersCountDisplayed();
            renewalTasksPage.IsBannerDateTimeStampDisplayed();

            renewalTasksPage.IsWatcherStampDisplayed();
            renewalTasksPage.IsSetReminderDisplayed();
            renewalTasksPage.IsCloneTaskDisplayed();
        }
    }
}
