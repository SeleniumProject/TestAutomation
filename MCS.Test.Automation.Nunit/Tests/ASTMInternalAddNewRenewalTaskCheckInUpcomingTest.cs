// <copyright file="ASTMInternalAddNewRenewalTaskCheckInUpcomingTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalAddNewRenewalTaskCheckInUpcomingTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1217", Name = "ASTM staff internal application - Login as ASTM staff - Renewal Tasks header menu - Renewal Tasks List page - Add and Save a New Renewal Task - System displays status of the Task as Upcoming if the Start Date of that Task is future Date")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternalAddNewTask" })]
        public void ASTMInternalAddNewRenewalTaskCheckInUpcoming(Dictionary<string, string> parameters)
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
            string startDate = DateHelper.GetFutureDateInMMDDYYYY(200);
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
            renewalTasksPage.IsSortBtnClickable();
            renewalTasksPage.IsSortEndDateBtnClickable();
            renewalTasksPage.IsUpcomingRenewalTaskTitleDisplayed(title);
        }
    }
}
