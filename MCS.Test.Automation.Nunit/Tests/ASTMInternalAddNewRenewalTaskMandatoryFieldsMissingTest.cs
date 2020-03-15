// <copyright file="ASTMInternalAddNewRenewalTaskMandatoryFieldsMissingTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalAddNewRenewalTaskMandatoryFieldsMissingTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1212", Name = "ASTM staff internal application_Login as ASTM staff_Add and Save a New Renewal Task - Mandatory fields missing")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternalAddNewTaskMandatoryFieldsMissing" })]
        public void ASTMInternalAddNewRenewalTaskMandatoryFieldsMissing(Dictionary<string, string> parameters)
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
            renewalTasksPage.IsUserableToSaveTask();
            string errorTitleMessage = parameters["titleErrorMessage"].Trim();
            renewalTasksPage.IsTitleErrorMessageDisplayed(errorTitleMessage);
            string errorStartDateMessage = parameters["startdateErrorMessage"].Trim();
            renewalTasksPage.IsStartDateErrorMessageDisplayed(errorStartDateMessage);
            string errorEndDateMessage = parameters["enddateErrorMessage"].Trim();
            renewalTasksPage.IsEndDateErrorMessageDisplayed(errorEndDateMessage);
        }
    }
}
