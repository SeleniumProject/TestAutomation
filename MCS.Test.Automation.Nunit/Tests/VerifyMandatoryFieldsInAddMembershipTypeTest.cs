// <copyright file="VerifyMandatoryFieldsInAddMembershipTypeTest.cs" company="PlaceholderCompany">
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
    public class VerifyMandatoryFieldsInAddMembershipTypeTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-628", Name = "Rules and Exceptions – Member Management – Add Membership type – Details Section – Mandatory fields missing")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AddManagementMembershipTypeWithEmptyData" })]
        public void VerifyMandatoryFieldsInAddMembershipType(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            string username = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(username, password);
            homePage.IsLoggedUserDisplayed();
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipTypeClickable();
            membershipManagementPage.IsAddMemberShipTypeButtonClickable();
            string membershipname = parameters["membershipName"].Trim();
            membershipManagementPage.EnterMembershipName(membershipname);
            membershipManagementPage.IsNextButtonClickable();
            string membershipnameerror = parameters["membershipNameError"].Trim();
            membershipManagementPage.AreAddManagementTypeValidationMessagesDisplayed(membershipnameerror);
        }
    }
}
