// <copyright file="ASTMInternalRenewalTaskDependentTaskColumnsTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalRenewalTaskDependentTaskColumnsTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-810", Name = "ASTM Staff Internal Application – Renewal Tasks Header menu – Task list Page- Task details page – Dependent tasks – Columns")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalDependentTaskColumnsData" })]
        public void ASTMInternalRenewalTaskDependentTaskColumns(Dictionary<string, string> parameters)
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

            string title1 = parameters["title1"].Trim() + DateHelper.RandomString(2, false);
            string title2 = parameters["title2"].Trim() + DateHelper.RandomString(2, false);
            string date = DateHelper.CurrentDateInMMDDYYYY;
            string descriptionText = parameters["descriptionText"].Trim();
            string assigneeName = parameters["assigneeName"].Trim();

            renewalTasksPage.IsUserableToaddNewTask(title1, date, descriptionText, assigneeName);
            string taskid = renewalTasksPage.IsUserableToaddNewTask(title2, date, descriptionText, assigneeName, title1);
            renewalTasksPage.IsuserAbleToEnterTextInSearchBoxFeature(title1);
            renewalTasksPage.IsUserableToSelectTaskCardBasedOnName(title1);

            string taskId = parameters["taskId"].Trim();
            renewalTasksPage.IsDependentTaskColumnVisible(taskId);
            string taskTitle = parameters["taskTitle"].Trim();
            renewalTasksPage.IsDependentTaskColumnVisible(taskTitle);
            string startDate = parameters["startDate"].Trim();
            renewalTasksPage.IsDependentTaskColumnVisible(startDate);
            string endDate = parameters["endDate"].Trim();
            renewalTasksPage.IsDependentTaskColumnVisible(endDate);
            string assignee = parameters["assignee"].Trim();
            renewalTasksPage.IsDependentTaskColumnVisible(assignee);
            string status = parameters["status"].Trim();
            renewalTasksPage.IsDependentTaskColumnVisible(status);
        }
    }
}
