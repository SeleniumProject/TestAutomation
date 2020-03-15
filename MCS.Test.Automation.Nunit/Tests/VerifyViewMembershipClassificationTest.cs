// <copyright file="VerifyViewMembershipClassificationTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyViewMembershipClassificationTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-550", Name = "Rules and Exceptions -View Member Classification List")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "Classification" })]
        public void VerifyViewMembershipClassification(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);

            homePage.IsLoggedUserDisplayed();
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipClassificationsClickable();
            homePage.IsAddClassificationTypeButtonClickable();
            string classificationType = parameters["ClassificationType"].Trim() + " on " + DateHelper.RandomString(3, false);
            string description = parameters["Description"].Trim() + " on " + DateHelper.CurrentTimeStamp;
            homePage.IsUserAbleToEnterClassificationTypeInPopUpWindowOfAddClassificationType(classificationType);

            homePage.IsUserAbleToEnterClassificationDescriptionInPopUpWindowOfAddClassificationType(description);
            homePage.IsSaveButtonClickableOfPopUpWindowOfAddClassificationType();
            homePage.IsSuccessfullMessageForAddMembershipClassificationDisplayed();
            homePage.IsUserAbleToViewInfoInClassificationTypeColumn(classificationType);
            homePage.IsUserAbleToViewInfoInClassificationDescriptionColumn(description);
            homePage.IsUserAbleToViewManageMembershipClassificationListInLifoOrder(1, classificationType);
        }
    }
}
