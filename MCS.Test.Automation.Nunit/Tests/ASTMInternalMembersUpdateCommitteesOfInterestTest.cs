// <copyright file="ASTMInternalMembersUpdateCommitteesOfInterestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Extensions;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]

    public class ASTMInternalMembersUpdateCommitteesOfInterestTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2747", Name = "ASTM General Information Section-Update 'Committees of Interest' Dropdown field")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "MembersUpdateCommitteesOfInterest" })]
        public void ASTMInternalMembersUpdateCommitteesOfInterest(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new InternalStaffMembershipManagementPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsLoggedUserDisplayed();
            internalhomePage.IsMembersManagementSectionClickable();
            internalhomePage.IsMemberManagementSubMenuMemberClickable();
            string header = parameters["header"].Trim();
            string membershipType = parameters["membershipType"].Trim();
            homePage.IsMembershipTypeHeaderDisplayed(header);
            membershipManagementPage.IsUserIsAbleToClickOnMemberTypeDropDownList();
            membershipManagementPage.IsStudentMemberTypeClickableInMemberTypeDrpDwn(membershipType);
            membershipManagementPage.IsUserIsAbleToClickOnAccountNumberOfMemberType();
            membershipManagementPage.IsASTMGeneralInformationEditable();
            string graduationDate = parameters["graduationDate"].Trim();
            membershipManagementPage.IsUserAbleToEnterTextInGraduationDateField(graduationDate);
            string committeesOfInterest = parameters["committeesOfInterest"].Trim();
            membershipManagementPage.IsUserAbleToEnterTextInCommitteesOfInterest(committeesOfInterest);
            string reasonForUpdate = parameters["ReasonForUpdate"].Trim();
            membershipManagementPage.IsUserAbleToEnterTextInReasonForUpdateField(reasonForUpdate);
            membershipManagementPage.IsASTMGeneralInformationUpdateButtonClickable();
            string updateSuccessMsg = parameters["updateSuccessMsg"].Trim();
            membershipManagementPage.IsTaskRecordUpdatedSuccessfully(updateSuccessMsg);
        }
    }
}
