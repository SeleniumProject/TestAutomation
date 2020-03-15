// <copyright file="InternalStaffMembersPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using global::MCS.Test.Automation.Common;
    using global::MCS.Test.Automation.Common.Extensions;
    using global::MCS.Test.Automation.Common.Types;
    using global::MCS.Test.Automation.Tests.PageObjects;
    using NLog;
    using NUnit.Framework;
    using RelevantCodes.ExtentReports;

    public class InternalStaffMembersPage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator
        cityColumnHead = new ElementLocator(Locator.CssSelector, "th.header.header--City.header--expandable");

        private readonly ElementLocator
            membersColumnHead = new ElementLocator(Locator.XPath, "//th[text()=' {0}']");

        private readonly ElementLocator
            ellipsis = new ElementLocator(Locator.CssSelector, "i.icon.ellipsis.vertical");

        private readonly ElementLocator
            checkBoxToSelectColumnPreference = new ElementLocator(Locator.XPath, "//div[@class='react-grid-action-menu-container']//label[text()='{0}']");

        private readonly ElementLocator
         loadbutton = new ElementLocator(Locator.XPath, "//*[@class='ui active transition visible dimmer']");

        private string nmellipsis = "Ellipsis for Column Preferences";
        private string nmcheckBox = "Check Box for Selecting Column Head Preference";

        public InternalStaffMembersPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void GetPageTitle(string expectedTitle)
        {
            try
            {
                string actualTitle = this.Driver.Title;
                Assert.AreEqual(expectedTitle, actualTitle);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Page title Text  is matching with Actual title text ", "The expected Value is " + expectedTitle + " and  actual value is " + actualTitle + " matching successfully");
                Logger.Info("Expected text " + expectedTitle + " and Actual text is " + actualTitle);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void IsColumnHeadVisibleInMembersPage(string name)
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.loadbutton, BaseConfiguration.LongTimeout);
            bool value = this.Driver.IsElementVisibleWithSoftAssertion(this.membersColumnHead.Format(name), name);
            if (value == true)
            {
                Verify.That(this.DriverContext, () => Assert.IsTrue(value), "Verifying whether the :" + name + ": column head is visible", name + ": column head  is visible", "column head  is not visible");
            }
           else
            {
                this.Driver.IsElementClickable(this.ellipsis, this.nmellipsis);
                this.Driver.IsElementClickable(this.checkBoxToSelectColumnPreference.Format(name), this.nmcheckBox);
                bool valueAfterPreferenceSet = this.Driver.IsElementVisibleWithSoftAssertion(this.membersColumnHead.Format(name), name);
                Verify.That(this.DriverContext, () => Assert.IsTrue(valueAfterPreferenceSet), "Verifying whether the :" + name + ": column head is visible", name + ": column head  is visible", "column head  is not visible");
            }
        }
    }
}
