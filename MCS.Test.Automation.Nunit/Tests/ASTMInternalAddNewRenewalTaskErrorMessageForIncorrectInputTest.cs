// <copyright file="ASTMInternalAddNewRenewalTaskErrorMessageForIncorrectInputTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalAddNewRenewalTaskErrorMessageForIncorrectInputTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1213", Name = "ASTM staff internal application - Login as ASTM staff - Renewal Tasks List page - Add and Save a New Renewal Task - Error message for incorrect input")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternalAddNewTaskMandatoryInputFieldsErrorMessage" })]
        public void ASTMInternalAddNewRenewalTaskErrorMessageForIncorrectInput(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            string username = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(username, password);

            internalhomePage.IsLoggedUserDisplayed();
            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            renewalTasksPage.IsAddTasksBtnClickable();
            renewalTasksPage.IsAddTasksPopupVisible();
            string title = parameters["title"].Trim();
            string startDate = parameters["startDateInput"].Trim();
            string descriptionText = parameters["descriptionText"].Trim();
            string endDate = parameters["endDateInput"].Trim();
            string assigneeName = parameters["assigneeName"].Trim();

            renewalTasksPage.IsUserableToEnterTitle(title);
            renewalTasksPage.IsUserAbleToSelectStartDate(startDate);
            renewalTasksPage.IsUserAbleToSelectEndDate(endDate);
            renewalTasksPage.IsUserAbleToEnterTextInDescription(descriptionText);
            renewalTasksPage.IsUserAbleToEnterAssigneeName(assigneeName);
            renewalTasksPage.IsUserableToSaveTask();

            string errorStartDateMessage = parameters["startdateErrorMessage"].Trim();
            renewalTasksPage.IsInputStartDateErrorMessageDisplayed(errorStartDateMessage);
            string errorEndDateMessage = parameters["enddateErrorMessage"].Trim();
            renewalTasksPage.IsInputEndDateErrorMessageDisplayed(errorEndDateMessage);
            renewalTasksPage.IsUserableToPopUpCloseTask();
        }
    }
}
