// <copyright file="ASTMInternalEditRenewalTaskAllSectionsTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalEditRenewalTaskAllSectionsTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1140", Name = "ASTM Staff Internal Application –Renewal Task Header Menu – Task list Page- Task Details page – remove Dependency")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalEditRenewalTaskAllSections" })]
        public void ASTMInternalEditRenewalTaskAllSections(Dictionary<string, string> parameters)
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
            string title = parameters["title"].Trim() + DateHelper.RandomString(3, false);
            string descriptionText = parameters["descriptionText"].Trim();
            string date = DateHelper.CurrentDateInMMDDYYYY;

            renewalTasksPage.IsUserableToSelectTaskCard();
            renewalTasksPage.IsGeneralInfoEditButtonClickable();
            string actualtitle = renewalTasksPage.IsUserableToEnterTitle(title);
            renewalTasksPage.VerifyingAllSectionEditableForTask(actualtitle, title, "title");
            string actualsdate = renewalTasksPage.IsUserAbleToSelectStartDate(date);
            renewalTasksPage.VerifyingAllSectionEditableForTask(actualsdate, date, "Startdate");
            string actualedate = renewalTasksPage.IsUserAbleToSelectEndDate(date);
            renewalTasksPage.VerifyingAllSectionEditableForTask(actualedate, date, "Enddate");
            renewalTasksPage.IsCloseButtonClickable();
            string textforsearchbutton = parameters["textforsearchbutton"].Trim();
            renewalTasksPage.IsEditButtonClickable(textforsearchbutton);
            string assigneeName = parameters["assigneeName"].Trim();
            string actualAssigneeName = renewalTasksPage.IsUserAbleToEnterAssigneeName(assigneeName);
            renewalTasksPage.VerifyingAllSectionEditableForTask(actualAssigneeName, assigneeName, "Assignee");
            renewalTasksPage.IsCloseButtonClickable(textforsearchbutton);
        }
    }
}
