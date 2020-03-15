// <copyright file="ASTMInternalEditRenewalTaskEndDateTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalEditRenewalTaskEndDateTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1153", Name = "ASTM Staff Internal Application –Renewal Task Header Menu – Task list Page- Task Details page – remove Dependency")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalEditRenewalTaskEndDate" })]
        public void ASTMInternalEditRenewalTaskEndDate(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsCustomerLogoDisplayed();
            internalhomePage.IsLoggedUserDisplayed();
            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            string title1 = parameters["title1"].Trim() + DateHelper.RandomString(3, false);
            string descriptionText = parameters["descriptionText"].Trim();
            string assigneeName = parameters["assigneeName"].Trim();
            string sdate = DateHelper.TomorrowDateInMMDDYYYY;
            string edate = DateHelper.TomorrowDateInMMDDYYYY;
            string edate1 = DateHelper.CurrentDateInMMDDYYYY;

            // renewalTasksPage.IsUserableToaddNewTask(title1, sdate, edate, descriptionText, assigneeName);
            // renewalTasksPage.IsUserableToSelectTaskCard(title1);
            // renewalTasksPage.IsGeneralInfoEditButtonClickable();
            // renewalTasksPage.IsUserAbleToSelectEndDate(edate1);
            // renewalTasksPage.IsupdateBtnClickableforInactiveTask();
            // string errorMessage = parameters["errorMessage"].Trim();
            // renewalTasksPage.EndDateErrorMessageDisplayed(errorMessage);
        }
    }
}
