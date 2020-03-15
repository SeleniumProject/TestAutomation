// <copyright file="VerifyViewMembershipFAQTest.cs" company="PlaceholderCompany">
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
    public class VerifyViewMembershipFAQTest : ProjectTestBase
    {
        [Test]
        [Category("NotReady")]
        [TestCaseDescription(Id = "MCS2-571", Name = "Rules and Exceptions - Manage Membership FAQ's - View FAQ list – Columns")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewMembershipFAQData" })]
        public void VerifyViewMembershipFAQ(Dictionary<string, string> parameters)
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

            string addfaqbuttontext = parameters["addfaqbuttontext"].Trim();
            string questionColumn = parameters["questionColumn"].Trim();
            string answersColumn = parameters["answersColumn"].Trim();
            string statusColumn = parameters["statusColumn"].Trim();
            manageMembershipFAQsPage.IsAddFAQButtonVisible(addfaqbuttontext);
            manageMembershipFAQsPage.IsQuestionColumnVisible(questionColumn);
            manageMembershipFAQsPage.IsAnswersColumnVisible(answersColumn);
            manageMembershipFAQsPage.IsStatusColumnVisible(statusColumn);
            manageMembershipFAQsPage.IsQuestionListTextNotEmpty();
        }
    }
}