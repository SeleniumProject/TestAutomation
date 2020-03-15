// <copyright file="VerifyEditMembershipDocumentTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyEditMembershipDocumentTest : ProjectTestBase
    {
        [Test]
        [Category("NotReady")]
        [Category("BugID:2458")]
        [TestCaseDescription(Id = "MCS2-449", Name = "Rules and Exceptions -Membership Documents list page-Edit Membership Document")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "editdocument" })]
        public void VerifyEditMembershipDocument(Dictionary<string, string> parameters)
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
            string header = parameters["header"].Trim();
            membershipDocumentPage.IsUserAbleToViewMembershipDocumentHeader(header);
            string documentId = membershipDocumentPage.IsUserIsAbleToSelectDocumnetFromList(1);
            string date = membershipDocumentPage.IsUserAbleToGetTextLastUpdatedOnBeforeEdit(1);
            membershipDocumentPage.IsUserAbleToClickOnEditBtn(documentId);
            string documentName = parameters["documentName"].Trim() + Common.Helpers.DateHelper.RandomString(2, false);
            membershipDocumentPage.EnterDocumentName(documentName);
            membershipDocumentPage.IsUserAbleToClickOnSaveBtn();
            string documentSaveMsg = parameters["documentsavemsg"].Trim();
            membershipDocumentPage.IsSuccessfullMessageDisplayedForUpdatedDocument(documentSaveMsg);
            membershipDocumentPage.IsUserAbleToGetTextLastUpdatedOnAfterEdit(date, 1);
            membershipDocumentPage.IsUserAbleToGetTextLastUpdatedByAfterEdit(1);
        }
    }
}
