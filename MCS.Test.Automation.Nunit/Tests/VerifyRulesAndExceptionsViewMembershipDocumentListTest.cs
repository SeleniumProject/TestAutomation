// <copyright file="VerifyRulesAndExceptionsViewMembershipDocumentListTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyRulesAndExceptionsViewMembershipDocumentListTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [Category("NotReady")]
        [Category("BugID:2482")]
        [TestCaseDescription(Id = "MCS2-442", Name = "Rules and Exceptions -View Membership Document List")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewMembershipDocumentTableColumns" })]
        public void VerifyRulesAndExceptionsViewMembershipDocumentList(Dictionary<string, string> parameters)
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
            string documentid = parameters["documentId"].Trim();
            membershipDocumentPage.IsUserAbleToViewMembershipDocumentIdColumn(documentid);
            string documentname = parameters["documentName"].Trim();
            membershipDocumentPage.IsUserAbleToViewMembershipDocumentNameColumn(documentname);
            string type = parameters["type"].Trim();
            membershipDocumentPage.IsUserAbleToViewMembershipTypeColumn(type);
            string status = parameters["status"].Trim();
            membershipDocumentPage.IsUserAbleToViewMembershipStatusColumn(status);
            string updatedby = parameters["updatedBy"].Trim();
            membershipDocumentPage.IsUserAbleToViewMembershipUpdatedByColumn(updatedby);
            string updatedon = parameters["updatedOn"].Trim();
            membershipDocumentPage.IsUserAbleToViewMembershipUpdatedOnColumn(updatedon);
            string actions = parameters["actions"].Trim();
            membershipDocumentPage.IsUserAbleToViewMembershipActionsColumn(actions);
        }
    }
}