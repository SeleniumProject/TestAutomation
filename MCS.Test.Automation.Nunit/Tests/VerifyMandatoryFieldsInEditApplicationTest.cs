// <copyright file="VerifyMandatoryFieldsInEditApplicationTest.cs" company="PlaceholderCompany">
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
    public class VerifyMandatoryFieldsInEditApplicationTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-475", Name = "Rules and Exceptions – Edit application details - Mandatory fields missing")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditApplicationWithEmptyData" })]
        public void VerifyMandatoryFieldsInEditApplication(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            var applicationManagementPage = new ApplicationManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsApplicationManagementSectionClickable();
            applicationManagementPage.IsUserAbleToSelectApplicationNameFromListOfApplications(0);
            applicationManagementPage.IsEditApplicationButtonClickable();
            applicationManagementPage.IsUpdatePopUpWindowVisible();
            applicationManagementPage.IsUserAbletoEditApplicationName(parameters["ApplicationName"].Trim());
            applicationManagementPage.IsUserAbletoEditContactName(parameters["contactName"].Trim());
            applicationManagementPage.IsUserAbletoEditEmailID(parameters["Email"].Trim());
            homePage.IsAddApplicationSaveButtonClickable();
            homePage.AreAddApplicationValidationMessagesDisplayed(parameters["applicationError"].Trim(), parameters["contacterror"].Trim(), parameters["emailerror"].Trim());
            applicationManagementPage.IsUserAbleCloseEditApplicationPopupWindow();
        }
    }
}