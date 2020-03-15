// <copyright file="ASTMInternalMembersIncorrectInformationTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalMembersIncorrectInformationTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2756", Name = "ASTM General Information Section-incorrect information")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "GeneralInformationIncorrectInformation" })]
        public void ASTMInternalMembersIncorrectInformation(Dictionary<string, string> parameters)
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
            membershipManagementPage.IsASTMGeneralInformationMandatoryFieldsCleared();
            string graduationDate = parameters["graduationDate"].Trim();
            membershipManagementPage.IsUserAbleToEnterTextInGraduationDateField(graduationDate);
            membershipManagementPage.IsASTMGeneralInformationUpdateButtonClickable();
            string incorrectInputErrorMsg = parameters["incorrectInputErrorMsg"].Trim();
            membershipManagementPage.IsIncorrectDataErrorMsgDisplayedAndFieldHighlighted(incorrectInputErrorMsg);
        }
    }
}
