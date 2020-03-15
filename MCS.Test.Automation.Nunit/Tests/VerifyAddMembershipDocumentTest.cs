// <copyright file="VerifyAddMembershipDocumentTest.cs" company="PlaceholderCompany">
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
    public class VerifyAddMembershipDocumentTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-544", Name = "Rules and Exceptions - Add and save a new Member Classification")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "adddocument" })]
        public void VerifyAddMembershipDocument(Dictionary<string, string> parameters)
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
            homePage.IsManageMembershipDocumentClickable();
            homePage.IsAddDocumentButtonClickable();

            string documentName = parameters["documentName"].Trim() + DateHelper.RandomString(3, false);

            homePage.IsUserAbleToEnterDocumentNameInPopUpWindowOfAddDocument(documentName);
            var filePath = TestContext.CurrentContext.TestDirectory + "\\PDFDownloads\\";
            homePage.IsUserAbletoUploadDocumentToAddDocument(filePath + "sample.pdf");
            homePage.IsAddDocumentSaveButtonClickableFromPopUpWindow();

            string documentsavemessage = parameters["documentsavemsg"].Trim();
            homePage.IsSuccessfullMessageForAddMembershipDocumentDisplayed(documentsavemessage);
            homePage.IsAddDocumentSavedToListOfRecordsSuccessfully(documentName);
        }
    }
}
