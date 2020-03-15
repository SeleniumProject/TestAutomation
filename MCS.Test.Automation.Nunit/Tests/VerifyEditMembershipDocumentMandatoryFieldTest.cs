﻿// <copyright file="VerifyEditMembershipDocumentMandatoryFieldTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyEditMembershipDocumentMandatoryFieldTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-453", Name = "Rules and Exceptions -Edit Membership Document-Mandatory fields missing")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "editdocumentWithMandatoryField" })]
        public void VerifyEditMembershipDocumentMandatoryField(Dictionary<string, string> parameters)
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
            membershipDocumentPage.IsUserAbleToClickOnEditBtn(documentId);
            string documentName = parameters["documentName"].Trim();
            membershipDocumentPage.EnterDocumentName(documentName);
            membershipDocumentPage.IsUserAbleToClickOnSaveBtn();
            string errorMessage = parameters["errorMessage"].Trim();
            membershipDocumentPage.IsErrorMessageDisplayedForMandatoryField(errorMessage);
            membershipDocumentPage.IsUserAbleToClickOnClosePopUp();
            string signouttext = parameters["signouttext"].Trim();
            homePage.IsSignOutClickable(signouttext);
        }
    }
}
