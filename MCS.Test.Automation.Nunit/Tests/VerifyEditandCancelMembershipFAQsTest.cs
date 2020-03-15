// <copyright file="VerifyEditandCancelMembershipFAQsTest.cs" company="PlaceholderCompany">
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
    public class VerifyEditandCancelMembershipFAQsTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-578", Name = "Rules and Exceptions - Manage Membership FAQ's – Edit FAQ details – Edit and Cancel FAQ")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "EditandCancelMembershipFAQData" })]
        public void VerifyEditandCancelMembershipFAQs(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            var manageMembershipFAQsPage = new ManageMembershipFAQsPage(this.DriverContext);
            loginPage.OpenLandingPage();
            var uname = parameters["uname"].Trim();
            var password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);

            homePage.IsLoggedInUserDisplayed(uname);
            homePage.IsMembershipManagementSectionClickable();
            string heading = parameters["heading"].Trim();
            homePage.IsManageMembershipFAQsClickable(heading);
            manageMembershipFAQsPage.IsAddFAQButtonClickable();
            string question = parameters["questiontxt"].Trim() + DateHelper.RandomString(3, false);
            manageMembershipFAQsPage.EnterFAQQuestionTextInEditorWindow(question);
            string answer = parameters["answertxt"].Trim() + DateHelper.RandomString(3, false);
            manageMembershipFAQsPage.EnterFAQAnswerTextInEditorWindow(answer);
            manageMembershipFAQsPage.IsAddFAQsCancelButtonCllickable();
            string signouttext = parameters["signouttext"].Trim();
            homePage.IsSignOutClickable(signouttext);
        }
    }
}