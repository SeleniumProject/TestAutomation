// <copyright file="VerifyMandatoryFieldsInAddNewFAQsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MCS.Test.Automation.Nunit.Tests
{
    using System.Collections.Generic;
    using MCS.Test.Automation.Tests.NUnit;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;
    using NUnit.Framework;

    [TestFixture]
    public class VerifyMandatoryFieldsInAddNewFAQsTest : ProjectTestBase
    {
        [Test]
        [Category("NotReady")]
        [TestCaseDescription(Id = "MCS2-564", Name = "Rules and Exceptions - Manage Membership FAQ's - Add new FAQ - Mandatory fields missing")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewMembershipFAQWithEmptyData" })]
        public void VerifyMandatoryFieldsInAddNewFAQs(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            var manageMembershipFAQsPage = new ManageMembershipFAQsPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();

            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedInUserDisplayed(uname);

            homePage.IsMembershipManagementSectionClickable();
            string heading = parameters["heading"].Trim();
            homePage.IsManageMembershipFAQsClickable(heading);

            manageMembershipFAQsPage.IsMembershipFAQsHeaderVisible();
            manageMembershipFAQsPage.IsAddFAQButtonClickable();
            manageMembershipFAQsPage.IsAddFAQsSaveButtonCllickable();
            string questionfieldErrorMessage = parameters["questionfieldErrorMessage"].Trim();
            manageMembershipFAQsPage.IsMandatoryFieldErrorMessageDisplayedforFAQsQuestionField(questionfieldErrorMessage);
            string answerfieldErrorMessage = parameters["answerfieldErrorMessage"].Trim();
            manageMembershipFAQsPage.IsMandatoryFieldErrorMessageDisplayedforFAQsAnswerField(answerfieldErrorMessage);
            manageMembershipFAQsPage.IsAddFAQCancelButtonClickable();
            string signouttext = parameters["signouttext"].Trim();
            homePage.IsSignOutClickable(signouttext);
        }
    }
}