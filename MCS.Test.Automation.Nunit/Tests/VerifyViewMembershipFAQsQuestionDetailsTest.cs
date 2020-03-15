// <copyright file="VerifyViewMembershipFAQsQuestionDetailsTest.cs" company="PlaceholderCompany">
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
    public class VerifyViewMembershipFAQsQuestionDetailsTest : ProjectTestBase
    {
        [Test]
        [Category("NotReady")]
        [TestCaseDescription(Id = "MCS2-576", Name = "Rules and Exceptions - Manage Membership FAQ's - View FAQ details - Details information")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ViewMembershipFAQDetailsData" })]
        public void VerifyViewMembershipFAQsQuestionDetails(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            var manageMembershipFAQsPage = new ManageMembershipFAQsPage(this.DriverContext);
            loginPage.OpenLandingPage();

            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);

            homePage.IsLoggedInUserDisplayed(uname);
            homePage.IsMembershipManagementSectionClickable();

            string heading = parameters["heading"].Trim();
            homePage.IsManageMembershipFAQsClickable(heading);

            manageMembershipFAQsPage.IsMembershipFAQsHeaderVisible();
            manageMembershipFAQsPage.IsUserabletoViewFAQDetails(1);
            manageMembershipFAQsPage.IsUserableToCloseFAQPopupWindow();

            string signouttext = parameters["signouttext"].Trim();
            homePage.IsSignOutClickable(signouttext);
        }
    }
}