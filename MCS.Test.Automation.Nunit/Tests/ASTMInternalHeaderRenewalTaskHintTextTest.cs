// <copyright file="ASTMInternalHeaderRenewalTaskHintTextTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalHeaderRenewalTaskHintTextTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("NotReady")]
        [TestCaseDescription(Id = "MCS2-1177", Name = "ASTM staff internal application - Login as ASTM staff - Renewal Tasks header menu - View the hint text Search Task by Task ID, Title, Assignee inside the Search box")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "RenewalTaskHintText" })]
        public void ASTMInternalHeaderRenewalTaskHintText(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            internalhomePage.IsCustomerLogoDisplayed();
            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            renewalTasksPage.IsAddTasksBtnClickable();
            renewalTasksPage.IsAddTasksPopupVisible();
            string title = parameters["title"].Trim() + DateHelper.RandomString(3, false);
            string startDate = DateHelper.CurrentDateInMMDDYYYY;
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
            string renewalTaskSelection = parameters["renewalTaskSelection"].Trim();
            renewalTasksPage.IsRenewalTaskSelectionDisplayed(renewalTaskSelection);
            string renewalTaskHint = parameters["renewalTaskHint"].Trim();
            renewalTasksPage.IsRenewalSearchHintDisplayed(renewalTaskHint);
            renewalTasksPage.IsUserableToEnterTitleInSearchBox(title);
            renewalTasksPage.IsRenewalSearchBtnClickable();
            renewalTasksPage.IsOpenRenewalTaskTitleWithThreeDotsDisplayed(title);
        }
    }
}