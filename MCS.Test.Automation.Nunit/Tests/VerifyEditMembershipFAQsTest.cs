// <copyright file="VerifyEditMembershipFAQsTest.cs" company="PlaceholderCompany">
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
    public class VerifyEditMembershipFAQsTest : ProjectTestBase
    {
        [Test]
        [Category("NotReady")]
        [TestCaseDescription(Id = "[MCS2-577] ", Name = "Rules and Exceptions -  Manage Membership FAQ's – Edit FAQ details – Edit and save FAQ")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditMembershipFAQData" })]
        public void VerifyEditMembershipFAQs(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            var manageMembershipFAQsPage = new ManageMembershipFAQsPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            var uname = parameters["uname"].Trim();
            var password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedInUserDisplayed(uname);
            homePage.IsMembershipManagementSectionClickable();
            var heading = parameters["heading"].Trim();
            homePage.IsManageMembershipFAQsClickable(heading);
            manageMembershipFAQsPage.IsMembershipFAQsHeaderVisible();
            manageMembershipFAQsPage.SelectFAQFromList(0);
            manageMembershipFAQsPage.IsStatusOfFAQPopupWindowVisible();
            manageMembershipFAQsPage.IsEditFAQBtnClickable();
            manageMembershipFAQsPage.IsUpdateMembershipFAQsPopUpWindowVisible();

           // string textbeforeupdatingQuestion = manageMembershipFAQsPage.IsQuestiontextCaptured();
            var updatedquestion = parameters["updatedquestion"] + DateHelper.RandomString(3, false);
            manageMembershipFAQsPage.EnterFAQQuestionTextInEditorWindow(updatedquestion);

            // string textCapturedafterupdatingQuestion = manageMembershipFAQsPage.IsQuestiontextCaptured();
            var updatedanswer = parameters["updatedanswer"];
            manageMembershipFAQsPage.EnterFAQAnswerTextInEditorWindow(updatedanswer);
            manageMembershipFAQsPage.IsAddFAQsSaveButtonCllickable();
            var successmsg = parameters["successmsg"].Trim();
            manageMembershipFAQsPage.IsFAQUpdatedMessageDisplayedSuccessfully(successmsg);
            manageMembershipFAQsPage.IsMembershipFAQsHeaderVisible();

            // manageMembershipFAQsPage.SelectFAQFromListWithText(textCapturedafterupdatingQuestion);
        }
    }
}