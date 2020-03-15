﻿// <copyright file="ASTMInternalWithoutEnteringReasonForUpdateClickSaveButtonTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalWithoutEnteringReasonForUpdateClickSaveButtonTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2759", Name = "ASTM General Information Section-Without Entering Reason for update -Save Button")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ClickSaveWithoutEnteringReasonForUpdate" })]
        public void ASTMInternalWithoutEnteringReasonForUpdateClickSaveButton(Dictionary<string, string> parameters)
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
            membershipManagementPage.IsASTMGeneralInformationUpdateButtonClickable();
            string errorMsg = parameters["errorMsg"].Trim();
            membershipManagementPage.IsGetErrorMessageForReasonForUpdateField(errorMsg);
        }
    }
}
