// <copyright file="ASTMInternalMemberRecordFilterActiveRecordsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalMemberRecordFilterActiveRecordsTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2123", Name = "ASTM staff internal application - Member List Page - Filtering of Members Records based on Status - Active member records")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalMemberRecordFilterActiveRecords" })]
        public void ASTMInternalMemberRecordFilterActiveRecords(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new InternalStaffMembershipManagementPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsLoggedUserDisplayed();

            internalhomePage.IsMembersManagementSectionClickable();
            internalhomePage.IsMemberManagementSubMenuMemberClickable();
            string header = parameters["header"].Trim();
            homePage.IsMembershipTypeHeaderDisplayed(header);
            membershipManagementPage.IsUserAbleToClickOnAccountStatusDropDown();
            string statusColumn = parameters["status"].Trim();
            membershipManagementPage.IsUserAbleToClickOnAccountStatusSelectActiveInDropdown(statusColumn);
            membershipManagementPage.IsUserAbleToViewStatusColumn(statusColumn);
        }
    }
}
