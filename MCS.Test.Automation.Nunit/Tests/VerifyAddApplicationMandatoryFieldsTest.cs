// <copyright file="VerifyAddApplicationMandatoryFieldsTest.cs" company="PlaceholderCompany">
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
    public class VerifyAddApplicationMandatoryFieldsTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-486", Name = "Rules and Exceptions - Add new application - Mandatory fields missing")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AddApplicationWithEmptyData" })]
        public void VerifyAddApplicationMandatoryFields(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsApplicationManagementSectionClickable();
            homePage.IsAddApplicationButtonClickable();
            homePage.IsUserAbletoEnterApplicationName(parameters["ApplicationName"].Trim());
            homePage.IsUserAbletoEnterContactName(parameters["contactName"].Trim());
            homePage.IsUserAbletoEnterEmailID(parameters["Email"].Trim());
            homePage.IsAddApplicationSaveButtonClickable();
            homePage.AreAddApplicationValidationMessagesDisplayed(parameters["applicationError"].Trim(), parameters["contacterror"].Trim(), parameters["emailerror"].Trim());
        }
    }
}
