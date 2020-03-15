// <copyright file="ASTMInternalVerifyResultsPerPageInMemberListPageTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalVerifyResultsPerPageInMemberListPageTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2207", Name = "Member list page to be viewed by ASTM staff in ASTM staff Internal Application - Results per page")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "MembersResultspageData" })]
        public void ASTMInternalVerifyResultsPerPageInMemberListPage(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new InternalStaffHomePage(this.DriverContext);
            var membersPage = new InternalStaffMembershipManagementPage(this.DriverContext);

            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();

            homePage.IsMembersManagementSectionClickable();
            homePage.IsMemberManagementSubMenuMemberClickable();

            string noOfItemsPerPage = parameters["noOfItemsPerPage"].Trim();
            membersPage.IsDefaultValuedisplayedAs25(noOfItemsPerPage);
            membersPage.IsUserableToSeeResultsPerPageDropdownWithValues();
        }
    }
}
