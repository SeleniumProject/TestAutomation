﻿// <copyright file="ASTMInternalMembersVerifyMemberTypeColumnHeadTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalMembersVerifyMemberTypeColumnHeadTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("Regression")]
        [TestCaseDescription(Id = "MCS2-2198", Name = "Member list page to be viewed by ASTM staff in ASTM staff Internal Application - Member Type")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalMemberTypeColumn" })]
        public void ASTMInternalMembersVerifyMemberTypeColumnHead(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var membersPage = new InternalStaffMembersPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();

            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsLoggedUserDisplayed();

            string pagetitle = parameters["pagetitle"].Trim();
            membersPage.GetPageTitle(pagetitle);

            string columnName = parameters["columnName"].Trim();
            membersPage.IsColumnHeadVisibleInMembersPage(columnName);
         }
    }
}
