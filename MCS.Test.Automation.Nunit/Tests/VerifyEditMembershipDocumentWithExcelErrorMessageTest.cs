// <copyright file="VerifyEditMembershipDocumentWithExcelErrorMessageTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyEditMembershipDocumentWithExcelErrorMessageTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-454", Name = "Rules and Exceptions -Edit Membership Document - Error message when trying to upload file other than Word or PDF format")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "editdocumentWithErrorMessageForExcelFile" })]
        public void VerifyEditMembershipDocumentWithExcelErrorMessage(Dictionary<string, string> parameters)
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
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipDocumentClickable();
            string header = parameters["header"].Trim();
            membershipDocumentPage.IsUserAbleToViewMembershipDocumentHeader(header);
            string documentId = membershipDocumentPage.IsUserIsAbleToSelectDocumnetFromList(2);
            string date = membershipDocumentPage.IsUserAbleToGetTextLastUpdatedOnBeforeEdit(2);
            membershipDocumentPage.IsUserAbleToClickOnEditBtn(documentId);
            var filePath = TestContext.CurrentContext.TestDirectory + "\\PDFDownloads\\";
            homePage.IsUserAbletoUploadDocumentToAddDocument(filePath + "Testing.ods");

            string documentErrorMsg = parameters["documentErrorMsg"].Trim();
            membershipDocumentPage.IsUserAbleToViewErrorMessageForForUploadingExcelFile(documentErrorMsg);
        }
    }
}
