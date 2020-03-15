// <copyright file="VerifyAddMembershipDeleteDocumentTest.cs" company="PlaceholderCompany">
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
    public class VerifyAddMembershipDeleteDocumentTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-1820", Name = "Rules and Exceptions - Membership Documents – Delete Document – Error Message")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "deletedocument" })]
        public void VerifyAddMembershipDeleteDocument(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
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
            string membershipDocumentTableCol = homePage.GetDocumentNameFirstIndexFromTableList();
            homePage.IsDeleteButtonFromMembershipDocumentTableClickable();
            homePage.IsYesButtonFromMembershipDocumentTableClickable();
            string documentDeletemessage = parameters["documentdeletemsg"].Trim();
            homePage.IsDeleteMessageForAddMembershipDocumentDisplayed(documentDeletemessage, membershipDocumentTableCol);
        }
    }
}
