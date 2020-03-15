// <copyright file="ASTMInternalRenewalTaskDependsOnRedirectToAssigneeTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalRenewalTaskDependsOnRedirectToAssigneeTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-805 ", Name = "ASTM Staff Internal Application – Renewal Tasks Header menu – Task list Page- Task details page – Depends on – Assignee - Redirect to assigned ASTM Staff Details page")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalDependsOnRedirectedData" })]
        public void ASTMInternalRenewalTaskDependsOnRedirectToAssignee(Dictionary<string, string> parameters)
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

            string title1 = parameters["title1"].Trim() + DateHelper.RandomString(3, false);
            string title2 = parameters["title2"].Trim() + DateHelper.RandomString(3, false);
            string currentDate = DateHelper.CurrentDateInMMDDYYYY;
            string descriptionText = parameters["descriptionText"].Trim();
            string assigneeName = parameters["assigneeName"].Trim();

            renewalTasksPage.IsUserableToaddNewTask(title1, currentDate, descriptionText, assigneeName);
            string taskid = renewalTasksPage.IsUserableToaddNewTask(title2, currentDate, descriptionText, assigneeName, title1);
            renewalTasksPage.IsuserAbleToEnterTextInSearchBoxFeature(title2);
            renewalTasksPage.IsUserableToSelectTaskCardBasedOnName(title2);
            renewalTasksPage.IsUserAbleToRedirectToAssigneePage(assigneeName);
        }
    }
}
