// <copyright file="VerifyContactNameListShownInAlphabeticalOrderInApplicationManagementTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class VerifyContactNameListShownInAlphabeticalOrderInApplicationManagementTest : ProjectTestBase
    {
        [Test]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-469", Name = "Rules and Exceptions – Sort application – Contact Name")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "mcslogin" })]
        public void VerifyContactNameListShownInAlphabeticalOrderInApplicationManagement(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var applicationManagementPage = new ApplicationManagementPage(this.DriverContext);
            var membershipManagementPage = new MemebershipManagementPage(this.DriverContext);
            loginPage.OpenLandingPage();
            loginPage.IsCustomerLogoDisplayed();

            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            homePage.IsCustomerLogoDisplayed();
            homePage.IsLoggedInUserDisplayed(uname);

            homePage.IsApplicationManagementSectionClickable();

            applicationManagementPage.IsUserAbleToClickOnSortIconFromContactName();
            applicationManagementPage.IsContactNameIConSortedSuccessfully();
            applicationManagementPage.AreListOfElementsDisplayInAlphabeticalOrderOrNotForContactName();
        }
    }
}
