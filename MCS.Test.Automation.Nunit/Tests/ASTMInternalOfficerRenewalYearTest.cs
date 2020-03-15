// <copyright file="ASTMInternalOfficerRenewalYearTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalOfficerRenewalYearTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1584", Name = "ASTM Staff Internal- Officer Titles list – Filter - Renewal Year")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AstmInternalOfficerListRenewalYear" })]
        public void ASTMInternalOfficerRenewalYear(Dictionary<string, string> parameters)
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
            renewalTasksPage.IsDefaultRenewalYearDisplayed();
            renewalTasksPage.IsRenewalDropDownClickable();
            renewalTasksPage.SelectYearfromList();
        }
    }
}
