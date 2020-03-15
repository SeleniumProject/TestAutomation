// <copyright file="VerifyMandatoryFieldsInAddMemberClassificationsTest .cs" company="PlaceholderCompany">
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
    public class VerifyMandatoryFieldsInAddMemberClassificationsTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-545", Name = "Rules and Exceptions - Add Member Classification - Mandatory fields missing")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AddMemberClassificationWithEmptyData" })]
        public void VerifyMandatoryFieldsInAddMemberClassifications(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipClassificationsClickable();
            homePage.IsAddClassificationTypeButtonClickable();
            homePage.IsSaveButtonClickableOfPopUpWindowOfAddClassificationType();
            homePage.IsMandatoryfieldErrorMessageDisplayedforMembershipClassification(parameters["errormessage"].Trim());
            homePage.IsCancelButtonClickableOfPopUpWindowOfAddClassificationType();
            string signouttext = parameters["signouttext"].Trim();
            homePage.IsSignOutClickable(signouttext);
        }
    }
}