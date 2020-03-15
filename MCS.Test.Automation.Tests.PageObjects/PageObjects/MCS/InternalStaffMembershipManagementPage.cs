// <copyright file="InternalStaffMembershipManagementPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::MCS.Test.Automation.Common;
    using global::MCS.Test.Automation.Common.Extensions;
    using global::MCS.Test.Automation.Common.Types;
    using global::MCS.Test.Automation.Tests.PageObjects;
    using NLog;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using RelevantCodes.ExtentReports;

    public class InternalStaffMembershipManagementPage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly ElementLocator
           memberTypeDropdownXPath = new ElementLocator(Locator.XPath, "//label[text()='Member Type']//..//div[@class='ui selection dropdown']//i");

        private readonly ElementLocator
         memberTypeDropDownOptions = new ElementLocator(Locator.CssSelector, "div.visible.menu.transition div.item span.text");

        private readonly ElementLocator
         memberAccountLink = new ElementLocator(Locator.XPath, "//table[@id='customGrid']//..//tr[1]//td[1]//a[@class='column--Account'][1]");

        private readonly ElementLocator
        editAstmGeneralInformation = new ElementLocator(Locator.XPath, "//h5[text()='ASTM General Information']//..//a[@class='editBtn']");

        private readonly ElementLocator
         graduationDateField = new ElementLocator(Locator.XPath, "//input[@name='GraduationDate']");

        private readonly ElementLocator
         updateAstmGeneralInformation = new ElementLocator(Locator.XPath, "//button[@title='Update']");

        private readonly ElementLocator
         errorMsgReasonForUpdate = new ElementLocator(Locator.XPath, "//span[@class='errorMessage'][text()='Please enter reason for update.']");

        private readonly ElementLocator
        errorMsgGraduationDate = new ElementLocator(Locator.XPath, "//span[@class='errorMessage'][text()='Graduation Date is required.']");

        private readonly ElementLocator
            highlightedMandatoryGraduationDate = new ElementLocator(Locator.XPath, "//label[text()='Graduation Date']/following::div[@class='field error'][1]");

        private readonly ElementLocator
            txtboxReasonForUpdate = new ElementLocator(Locator.XPath, "//textarea[@name='UpdateReason']");

        private readonly ElementLocator
           updateSuccessMessage = new ElementLocator(Locator.CssSelector, "div.content > p");

        private readonly ElementLocator
            committeesOfInterest = new ElementLocator(Locator.XPath, "//div[@name='InterestedCommittee']");

        private readonly ElementLocator
           universityTextField = new ElementLocator(Locator.XPath, "//input[@name='University']");

        private readonly ElementLocator
    incorrectDataGraduationError = new ElementLocator(Locator.XPath, "//span[@class='errorMessage'][text()='Incorrect input.']");

        private readonly ElementLocator
                  majorTextField = new ElementLocator(Locator.XPath, "//input[@name='StudyField']");

        private readonly ElementLocator
         committeeOfInterestOptions = new ElementLocator(Locator.XPath, "//label[text()='Committees of Interest']/..//div[@role='option'][@id=1]");

        private readonly ElementLocator
            existingCommitteesDeleteIcon = new ElementLocator(Locator.XPath, "//div[@name='InterestedCommittee']/a/i[@class='delete icon']");

        private readonly ElementLocator
            committeeOfInterestInput = new ElementLocator(Locator.XPath, "//div[@name='InterestedCommittee']//input");

        private readonly ElementLocator
            selectNoOfItemsperPage = new ElementLocator(Locator.XPath, "//div[text()='25']/../i[@class='dropdown icon']");

        private readonly ElementLocator
            selectpageItemsCount = new ElementLocator(Locator.XPath, "//div[@class='visible menu transition']//span[text()='{0}']");

        private readonly ElementLocator
            defaultValueperPage = new ElementLocator(Locator.XPath, "//div[@class='itemPerPage']//div[@class='text']");

        private readonly ElementLocator
        accountStatusDropDown = new ElementLocator(Locator.XPath, "//label[text()='Account Status']//..//i[@class='dropdown icon']");

        private readonly ElementLocator
           accountStatusSelectActiveInDropDown = new ElementLocator(Locator.XPath, "//div[@class='visible menu transition']//span[text()='{0}']");

        private readonly ElementLocator
           statusColumn = new ElementLocator(Locator.XPath, "//p[@class='column--Status']");

        private readonly ElementLocator
           memberdropdownInSearch = new ElementLocator(Locator.XPath, "//div[text()='Member']");

        private readonly ElementLocator
           searchtextfield = new ElementLocator(Locator.XPath, "//div[@class='ui input searchInput']//input");

        private readonly ElementLocator
           searchclick = new ElementLocator(Locator.XPath, "//i[@class='search icon']");

        private readonly ElementLocator
           errorMessageForNoData = new ElementLocator(Locator.XPath, "//div[@class='noRecordMessage']");

        private string nmeditAstmGeneralInformation = "Edit ASTM General Information";
        private string nmGraduationDateField = "Graduation Date Text Field";
        private string nmupdateAstmGeneralInformation = "Update button for ASTM General Information";
        private string nmtxtboxReasonForUpdate = "Text Area Reason for Update";
        private string nmupdateSuccessMessage = "Record updated successfully.";
        private string nmcommitteesOfInterest = "Committees Of Interest";
        private string nmuniversityTextField = "University Text Field";
        private string nmmajorTextField = "Major Text Field";
        private string nmexistingCommitteesDeleteIcon = "Delete Icon of Existing Committees";
        private string nmaccountStatusDropDown = "Account Status DropDown";
        private string nmaccountStatusSelectActiveInDropDown = "Account Status Select In DropDown";
        private string nmSearchField = "Search Field";
        private string nmSearchClicked = "Search";
        private string nmhintTextInSearch = "Hint Text In Search Text";

        public InternalStaffMembershipManagementPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void IsUserIsAbleToClickOnMemberTypeDropDownList()
        {
            this.Driver.WaitUntilElementIsFound(this.memberTypeDropdownXPath, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.memberTypeDropdownXPath);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsStudentMemberTypeClickableInMemberTypeDrpDwn(string membershipType)
        {
            this.Driver.WaitUntilElementIsFound(this.memberTypeDropDownOptions, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickableFromListofElementWithText(this.memberTypeDropDownOptions, membershipType);
            System.Threading.Thread.Sleep(2000);
        }

        public void IsUserIsAbleToClickOnAccountNumberOfMemberType()
        {
            this.Driver.WaitUntilElementIsFound(this.memberAccountLink, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.memberAccountLink);
            this.Driver.JavaScriptClick(webElement);
            this.Driver.WaitForPageLoad();
        }

        public void IsASTMGeneralInformationEditable()
        {
            this.Driver.ScrollToWebElement(this.editAstmGeneralInformation);
            this.Driver.IsElementVisible(this.editAstmGeneralInformation, this.nmeditAstmGeneralInformation);
            this.Driver.WaitUntilElementIsFound(this.editAstmGeneralInformation, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.editAstmGeneralInformation, this.nmeditAstmGeneralInformation);
        }

        public void IsUserAbleToEnterTextInGraduationDateField(string graduationDate)
        {
            this.Driver.IsElementVisible(this.graduationDateField, this.nmGraduationDateField);
            this.Driver.EnterText(this.graduationDateField, graduationDate, this.nmGraduationDateField);
        }

        public void IsUserAbleToEnterTextInReasonForUpdateField(string reasonForUpdate)
        {
            this.Driver.IsElementVisible(this.txtboxReasonForUpdate, this.nmtxtboxReasonForUpdate);
            this.Driver.EnterText(this.txtboxReasonForUpdate, reasonForUpdate, this.nmtxtboxReasonForUpdate);
        }

        public void IsASTMGeneralInformationUpdateButtonClickable()
        {
            this.Driver.IsElementVisible(this.updateAstmGeneralInformation, this.nmupdateAstmGeneralInformation);
            this.Driver.WaitUntilElementIsFound(this.updateAstmGeneralInformation, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.updateAstmGeneralInformation, this.nmupdateAstmGeneralInformation);
        }

        public void IsGetErrorMessageForReasonForUpdateField(string errorMsg)
        {
            try
            {
                this.Driver.WaitUntilElementIsFound(this.errorMsgReasonForUpdate, BaseConfiguration.LongTimeout);
                var errorMsgWebElement = this.Driver.GetElement(this.errorMsgReasonForUpdate);
                if (errorMsgWebElement.Text.Equals(errorMsg.Trim()))
                {
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Reason For Update Error Message is visible", "Reason For Update Error Message is visible successfully");
                    Logger.Info("Reason For Update Error Message is visible successfully");
                }

                var webElementLocator = this.Driver.GetElement(this.txtboxReasonForUpdate);
                if (webElementLocator.Displayed)
                {
                    this.Driver.HighlightingWebElement(webElementLocator);
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Reason For Update Text Area is Highlighted", "Reason For Update Text Area is Highlighted successfully");
                    Logger.Info("Reason For Update Text Area is Highlighted successfully");
                }
                else
                {
                    Logger.Error("Failed to click on " + errorMsg + "Due to exception: ");

                    DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify " + errorMsg + " is clicked ", "An exception occurred while clicking on " + errorMsg);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("An exception occured while displaying Error message and Highlighting Reason for Update field " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To display Error message and Highlight Reason for Update field", "An exception occurred while displaying Error message and Highlighting Reason for Update field");
                throw;
            }
        }

        public void IsTaskRecordUpdatedSuccessfully(string updateSuccessMessage)
        {
            this.Driver.WaitUntilElementIsFound(this.updateSuccessMessage, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.updateSuccessMessage, this.nmupdateSuccessMessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.updateSuccessMessage, updateSuccessMessage, this.nmupdateSuccessMessage);
        }

        public void IsUserAbleToEnterTextInCommitteesOfInterest(string committee)
        {
            try
            {
                this.Driver.IsElementVisible(this.committeesOfInterest, this.nmcommitteesOfInterest);
                this.Driver.IsElementVisible(this.existingCommitteesDeleteIcon, this.nmexistingCommitteesDeleteIcon);
                this.Driver.IsElementClickable(this.existingCommitteesDeleteIcon, this.nmexistingCommitteesDeleteIcon);
                var committeeInterestInput = this.Driver.GetElement(this.committeeOfInterestInput);
                committeeInterestInput.SendKeys(committee);
                this.Driver.WaitUntilElementIsFound(this.committeeOfInterestOptions, BaseConfiguration.LongTimeout);
                this.Driver.IsElementClickableFromListofElementWithText(this.committeeOfInterestOptions, committee);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify User should able to update Committee of Interest field", "User is able to update Committee of Interest field successfully");
                Logger.Info("User is able to update Committee of Interest successfully");
            }
            catch (Exception ex)
            {
                Logger.Error("An exception occured while updating Committee of Interest field " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify User should able to update Committee of Interest field", "An exception occurred while while updating Committee of Interest field");
                throw;
            }
        }

        public void IsASTMGeneralInformationMandatoryFieldsCleared()
        {
            IWebElement graduationWebElement = this.Driver.GetElement(this.graduationDateField);
            string graduationDateText = graduationWebElement.GetAttribute("value");
            if (graduationDateText != string.Empty)
            {
                graduationWebElement.Clear();
            }
        }

        public void IsGetErrorMessageForGraduationField(string errorMsg)
        {
            this.Driver.WaitUntilElementIsFound(this.errorMsgGraduationDate, BaseConfiguration.LongTimeout);
            var errorMsgWebElement = this.Driver.GetElement(this.errorMsgGraduationDate);
            if (errorMsgWebElement.Text.Equals(errorMsg.Trim()))
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Graduation Date Mandatory Field Error Message is visible", "Graduation Date Mandatory Field Error Message is visible successfully");
                Logger.Info("Graduation Date Mandatory Field Error message is visible successfully");
            }

            this.Driver.WaitUntilElementIsFound(this.highlightedMandatoryGraduationDate, BaseConfiguration.LongTimeout);
            var grauadtionFieldHighlighted = this.Driver.GetElement(this.highlightedMandatoryGraduationDate);
            if (grauadtionFieldHighlighted.Displayed)
            {
                var webElementLocator = this.Driver.GetElement(this.graduationDateField);
                if (webElementLocator.Displayed)
                {
                    this.Driver.HighlightingWebElement(webElementLocator);
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Graduation Date Mandatory Field is Highlighted", "Graduation Date Mandatory Field is Highlighted successfully");
                    Logger.Info("Graduation Date Mandatory Field is Highlighted successfully");
                }
            }
            else
            {
                throw new Exception("Graduation Date Mandatory Field is not Highlighted");
            }
       }

        public void IsUserAbleToEnterTextInUniversityField(string university)
        {
            this.Driver.IsElementVisible(this.universityTextField, this.nmuniversityTextField);
            this.Driver.EnterText(this.universityTextField, university, this.nmuniversityTextField);
        }

        public void IsIncorrectDataErrorMsgDisplayedAndFieldHighlighted(string errorMsg)
        {
            this.Driver.WaitUntilElementIsFound(this.incorrectDataGraduationError, BaseConfiguration.LongTimeout);
            var errorMsgWebElement = this.Driver.GetElement(this.incorrectDataGraduationError);
            if (errorMsgWebElement.Text.Equals(errorMsg.Trim()))
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Graduation Date Incorrect Input Error Message is visible", "Graduation Date Incorrect Input Error Message is visible successfully");
                Logger.Info("Graduation Date Incorrect Input Error message is visible successfully");
            }

            this.Driver.WaitUntilElementIsFound(this.highlightedMandatoryGraduationDate, BaseConfiguration.LongTimeout);
            var grauadtionFieldHighlighted = this.Driver.GetElement(this.highlightedMandatoryGraduationDate);
            if (grauadtionFieldHighlighted.Displayed)
            {
                var webElementLocator = this.Driver.GetElement(this.graduationDateField);
                if (webElementLocator.Displayed)
                {
                    this.Driver.HighlightingWebElement(webElementLocator);
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Graduation Date Incorrect Input Field is Highlighted", "Graduation Date Incorrect Input Field is Highlighted successfully");
                    Logger.Info("Graduation Date Incorrect Input Field is Highlighted successfully");
                }
            }
            else
            {
                throw new Exception("Graduation Date Incorrect Input Field is not Highlighted");
            }
        }

        public void IsUserAbleToEnterTextInMajorTextField(string major)
        {
            this.Driver.IsElementVisible(this.majorTextField, this.nmmajorTextField);
            this.Driver.EnterText(this.majorTextField, major, this.nmmajorTextField);
        }

        public void IsDefaultValuedisplayedAs25(string text)
        {
            this.Driver.ScrollToWebElement(this.selectNoOfItemsperPage);
            this.Driver.IsExpectedTextMatchWithActualText(this.defaultValueperPage, text);
        }

        public void IsUserableToSeeResultsPerPageDropdownWithValues()
        {
            try
            {
                IList<string> lstElements1 = new List<string>() { "25", "50", "75", "100" };
                IList<string> lstElements2 = new List<string>();
                IList<IWebElement> webelementslist = this.Driver.GetElements(this.selectNoOfItemsperPage);
                foreach (IWebElement i in webelementslist)
                {
                    lstElements2.Add(i.Text);
                }

                var result = lstElements1.Except(lstElements2).ToList();
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To Verify whether Items displayed for page in Member Management contains 25, 50, 75, 100 count in list", " Items displayed for page in Member Management contains 25, 50, 75, 100 count in list");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to verify drop down values from items per page Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify item per page drop down An exception occurred while finding count on ");
            }
}

        public void IsUserAbleToClickOnAccountStatusDropDown()
        {
            this.Driver.IsElementVisible(this.accountStatusDropDown, this.nmaccountStatusDropDown);
            this.Driver.IsElementClickable(this.accountStatusDropDown, this.nmaccountStatusDropDown);
        }

        public void IsUserAbleToClickOnAccountStatusSelectActiveInDropdown(string name)
        {
            this.Driver.IsElementVisible(this.accountStatusSelectActiveInDropDown.Format(name), this.nmaccountStatusSelectActiveInDropDown);
            this.Driver.IsElementClickable(this.accountStatusSelectActiveInDropDown.Format(name), this.nmaccountStatusSelectActiveInDropDown);
        }

        public void IsUserAbleToViewStatusColumn(string name)
        {
            try
            {
                this.Driver.WaitUntilElementIsFound(this.statusColumn, BaseConfiguration.LongTimeout);
                IList<IWebElement> lstTableElements = this.Driver.GetElements(this.statusColumn);
                bool exist = lstTableElements.All(x => x.Text == name);
                if (exist == true)
                {
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify " + name + " is visible under the User column ", name + " is visible successfully under status Column");
                    Logger.Info(name + " is visible successfully under status Column");
                }
                else
                {
                    Assert.IsFalse(exist);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("An exception occured while waiting for the element to become visible " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify " + name + " is visible with in provided time " + BaseConfiguration.LongTimeout, "An exception occurred waiting for " + name + " to become visible");
            }
        }

        public void IsUserAbleToViewMemberInDropDownBesideSeachBox(string name)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.memberdropdownInSearch, name);
        }

        public void IsUserAbleToEnterTextInSearchField(string name)
        {
            this.Driver.EnterText(this.searchtextfield, name, this.nmSearchField);
        }

        public void IsUserAbleToClickOnSearch()
        {
            this.Driver.IsElementVisible(this.searchclick, this.nmSearchClicked);
            this.Driver.WaitUntilElementIsFound(this.searchclick, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.searchclick, this.nmSearchClicked);
        }

        public void IsUserAbleToViewNoDataFound(string name)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.errorMessageForNoData, name);
        }

        public void IsHintTextVisibleInSearchBox(string expectedHintText)
        {
            this.Driver.IsElementVisible(this.searchtextfield, this.nmhintTextInSearch);
            var webelement = this.Driver.GetElement(this.searchtextfield);
            string actualHintText = webelement.GetAttribute("placeholder");
            try
            {
                Verify.That(this.DriverContext, () => Assert.AreEqual(expectedHintText, actualHintText), "Verifying search placeholder from search box :" + expectedHintText, actualHintText + " search box place holder displayed successfully", "search box placeholder is not displaying");
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Expected Value is matching with Actual text ", "The expected Value is " + expectedHintText + " and  actual value is " + actualHintText + " matching successfully");
            }
            catch (Exception)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify text on " + expectedHintText + "with Actual Text " + actualHintText, "An exception occurred while finding text on " + expectedHintText);
                throw;
            }
        }
    }
}
