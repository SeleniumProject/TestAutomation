// <copyright file="ASTMInternalViewRenewalTaskDetailsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalViewRenewalTaskDetailsTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1121 ", Name = "ASTM staff internal application - Login as ASTM staff - View Renewal Task header menu - Renewal Task List page - Renewal Task Details page - View information on Task Details Page")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalRenewalTaskDetails" })]
        public void ASTMInternalViewRenewalTaskDetails(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            renewalTasksPage.IsUserableToSelectTaskCard();
            string title = parameters["title"].Trim();
            renewalTasksPage.IsUserableToViewTaskDetailsTitle(title);
            string taskId = parameters["taskId"].Trim();
            renewalTasksPage.IsUserableToViewTaskId(taskId);
            string taskTitle = parameters["taskTitle"].Trim();
            renewalTasksPage.IsUserableToViewTaskTitle(taskTitle);
            string startDate = parameters["startDate"].Trim();
            renewalTasksPage.IsUserableToViewStartDate(startDate);
            string endDate = parameters["endDate"].Trim();
            renewalTasksPage.IsUserableToViewEndDate(endDate);
            string renewalYear = parameters["RenewalYear"].Trim();
            renewalTasksPage.IsUserableToViewRenewalYear(renewalYear);
            string description = parameters["description"].Trim();
            renewalTasksPage.IsUserableToViewDescription(description);
            string assignee = parameters["assignee"].Trim();
            renewalTasksPage.IsUserableToViewAssignee(assignee);
            string status = parameters["status"].Trim();
            renewalTasksPage.IsUserableToViewSatus(status);
        }
    }
}
