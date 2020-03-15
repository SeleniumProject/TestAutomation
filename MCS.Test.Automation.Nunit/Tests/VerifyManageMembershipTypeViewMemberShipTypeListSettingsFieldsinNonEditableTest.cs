// <copyright file="VerifyManageMembershipTypeViewMemberShipTypeListSettingsFieldsinNonEditableTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using System.Threading;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyManageMembershipTypeViewMemberShipTypeListSettingsFieldsinNonEditableTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-580", Name = "Rules and Exceptions – Member Management –View Membership Type list –  Settings Fields")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "MembershipType" })]
        public void VerifyManageMembershipTypeViewMemberShipTypeListSettingsFieldsinNonEditable(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();

            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipTypeClickable();
            membershipManagementPage.IsAddMemberShipTypeButtonClickable();
            string membershipType = parameters["membershipname"].Trim() + DateHelper.RandomString(3, false);
            membershipManagementPage.EnterMembershipName(membershipType);
            string membershipFee = parameters["membershipfee"].Trim();
            membershipManagementPage.EnterMembershipFee(membershipFee);

            string summary = parameters["summary"].Trim();
            membershipManagementPage.EnterMembershipTypeSummary(summary);

            string description = parameters["description"].Trim();
            membershipManagementPage.EnterMembershipTypeDescription(description);

            string benefits = parameters["benefits"].Trim();
            membershipManagementPage.EnterMembershipTypeBenefits(benefits);

            membershipManagementPage.IsNextButtonClickable();
            string renewalPeriod = parameters["renewalPeriod"].Trim();
            membershipManagementPage.IsRenewalPeriodDropDownSelected(renewalPeriod);
            membershipManagementPage.IsSaveButtonClickable();
            membershipManagementPage.IsSuccessfullMessageDisplayed();
            membershipManagementPage.IsUserAbleToClickonManageMembershipTypeFromList(membershipType);
            membershipManagementPage.IsManageMembershipTypeDetailsAreDisplayedInNonEditableMode("titleInfo");
        }
    }
}
