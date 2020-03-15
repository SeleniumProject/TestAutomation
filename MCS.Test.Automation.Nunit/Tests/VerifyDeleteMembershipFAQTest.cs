// <copyright file="VerifyDeleteMembershipFAQTest.cs" company="PlaceholderCompany">
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
    public class VerifyDeleteMembershipFAQTest : ProjectTestBase
    {
        [Test]
        [Category("NotReady")]
        [TestCaseDescription(Id = "MCS2-1814", Name = "Rules and Exceptions -  Manage Membership FAQ's – Deleted FAQ")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "DeleteMembershipFAQData" })]
        public void VerifyUserAbleToDeleteMembershipFAQs(Dictionary<string, string> parameters)
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

            manageMembershipFAQsPage.IsDeleteButtonClickable(questiontxt);
            manageMembershipFAQsPage.IsUserabletoClickOnYesButtonFromFAQConfirmationDialogWindow();

            string deletedMessage = parameters["deletemessagetext"].Trim();
            manageMembershipFAQsPage.IsFAQDeletedMessageDisplayedSuccessfully(deletedMessage);

            manageMembershipFAQsPage.VerifyFAQIsDetletedAndNotVisibleInList(questiontxt);
        }
    }
}