// <copyright file="VerifyViewMembershipTypedetailsFieldsTest.cs" company="PlaceholderCompany">
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
    public class VerifyViewMembershipTypedetailsFieldsTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-662", Name = "Rules and Exceptions – Member Management –View Membership Type list – Details Fields")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewMembershipTypeDetailsFields" })]
        public void VerifyViewMembershipTypedetailsFields(Dictionary<string, string> parameters)
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

            string membershipname = parameters["membershipname"].Trim() + DateHelper.RandomString(3, false);
            string membershipfee = parameters["membershipfee"].Trim();
            string summarytext = parameters["summarytext"].Trim();
            string benefitstext = parameters["benefitstext"].Trim();
            string descriptiontext = parameters["descriptiontext"].Trim();

            membershipManagementPage.AddnewMembershipType(membershipname, membershipfee, summarytext, benefitstext, descriptiontext);
            membershipManagementPage.IsMembershipTypeRecordClickableFromList(membershipname);
            membershipManagementPage.IsMembershipNamefieldNoneditable(membershipname);
            membershipManagementPage.IsMembershipFeefieldNoneditable(membershipfee);
            membershipManagementPage.IsMembershipSummaryfieldNoneditable(summarytext);
            membershipManagementPage.IsMembershipBenefitsfieldNoneditable(benefitstext);
            membershipManagementPage.IsMembershipDescriptionfieldNoneditable(descriptiontext);

            string signouttext = parameters["signouttext"].Trim();
            homePage.IsSignOutClickable(signouttext);
        }
    }
}
