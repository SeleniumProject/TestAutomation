// <copyright file="ASTMInternalMemberSearchNoDataFoundTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalMemberSearchNoDataFoundTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2107", Name = "ASTM staff internal application - Member Basic Search - No records found")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AstmInternalMemberSearch" })]
        public void ASTMInternalMemberSearchNoDataFound(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new InternalStaffMembershipManagementPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsLoggedUserDisplayed();
            string member = parameters["member"].Trim();
            membershipManagementPage.IsUserAbleToViewMemberInDropDownBesideSeachBox(member);
            string hintText = parameters["hintText"].Trim();
            membershipManagementPage.IsHintTextVisibleInSearchBox(hintText);
            string search = parameters["search"].Trim();
            membershipManagementPage.IsUserAbleToEnterTextInSearchField(search);
            membershipManagementPage.IsUserAbleToClickOnSearch();
            string noDataFound = parameters["Mesage"].Trim();
            membershipManagementPage.IsUserAbleToViewNoDataFound(noDataFound);
        }
    }
}
