// <copyright file="VerifyErrorMessageMembershipClassificationNotUniqueTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using System.Threading;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Common.Helpers;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyErrorMessageMembershipClassificationNotUniqueTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-546", Name = "Rules and Exceptions - Error message if the classification type is not unique")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ClassificationErrorUnique" })]
        public void VerifyErrorMessageMembershipClassificationNotUnique(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            loginPage.IsUserAbletoLoginMCSApp(parameters["uname"].Trim(), parameters["password"].Trim());
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedUserDisplayed();
            homePage.IsMembershipManagementSectionClickable();
            homePage.IsManageMembershipClassificationsClickable();
            homePage.IsAddClassificationTypeButtonClickable();
            string classificationType = parameters["ClassificationType"].Trim() + DateHelper.RandomString(4, false);
            string description = parameters["Description"].Trim() + DateHelper.CurrentTimeStamp;
            homePage.IsUserAbleToEnterClassificationTypeInPopUpWindowOfAddClassificationType(classificationType);
            homePage.IsUserAbleToEnterClassificationDescriptionInPopUpWindowOfAddClassificationType(description);
            homePage.IsSaveButtonClickableOfPopUpWindowOfAddClassificationType();
            homePage.IsSuccessfullMessageForAddMembershipClassificationDisplayed();
            homePage.IsAddClassificationTypeButtonClickable();
            homePage.IsUserAbleToEnterClassificationTypeInPopUpWindowOfAddClassificationType(classificationType);
            homePage.IsUserAbleToEnterClassificationDescriptionInPopUpWindowOfAddClassificationType(description);
            homePage.IsSaveButtonClickableOfPopUpWindowOfAddClassificationType();
            string errorMessageUnique = parameters["errorMessageUnique"];
            homePage.IsErrorMessageDisplayedforMembershipClassificationUnique(errorMessageUnique);
            homePage.IsPopUpCloseButtonClickable();
        }
    }
}
