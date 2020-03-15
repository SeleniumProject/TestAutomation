// <copyright file="VerifyViewApplicationSortOrderTest.cs" company="PlaceholderCompany">
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
    public class VerifyViewApplicationSortOrderTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-463", Name = "Rules and Exceptions – View application list - Sort order")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewApplicationWithValidDataWithStatus" })]
        public void VerifyViewApplicationSortOrder(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            var applicationManagementPage = new ApplicationManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsApplicationManagementSectionClickable();
            homePage.IsAddApplicationButtonClickable();
            string applicationName = parameters["ApplicationName"].Trim() + DateHelper.RandomString(3, false);
            string contactName = parameters["contactName"].Trim() + DateHelper.RandomString(3, false);
            string applicationNameUpperCase = applicationName.ToUpper();
            homePage.IsUserAbletoEnterApplicationName(applicationNameUpperCase);
            homePage.IsUserAbletoEnterContactName(contactName);
            string emailId = parameters["Email"].Trim();
            homePage.IsUserAbletoEnterEmailID(emailId);
            homePage.IsAddApplicationSaveButtonClickable();
            homePage.IsAddApplicationSuccessfullMessageDisplayed();

            string applicationNameLink = applicationManagementPage.IsUserAbleToViewApplicationManagementListInLifoOrder(0, applicationNameUpperCase);
            string status = parameters["status"].Trim();
            applicationManagementPage.IsUserAbleToViewNewApplicationIsByDefaultActiveStatus(status, applicationNameLink.ToUpper());
        }
    }
}
