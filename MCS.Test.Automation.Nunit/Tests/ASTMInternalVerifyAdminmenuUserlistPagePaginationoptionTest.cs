// <copyright file="ASTMInternalVerifyAdminmenuUserlistPagePaginationoptionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalVerifyAdminmenuUserlistPagePaginationoptionTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-843", Name = "ASTM Staff Internal Application – Admin menu – User list Page – Pagination option")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "astmInternalEditUserRole" })]
        public void ASTMInternalVerifyAdminmenuUserlistPagePaginationoption(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var homePage = new HomePage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var internalStaffUsersPage = new InternallStaffUsersPage(this.DriverContext);
            var user = new UserManagementPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();

            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);

            homePage.IsLoggedInUserDisplayed(uname);
            homePage.SelectUserPermissionFromAdminMenuitem();

            internalStaffUsersPage.IsUserableToSelectNoOfItemsPerPage("100");
            internalStaffUsersPage.IsUserAbletoGetTheItemPerPageText();
       }
    }
}
