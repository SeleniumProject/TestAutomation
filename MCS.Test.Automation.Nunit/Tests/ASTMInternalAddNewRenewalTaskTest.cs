// <copyright file="ASTMInternalAddNewRenewalTaskTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalAddNewRenewalTaskTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1211", Name = "ASTM staff internal application - Add and Save a New Renewal Task")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternalAddNewTask" })]
        public void ASTMInternalAddNewRenewalTask(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            internalhomePage.IsCustomerLogoDisplayed();
            internalhomePage.IsLoggedUserDisplayed();
            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            renewalTasksPage.IsAddTasksBtnClickable();
            renewalTasksPage.IsAddTasksPopupVisible();
            string title = parameters["title"].Trim();
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
        }
    }
}
