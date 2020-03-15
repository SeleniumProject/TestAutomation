// <copyright file="ASTMInternalStaffRenewalTaskRemoveMessageTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit.Tests
{
    using System.Collections.Generic;
    using global::NUnit.Framework;
    using MCS.Test.Automation.Tests.NUnit.DataDriven;
    using MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS;

    [TestFixture]
    public class ASTMInternalStaffRenewalTaskRemoveMessageTest : ProjectTestBase
    {
        [Test]
        [Category("ASTM_Internal")]
        [Category("NotReady")]
        [TestCaseDescription(Id = "[MCS2-1542] ", Name = "ASTM Staff Internal- Officer Titles list – Remove- Message – Yes")]
        [TestCaseSource(typeof(TestData), "GetDetailsFromXML", new object[] { "ASTMInternalRemoveMessageData" })]
        public void ASTMInternalStaffRenewalTaskRemoveMessage(Dictionary<string, string> parameters)
        {
            var loginPage = new LoginPage(this.DriverContext);
            var internalhomePage = new InternalStaffHomePage(this.DriverContext);
            var renewalTasksPage = new InternalStaffRenewalTasksPage(this.DriverContext);
            loginPage.OpenASTMInternalLandingPage();
            loginPage.IsCustomerLogoDisplayed();
            string uname = parameters["uname"].Trim();
            string password = parameters["password"].Trim();
            loginPage.IsUserAbletoLoginMCSApp(uname, password);
            internalhomePage.IsLoggedUserDisplayed();
            internalhomePage.IsRenewalTasksMenuItemClickable();
            renewalTasksPage.IsRenewalTasksHeaderVisible();
            renewalTasksPage.IsUserableToSelectTaskCard();

            renewalTasksPage.IsCommunicationsLogTabClickable();
            string textForComment = parameters["textForComment"].Trim();
            renewalTasksPage.IsUserAbleToAddComment(textForComment);
            renewalTasksPage.IsUserAbletoClickSubmitButton();
            renewalTasksPage.IsUserableToClickDeleteComment();
            string deletePopupText = parameters["deletePopupText"].Trim();
            renewalTasksPage.IsDeleteCommentPopupWindowVisible(deletePopupText);
            string successmsg = parameters["successmsg"].Trim();
            renewalTasksPage.IsSuccessMessageDisplayed(successmsg);
        }
    }
}
