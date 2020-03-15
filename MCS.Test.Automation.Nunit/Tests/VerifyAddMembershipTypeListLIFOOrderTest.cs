// <copyright file="VerifyAddMembershipTypeListLIFOOrderTest.cs" company="PlaceholderCompany">
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
    public class VerifyAddMembershipTypeListLIFOOrderTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-655", Name = "Rules and Exceptions - Member Management – Membership type list – Order")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AddMembershipTypeToCheckLifoOrder" })]
        public void VerifyAddMembershipTypeListLIFOOrder(Dictionary<string, string> parameters)
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
            membershipManagementPage.IsAddMemberShipTypeButtonClickable();
            string membershipname = parameters["membershipname"].Trim() + DateHelper.RandomString(3, false);
            membershipManagementPage.EnterMembershipName(membershipname);
            string membershipFee = parameters["membershipfee"].Trim();
            membershipManagementPage.EnterMembershipFee(membershipFee);
            membershipManagementPage.IsNextButtonClickable();
            string renewalPeriod = parameters["renewalPeriod"].Trim();
            membershipManagementPage.IsRenewalPeriodDropDownSelected(renewalPeriod);
            membershipManagementPage.IsSaveButtonClickable();
            membershipManagementPage.IsSuccessfullMessageDisplayed();
            membershipManagementPage.IsUserAbleToViewManageMembershipTypeListInLifoOrder(0, membershipname);
        }
    }
}
