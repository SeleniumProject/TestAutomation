// <copyright file="VerifyDownloadMembershipDocumentTest.cs" company="PlaceholderCompany">
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
    public class VerifyDownloadMembershipDocumentTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-460", Name = "Rules and Exceptions -Membership Documents list page-Download Membership Document")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "adddocument" })]
        public void VerifyDownloadMembershipDocument(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            var membershipDocumentPage = new MembershipDocumentsPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipDocumentClickable();
            homePage.IsAddDocumentButtonClickable();

            string documentName = parameters["documentName"].Trim() + DateHelper.RandomString(3, false);

            homePage.IsUserAbleToEnterDocumentNameInPopUpWindowOfAddDocument(documentName);
            var filePath = TestContext.CurrentContext.TestDirectory + "\\PDFDownloads\\";
            homePage.IsUserAbletoUploadDocumentToAddDocument(filePath + "aws-overview.pdf");
            homePage.IsAddDocumentSaveButtonClickableFromPopUpWindow();

            string documentsavemessage = parameters["documentsavemsg"].Trim();
            homePage.IsSuccessfullMessageForAddMembershipDocumentDisplayed(documentsavemessage);
            homePage.IsAddDocumentSavedToListOfRecordsSuccessfully(documentName);
            membershipDocumentPage.IsUserAbleToClickOnDownloadBtn(documentName);
        }
    }
}
