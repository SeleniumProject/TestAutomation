// <copyright file="ASTMInternalRenewalTaskDependsOnsectionTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalRenewalTaskDependsOnsectionTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1131 ", Name = "ASTM staff internal application - Login as ASTM staff - View Renewal Task header menu - Renewal Task List page - Renewal Task Details page - View Depends on section")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalDependsOnSectionData" })]
        public void ASTMInternalRenewalTaskDependsOnsection(Dictionary<string, string> parameters)
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
            renewalTasksPage.IsuserAbleToEnterTextInSearchBoxFeature(title2);
            renewalTasksPage.IsUserableToSelectTaskCardBasedOnName(title2);

            renewalTasksPage.IsAddedDependenciesvisible();
            renewalTasksPage.IsAddedDependenciesTaskInfovisible(taskid);
        }
    }
}
