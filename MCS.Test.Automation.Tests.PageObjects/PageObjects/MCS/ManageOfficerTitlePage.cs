// <copyright file="ManageOfficerTitlePage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS
{
    using System;
    using System.Collections.Generic;
    using global::MCS.Test.Automation.Common;
    using global::MCS.Test.Automation.Common.Extensions;
    using global::MCS.Test.Automation.Common.Types;
    using global::MCS.Test.Automation.Tests.PageObjects;
    using global::NUnit.Framework;
    using NLog;
    using OpenQA.Selenium;
    using RelevantCodes.ExtentReports;

    public class ManageOfficerTitlePage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator
customerLogo = new ElementLocator(Locator.CssSelector, "img.ui.image");

        private readonly ElementLocator
membershipmenu = new ElementLocator(Locator.CssSelector, "i.address.card.icon");

        private readonly ElementLocator
committeemanagement = new ElementLocator(Locator.CssSelector, "i.users.icon");

        private readonly ElementLocator
            applicationManagement = new ElementLocator(Locator.CssSelector, "i.cog.icon");

        private readonly ElementLocator
            managemembershiptype = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(1)");

        private readonly ElementLocator
            manageMembershipFAQs = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(2)");

        private readonly ElementLocator
            manageMembershipDocuments = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(3)");

        private readonly ElementLocator
            manageMemberClassifications = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(4)");

        private readonly ElementLocator
            officerTitleheader = new ElementLocator(Locator.CssSelector, "div.headingTitle.clearfix h2");

        private readonly ElementLocator
            addOfficerTitleButton = new ElementLocator(Locator.CssSelector, "button.ui.secondary.button");

        private readonly ElementLocator
            cardtitleEditbutton = new ElementLocator(Locator.XPath, "//*[@class='roleCard']/h4[text()='{0}']/following::div[2]/i");

        private readonly ElementLocator
            officerTitleUpdatebutton = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
            listofRolCard = new ElementLocator(Locator.CssSelector, "div.roleCard h4");

        private readonly ElementLocator
            popupaddnewofficerTitleheader = new ElementLocator(Locator.CssSelector, "div.header");

        private readonly ElementLocator
            officertitletext = new ElementLocator(Locator.Name, "add_OfficerTitleName");

        private readonly ElementLocator
            addofficersavebutton = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
            successfullMsg = new ElementLocator(Locator.CssSelector, "div.ui.compact.message.success div.content p");

        private readonly ElementLocator
            cardTitlesList = new ElementLocator(Locator.CssSelector, "div.roleCard h4");

        private readonly ElementLocator
            cardTitleStatusfield = new ElementLocator(Locator.XPath, " //h4[text()='{0}']/..//div[@class='roleStatus']/span[starts-with(@class, 'statusIndicator')]");

        private readonly ElementLocator
             cardTitleResponsibilities = new ElementLocator(Locator.XPath, " //*[@class='roleCard']/h4[text()='{0}']/following::div[3]/span[@class='privelegeHead']");

        private readonly ElementLocator
            officerTitleAlredyExistmsg = new ElementLocator(Locator.CssSelector, "span.errorMessage");

        private readonly ElementLocator
            officerTitlePopUpwindowcloseIcon = new ElementLocator(Locator.CssSelector, "div.header i.close");

        private readonly ElementLocator
            officerTitleStausActive = new ElementLocator(Locator.XPath, "//*[@class='roleCard']/h4[text()='{0}']/following::div[1]/span[@class='statusIndicator active']");

        private readonly ElementLocator
            officerTitleMandatory = new ElementLocator(Locator.CssSelector, "span.errorMessage");

        private string nmofficerTitleAlredyExistmsg = "Officer Title already exists.";
        private string nmcardtitleEditbutton = "Edit icon in Officer Title Card";
        private string nmofficerStatusfield = "Status-field in Officer Title Card";
        private string nmofficerTitlesuccessfullmessage = "New Officer Title added successfully.";
        private string nmaddOfficerTitleButton = "Add Officer Title button";
        private string nmpopupaddnewofficerTitleheader = "ADD NEW OFFICER TITLE";
        private string nmofficertitletext = "Officer Title Text";
        private string nmaddooficersavebutton = "Add New Officer Title Save button";
        private string nmcustomerlogo = "Customer logo";
        private string nmmembership = "Memebership Management Menu";
        private string nmcommitteemanagement = "Committee Management Menu";
        private string nmapplicationmanagement = "Application Management Menu";
        private string nmmanagememebershiptype = "Manage Membership Type option";
        private string nmmanagemembershipFaqs = "Manage Membership FAQ's option";
        private string nmmanagemembershipdocument = "Manage Membership Documents option";
        private string nmmanagememeberclassifications = "Manage Member Classifications option";
        private string nmofficerTitleheader = "Officer Titles header";
        private string nmofficerTitleUpdateButton = "Officer Title Update button";
        private string nmOfficerTitlePopUpwindowcloseIcon = "Close button";

        public ManageOfficerTitlePage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void ClickOnCloseButtonOfAddOfficerTitlePopUpWindow()
        {
            this.Driver.IsElementClickable(this.officerTitlePopUpwindowcloseIcon, this.nmOfficerTitlePopUpwindowcloseIcon);
        }

        public void IsCustomerLogoDisplayed()
        {
            this.Driver.IsElementVisible(this.customerLogo, this.nmcustomerlogo);
        }

        public void IsUpdateButtonOfOfficerTitleClickable()
        {
            this.Driver.IsElementVisible(this.officerTitleUpdatebutton, this.nmofficerTitleUpdateButton);
            this.Driver.IsElementClickable(this.officerTitleUpdatebutton, this.nmofficerTitleUpdateButton);
        }

        public void IsMembershipManagementSectionClickable(string name)
        {
            this.Driver.IsElementVisible(this.membershipmenu.Format(name), this.nmmembership);
            this.Driver.IsElementClickable(this.membershipmenu.Format(name), this.nmmembership);
        }

        public void IsOffierTitleRecordEditableFromListOfRecords(string officerTitle)
        {
            this.Driver.IsElementClickableFromListofElement(this.cardtitleEditbutton.Format(officerTitle), officerTitle);
        }

        public void IsOfficerTitleDisplayedInListofOfficerTitle(string officerTitleText)
        {
            this.Driver.WaitUntilElementIsFound(this.listofRolCard, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisibleFromListOfElement(this.listofRolCard.Format(officerTitleText), officerTitleText);
        }

        public void IsCommitteeManagementSectionClickable(string name)
        {
            this.Driver.IsElementVisible(this.committeemanagement.Format(name), this.nmcommitteemanagement);
            this.Driver.IsElementClickable(this.committeemanagement.Format(name), this.nmcommitteemanagement);
        }

        public void IsApplicationManagementSectionClickable(string name)
        {
            this.Driver.IsElementVisible(this.applicationManagement.Format(name), this.nmapplicationmanagement);
            this.Driver.IsElementClickable(this.applicationManagement.Format(name), this.nmapplicationmanagement);
        }

        public void IsManageOfficerTitleHeaderDisplayed(string header)
        {
            var text = this.Driver.GetText(this.officerTitleheader);
            this.Driver.IsElementVisible(this.officerTitleheader.Format(header), this.nmofficerTitleheader);
            Assert.AreEqual(text, header, "Officer Title header is missing");
        }

        public void IsAddOfficerTitleButtonClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.addOfficerTitleButton, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.addOfficerTitleButton);
            this.Driver.IsElementVisible(this.addOfficerTitleButton, this.nmaddOfficerTitleButton);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsAddNewOfficerTitleHeaderDisplayedInPopUpWindow(string popuptitle)
        {
            this.Driver.IsElementVisible(this.popupaddnewofficerTitleheader, this.nmpopupaddnewofficerTitleheader);
            this.Driver.IsExpectedTextMatchWithActualText(this.popupaddnewofficerTitleheader, popuptitle, this.nmpopupaddnewofficerTitleheader);
        }

        public void IsNewOfficerTitleaddedsuccessfullyDisplayed(string message)
        {
            this.Driver.IsElementVisible(this.successfullMsg, this.nmofficerTitlesuccessfullmessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.successfullMsg, message, this.nmofficerTitlesuccessfullmessage);
        }

        public void IsUserAbletoEnterOfficerTitleInTextBox(string officerTitleText)
        {
            this.Driver.IsElementVisible(this.officertitletext, this.nmofficertitletext);
            this.Driver.EnterText(this.officertitletext, officerTitleText, this.nmofficertitletext);
        }

        public void IsAddNewOfficerSaveButtonClickable()
        {
            this.Driver.IsElementVisible(this.addofficersavebutton, this.nmaddooficersavebutton);
            this.Driver.IsElementClickable(this.addofficersavebutton, this.nmaddooficersavebutton);
        }

        public void IsManageMembershipTypeClickable(string name)
        {
            this.Driver.IsElementVisible(this.managemembershiptype.Format(name), this.nmmanagememebershiptype);
            this.Driver.IsElementClickable(this.managemembershiptype.Format(name), this.nmmanagememebershiptype);
        }

        public void IsManageMembershipFAQsClickable(string name)
        {
            this.Driver.IsElementVisible(this.manageMembershipFAQs.Format(name), this.nmmanagemembershipFaqs);
            this.Driver.IsElementClickable(this.manageMembershipFAQs.Format(name), this.nmmanagemembershipFaqs);
        }

        public void IsManageMembershipDocumentsClickable(string name)
        {
            this.Driver.IsElementVisible(this.manageMembershipDocuments.Format(name), this.nmmanagemembershipdocument);
            this.Driver.IsElementClickable(this.manageMembershipDocuments.Format(name), this.nmmanagemembershipdocument);
        }

        public void IsOfficerTitleUpdateMessageDisplayedSuccessfully(string updateSuccessmessage)
        {
            this.Driver.IsElementVisible(this.successfullMsg, this.nmofficerTitlesuccessfullmessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.successfullMsg, updateSuccessmessage, this.nmofficerTitlesuccessfullmessage);
        }

        /// <summary>
        /// Manage Memebership Classification option.
        /// </summary>
        /// <param name="name">Element Name.</param>
        public void IsManageMembershipClassificationsClickable(string name)
        {
            this.Driver.IsElementVisible(this.manageMemberClassifications.Format(name), this.nmmanagememeberclassifications);
            this.Driver.IsElementClickable(this.manageMemberClassifications.Format(name), this.nmmanagememeberclassifications);
        }

        public int IsuserabletogetListofofficerCards()
        {
            IList<IWebElement> lstElements = this.Driver.GetElements(this.cardTitlesList);
            int elementcount = lstElements.Count;
            return elementcount;
        }

        public string IsuserabletoGetTextofOfficerTitle(int index)
        {
            this.Driver.WaitUntilElementIsFound(this.cardTitlesList, BaseConfiguration.LongTimeout);
            IList<IWebElement> lstElements = this.Driver.GetElements(this.cardTitlesList);
            string officertext = lstElements[index].GetTextContent();
            return officertext;
        }

        public void IsOfficerAlredyExistMessageDisplayed(string officerAlredyExistMessage)
        {
            this.Driver.IsElementVisible(this.officerTitleAlredyExistmsg, this.nmofficerTitleAlredyExistmsg);
            this.Driver.IsExpectedTextMatchWithActualText(this.officerTitleAlredyExistmsg, officerAlredyExistMessage, this.nmofficerTitleAlredyExistmsg);
        }

        public void IsuserabletoViewStatusfieldOfOfficerCard(string name)
        {
            this.Driver.IsElementVisible(this.cardTitleStatusfield.Format(name), this.nmofficerStatusfield);
        }

        public void IsuserabletoViewEditButtonOfOfficerCard(string name)
        {
            this.Driver.IsElementVisible(this.cardtitleEditbutton.Format(name), this.nmcardtitleEditbutton);
        }

        public void IsUserableToViewResponsibilitiesField(string name, string actualText)
        {
            try
            {
                string expectedText = this.Driver.GetText(this.cardTitleResponsibilities.Format(name));
                Assert.AreEqual(expectedText, actualText);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Expected Value is matching with Actual text ", "The expected Value is " + expectedText + " and  actual value is " + actualText + " matching successfully");
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To Verify Responsibilities field is visible", "Responsibilities field is visible successfully");
                Logger.Info("Expected text " + expectedText + " and Actual text is " + actualText);
            }
            catch (Exception ex)
            {
                Logger.Error("Failed Due to exception: " + ex.ToString());
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify whether Responsibilities field is visible", " An exception occured as Responsibilities field is not visible");
                throw;
            }
        }

        public void IsUserAbleToViewNewOfficerIsByDefaultActiveStatus(string expected, string officerName)
        {
            var actualStatus = this.Driver.GetText(this.officerTitleStausActive.Format(officerName));
            this.Driver.IsExpectedTextMatchWithActualText(this.officerTitleStausActive.Format(officerName), expected, actualStatus);
        }

        public void IsOfficerTitleMandatory(string expected)
        {
            var actual = this.Driver.GetText(this.officerTitleMandatory);
            this.Driver.IsExpectedTextMatchWithActualText(this.officerTitleMandatory, expected, actual);
        }
    }
}
