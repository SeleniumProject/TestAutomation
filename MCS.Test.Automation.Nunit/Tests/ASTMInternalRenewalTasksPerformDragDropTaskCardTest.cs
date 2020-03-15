// <copyright file="ASTMInternalRenewalTasksPerformDragDropTaskCardTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalRenewalTasksPerformDragDropTaskCardTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1203 ", Name = "ASTM staff internal application - Renewal Tasks header menu - Renewal Tasks List page - Perform Drag and Drop of Task card")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternalAddNewTaskDragDrop" })]
        public void ASTMInternalRenewalTasksPerformDragDropTaskCard(Dictionary<string, string> parameters)
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
            renewalTasksPage.IsUserableToEnterTitleInSearchBox(title);
            renewalTasksPage.IsRenewalSearchBtnClickable();
            renewalTasksPage.IsUpcomingRenewalTaskTitleDisplayed(title);
            string upcoming = parameters["upcoming"].Trim();
            renewalTasksPage.IsRenewalHeaderDisplayed(upcoming);
            string open = parameters["open"].Trim();
            renewalTasksPage.IsRenewalHeaderDisplayed(open);
            string done = parameters["done"].Trim();
            renewalTasksPage.IsRenewalHeaderDisplayed(done);
            renewalTasksPage.IsAssigneeRenewalTaskVisible();
            renewalTasksPage.IsYearDateRenewalTaskVisible();
            renewalTasksPage.IsStartDateRenewalTaskVisible();
            renewalTasksPage.IsEndDateRenewalTaskVisible();
            renewalTasksPage.IsTaskIDRenewalTaskVisible();
            renewalTasksPage.IsClockIconRenewalTaskVisible();
            renewalTasksPage.IsCopyIconRenewalTaskVisible();
            renewalTasksPage.IsEyeIconRenewalTaskVisible();
            renewalTasksPage.DragEligibleToOpenFromUpComing();
            string dragsucesssmsg = parameters["dragsucesssmsg"].Trim();
            renewalTasksPage.IsSuccessMessageDisplayed(dragsucesssmsg);
            renewalTasksPage.IsUserableToEnterTitleInSearchBoxClear();
            renewalTasksPage.IsRenewalSearchBtnClickable();
            renewalTasksPage.IsRenewalSearchBtnClickable();
            string firstIndexText = renewalTasksPage.DragEligibleUpComingIndexWise(1, 5);
            renewalTasksPage.ValidateRenewalTaskFirstRecordCardName(firstIndexText, 1);
        }
    }
}
