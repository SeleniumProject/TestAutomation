// <copyright file="ASTMInternalRenewalTaskStatusWatchersTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalRenewalTaskStatusWatchersTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-795", Name = "ASTM Staff Internal Application –Renewal Task Header Menu – Task list Page- Task Details page – Watchers")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalWatchersData" })]
        public void ASTMInternalRenewalTaskStatusWatchers(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsLoggedUserDisplayed();
            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            renewalTasksPage.IsUserableToSelectTaskCard();
            renewalTasksPage.IsGeneralInfoEditButtonClickable();
            renewalTasksPage.IsInactiveCheckBoxClickable();
            string reasonForInactive = parameters["reasonForInactive"].Trim();
            renewalTasksPage.EnterTextInInactiveDescriptionBox(reasonForInactive);
            renewalTasksPage.IsupdateBtnClickableforInactiveTask();
            renewalTasksPage.IsWatchersDetailsVisible();
        }
    }
}
