// <copyright file="VerifyMembershipFAQsFIFOOrderTest.cs" company="PlaceholderCompany">
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
    public class VerifyMembershipFAQsFIFOOrderTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-568", Name = "Rules and Exceptions - Manage Membership FAQ's - FIFO order")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "FIFOFAQData" })]
        public void VerifyMembershipFAQsFIFOOrder(Dictionary<string, string> parameters)
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
            string manageMembershipFAQsheading = parameters["manageMembershipFAQsheading"].Trim();
            homePage.IsManageMembershipFAQsClickable(manageMembershipFAQsheading);

            string questiontxt = parameters["questiontxt"].Trim() + DateHelper.RandomString(3, false);
            string answertxt = parameters["answertxt"].Trim() + DateHelper.RandomString(3, false);

            manageMembershipFAQsPage.AddFAQs(questiontxt, answertxt);

            manageMembershipFAQsPage.FAQsPageRefresh();
            int count = manageMembershipFAQsPage.IsuserabletogetCountOfFAQs();

            string lastquestionfromList = manageMembershipFAQsPage.IsQuestionTextcapturedfromListOfQuestions(count - 1);
            manageMembershipFAQsPage.VerifyWhetherFAQlistIssortedInFIFOOrder(questiontxt, lastquestionfromList);

            string signouttext = parameters["signouttext"].Trim();
            homePage.IsSignOutClickable(signouttext);
        }
    }
}