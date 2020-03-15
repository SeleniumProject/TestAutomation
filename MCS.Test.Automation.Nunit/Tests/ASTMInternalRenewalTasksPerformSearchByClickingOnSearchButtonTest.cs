// <copyright file="ASTMInternalRenewalTasksPerformSearchByClickingOnSearchButtonTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalRenewalTasksPerformSearchByClickingOnSearchButtonTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1178 ", Name = "ASTM staff internal application - Login as ASTM staff - Renewal Tasks header menu - Renewal Tasks List page - Perform Search by entering search parameter and clicking on Search button or pressing Enter key")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalPerformSearchData" })]
        public void ASTMInternalRenewalTasksPerformSearchByClickingOnSearchButton(Dictionary<string, string> parameters)
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
            string date = DateHelper.CurrentDateInMMDDYYYY;
            string descriptionText = parameters["descriptionText"].Trim();
            string assigneeName = parameters["assigneeName"].Trim();

            renewalTasksPage.IsUserableToaddNewTask(title1, date, descriptionText, assigneeName);
            string successmsg = parameters["successmsg"].Trim();
            renewalTasksPage.IsSuccessMessageDisplayed(successmsg);

            string searchType = parameters["searchType"].Trim();
            renewalTasksPage.IsUserableToSelectTypeOfSearchUsingDropdown(searchType);
            renewalTasksPage.IsuserAbleToEnterTextInSearchBoxFeature(title1);
            renewalTasksPage.IsUserabletoViewTaskAfterPerformingSearch(title1);
        }
    }
}
