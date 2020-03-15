// <copyright file="VerifyViewMembershipTypeColumnsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyViewMembershipTypeColumnsTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-658", Name = "Rules and Exceptions – Member Management – Membership Type list – Columns")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewMembershipTypeColumns" })]
        public void VerifyViewMembershipTypeColumns(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipTypeClickable();
            string membershipName = parameters["membershipName"].Trim();
            membershipManagementPage.IsUserAbleToViewManageMembershipNameColumn(membershipName);
            string membershipFee = parameters["membershipFee"].Trim();
            membershipManagementPage.IsUserAbleToViewManageMembershipFeeColumn(membershipFee);
            string enabled = parameters["membershipEnabled"].Trim();
            membershipManagementPage.IsUserAbleToViewManageMembershipEnabledColumn(enabled);
            string signouttext = parameters["signouttext"].Trim();
            homePage.IsSignOutClickable(signouttext);
        }
    }
}
