// <copyright file="ASTMInternalViewAllTasksForCurrentYearInStatusLaneTest.cs" company="PlaceholderCompany">
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
    public class ASTMInternalViewAllTasksForCurrentYearInStatusLaneTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("NotReady")]
        [TestCaseDescription(Id = "MCS2-1181", Name = "ASTM staff internal application - Login as ASTM staff - Renewal Tasks header menu - Renewal Tasks List page - View all the Tasks created for the current Renewal Year under each status lane")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "AstmInternalStatusLaneData" })]
        public void ASTMInternalViewAllTasksForCurrentYearInStatusLane(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            string username = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(username, password);
            internalhomePage.IsLoggedUserDisplayed();

            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();

            renewalTasksPage.IsUpcomingStatusLaneTaskCountVisible();
            renewalTasksPage.IsOpenStatusLaneTaskCountVisible();
            renewalTasksPage.IsDoneStatusLaneTaskCountVisible();
        }
    }
}
