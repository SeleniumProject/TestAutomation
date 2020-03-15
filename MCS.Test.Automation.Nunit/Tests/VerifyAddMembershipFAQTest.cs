// <copyright file="VerifyAddMembershipFAQTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MCS.Test.Automation.Nunit.Tests
{
    using System.Collections.Generic;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;
    using NUnit.Framework;

    [TestFixture]
    public class VerifyAddMembershipFAQTest : ProjectTestBase
    {
        [Test]
        [Category("smoke")]
        [TestCaseDescription(Id = "MCS2-566", Name = "Rules and Exceptions - Manage Membership FAQ's -  Add and save a new FAQ")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "MembershipFAQData" })]
        public void VerifyAddMembershipFAQ(Dictionary<string, string> parameters)
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
            manageMembershipFAQsPage.IsAddMembershipFAQsPopUpWindowTitleVisible();

            string question = parameters["questiontxt"].Trim() + DateHelper.RandomString(3, false);
            manageMembershipFAQsPage.EnterFAQQuestionTextInEditorWindow(question);
            string answer = parameters["answertxt"].Trim() + DateHelper.RandomString(3, false);
            manageMembershipFAQsPage.EnterFAQAnswerTextInEditorWindow(answer);
            manageMembershipFAQsPage.IsAddFAQsSaveButtonCllickable();

            string successmsg = parameters["successmsg"].Trim();
            manageMembershipFAQsPage.IsMembershipFAQsAddedMessageDisplayedSuccessfully(successmsg);
        }
    }
}