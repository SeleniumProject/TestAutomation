// <copyright file="ASTMInternalAddNewRenewalTaskDependentTaskSortTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalAddNewRenewalTaskDependentTaskSortTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-815", Name = "ASTM Staff Internal Application –  Renewal Tasks Header menu – Task list Page- Task details page – Dependent tasks – Sort order")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternalAddNewTaskDependentSort" })]
        public void ASTMInternalAddNewRenewalTaskDependentTaskSort(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsLoggedUserDisplayed();
            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            renewalTasksPage.IsAddTasksBtnClickable();
            renewalTasksPage.IsAddTasksPopupVisible();
            string title = parameters["title"].Trim() + DateHelper.RandomInteger();
            string startDate = DateHelper.CurrentDateInMMDDYYYY;
            string endDate = DateHelper.TomorrowDateInMMDDYYYY;
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
            renewalTasksPage.IsAddTasksBtnClickable();
            renewalTasksPage.IsAddTasksPopupVisible();
            string title1 = parameters["title"].Trim() + DateHelper.RandomInteger();
            renewalTasksPage.IsUserableToEnterTitle(title1);
            renewalTasksPage.IsUserAbleToSelectStartDate(startDate);
            renewalTasksPage.IsUserAbleToSelectEndDate(endDate);
            renewalTasksPage.IsUserAbleToEnterTextInDescription(descriptionText);
            renewalTasksPage.IsUserAbleToEnterAssigneeName(assigneeName);
            renewalTasksPage.IsUserableToSaveTask();
            renewalTasksPage.IsSuccessMessageDisplayed(successmsg);
            renewalTasksPage.IsAddTasksBtnClickable();
            renewalTasksPage.IsAddTasksPopupVisible();
            string title2 = parameters["title"].Trim() + DateHelper.RandomInteger();
            renewalTasksPage.IsUserableToEnterTitle(title2);
            renewalTasksPage.IsUserAbleToSelectStartDate(startDate);
            renewalTasksPage.IsUserAbleToSelectEndDate(endDate);
            renewalTasksPage.IsUserAbleToEnterTextInDescription(descriptionText);
            renewalTasksPage.IsUserAbleToEnterAssigneeName(assigneeName);
            renewalTasksPage.IsRenewalDepedent(title);
            renewalTasksPage.IsRenewalDepedent(title1);
            renewalTasksPage.IsUserableToSaveTask();
            renewalTasksPage.IsSuccessMessageDisplayed(successmsg);
            renewalTasksPage.IsUserableToEnterTitleInSearchBox(title2);
            renewalTasksPage.IsRenewalSearchBtnClickable();
            renewalTasksPage.IsOpenRenewalTaskTitle(title2);
            renewalTasksPage.IsRenewalTaskDependentSortDisplayed(title);
        }
    }
}
