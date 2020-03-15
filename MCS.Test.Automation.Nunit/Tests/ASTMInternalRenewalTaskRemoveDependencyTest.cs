// <copyright file="ASTMInternalRenewalTaskRemoveDependencyTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalRenewalTaskRemoveDependencyTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "[MCS2-798] ", Name = "ASTM Staff Internal Application –Renewal Task Header Menu – Task list Page- Task Details page – remove Dependency")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalRemoveDependencyData" })]
        public void ASTMInternalRenewalTaskRemoveDependency(Dictionary<string, string> parameters)
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

            string title1 = parameters["title1"].Trim() + DateHelper.RandomString(4, false);
            string title2 = parameters["title2"].Trim() + DateHelper.RandomString(4, false);
            string date = DateHelper.CurrentDateInMMDDYYYY;
            string descriptionText = parameters["descriptionText"].Trim();
            string assigneeName = parameters["assigneeName"].Trim();

            renewalTasksPage.IsUserableToaddNewTask(title1, date, descriptionText, assigneeName);
            renewalTasksPage.IsUserableToaddNewTask(title2, date, descriptionText, assigneeName);
            renewalTasksPage.IsuserAbleToEnterTextInSearchBoxFeature(title1);
            renewalTasksPage.IsUserableToSelectTaskCardBasedOnName(title1);
            renewalTasksPage.IsDependsOnAddButtonClickable();
            renewalTasksPage.IsDependencySearchBoxClickable();

            renewalTasksPage.IsDependenciesSelectablefromList(title2);
            renewalTasksPage.IsAddButtonClickableInADDDependenciesPopupWindow();
            string successmsg = parameters["successmsg"].Trim();
            renewalTasksPage.IsSuccessMessageDisplayed(successmsg);
            renewalTasksPage.IsAddedDependenciesvisible();
            renewalTasksPage.IsGeneralInfoEditButtonClickable();
            renewalTasksPage.IsInactiveCheckBoxClickable();

            string reasonForInactive = parameters["reasonForInactive"].Trim();
            renewalTasksPage.EnterTextInInactiveDescriptionBox(reasonForInactive);
            renewalTasksPage.IsupdateBtnClickableforInactiveTask();
            renewalTasksPage.IsDependenciesNOTVisible();
        }
    }
}
