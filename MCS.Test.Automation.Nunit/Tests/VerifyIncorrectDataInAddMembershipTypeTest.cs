// <copyright file="VerifyIncorrectDataInAddMembershipTypeTest.cs" company="PlaceholderCompany">
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
    public class VerifyIncorrectDataInAddMembershipTypeTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-629", Name = "Rules and Exceptions - Member Management – Add Membership type – Details Section – Error message for incorrect input")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AddManagementMembershipTypeWithIncorrectData" })]
        public void VerifyIncorrectDataInAddMembershipType(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string username = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(username, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipTypeClickable();
            membershipManagementPage.IsAddMemberShipTypeButtonClickable();
            string membershipname = parameters["membershipName"].Trim();
            membershipManagementPage.EnterMembershipName(membershipname);
            string membershipFee = parameters["membershipFee"].Trim();
            membershipManagementPage.EnterMembershipFee(membershipFee);
            membershipManagementPage.IsNextButtonClickable();
            string membershipnameerror = parameters["membershipNameError"].Trim();

            membershipManagementPage.AreAddManagementTypeValidationMessagesDisplayed(membershipnameerror);
            string membershipfeeerror = parameters["membershipFeeError"].Trim();
            membershipManagementPage.AreAddMembershipFeeValidationMessagesDisplayed(membershipfeeerror);
        }
    }
}
