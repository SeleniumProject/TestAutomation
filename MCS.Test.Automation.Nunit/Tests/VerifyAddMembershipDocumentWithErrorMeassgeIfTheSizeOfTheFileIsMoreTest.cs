// <copyright file="VerifyAddMembershipDocumentWithErrorMeassgeIfTheSizeOfTheFileIsMoreTest.cs" company="PlaceholderCompany">
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
    public class VerifyAddMembershipDocumentWithErrorMeassgeIfTheSizeOfTheFileIsMoreTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-436", Name = "Rules and Exceptions - Add Membership Document_Error message when uploading a file, the size of which is greater than 10 MB")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "adddocumentWithMoreSizeFile" })]
        public void VerifyAddMembershipDocumentWithErrorMeassgeIfTheSizeOfTheFileIsMore(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
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
            homePage.IsUserAbletoUploadDocumentToAddDocument(filePath + "sample1.pdf");
            homePage.IsAddDocumentSaveButtonClickableFromPopUpWindow();
            string errorMsg = parameters["errorMsg"].Trim();
            membershipDocumentPage.IsUserAbleToViewErrorMessageIfUploadMoreSizeFile(errorMsg);
        }
    }
}
