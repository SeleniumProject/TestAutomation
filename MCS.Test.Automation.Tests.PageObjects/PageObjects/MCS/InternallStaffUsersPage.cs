﻿// <copyright file="InternallStaffUsersPage.cs" company="PlaceholderCompany">
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
    using global::NUnit.Framework;
    using NLog;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using RelevantCodes.ExtentReports;

    public class InternallStaffUsersPage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly ElementLocator
          userNameColumnInPageList = new ElementLocator(Locator.CssSelector, "th.userName");

        private readonly ElementLocator
            nameColumnInPageList = new ElementLocator(Locator.CssSelector, "th.name");

        private readonly ElementLocator
            emailColumnInPageList = new ElementLocator(Locator.CssSelector, "th.email");

        private readonly ElementLocator
            userRoleColumnInPageList = new ElementLocator(Locator.CssSelector, "th.userType");

        private readonly ElementLocator
            actionColumnInPageList = new ElementLocator(Locator.XPath, "//th[text()='Action']");

        private readonly ElementLocator
            searchBox = new ElementLocator(Locator.CssSelector, "input.prompt");

        private readonly ElementLocator
            searchMessage = new ElementLocator(Locator.CssSelector, "div.header");

        private readonly ElementLocator
            autosuggestionField = new ElementLocator(Locator.CssSelector, "div.result");

        private readonly ElementLocator
            userNameAfterSearch = new ElementLocator(Locator.CssSelector, "td.userName");

        private readonly ElementLocator
          nameAfterSearch = new ElementLocator(Locator.CssSelector, "td.name");

        private readonly ElementLocator
          userEmailAfterSearch = new ElementLocator(Locator.CssSelector, "td.email");

        private readonly ElementLocator
          userRoleAfterSearch = new ElementLocator(Locator.CssSelector, "td.userType");

        private readonly ElementLocator
            selectNoOfItemsperPage = new ElementLocator(Locator.XPath, "//div[text()='25']/../i[@class='dropdown icon']");

        private readonly ElementLocator
            selectpageItemsCount = new ElementLocator(Locator.XPath, "//div[@class='visible menu transition']//span[text()='{0}']");

        private readonly ElementLocator
            autoSuggestionsList = new ElementLocator(Locator.CssSelector, "div.results.transition.visible");

        private readonly ElementLocator
           searchCount = new ElementLocator(Locator.CssSelector, "div.result");

        private readonly ElementLocator
           userNameHyperlink = new ElementLocator(Locator.CssSelector, "td.userName a");

        private readonly ElementLocator
           editIcon = new ElementLocator(Locator.CssSelector, "i.pencil.icon");

        private readonly ElementLocator
           userDropdown = new ElementLocator(Locator.XPath, "//div[@class='ui selection dropdown']//i");

        private readonly ElementLocator
         selectRoleFromDropdown = new ElementLocator(Locator.CssSelector, "div.visible.menu.transition div.item span.text");

        private readonly ElementLocator
  userroleDropdown = new ElementLocator(Locator.XPath, "//div[@class='ui selection dropdown']");

        private readonly ElementLocator
           updateButton = new ElementLocator(Locator.CssSelector, "div.mt30 button.ui.button.primary");

        private readonly ElementLocator
           successMessage = new ElementLocator(Locator.CssSelector, "div.ui.compact.message.success div.content p");

        private readonly ElementLocator
         privilegeCheckBoxforAll = new ElementLocator(Locator.XPath, "//label[contains(text(), 'All')]");

        private readonly ElementLocator
           additionalPrivileges = new ElementLocator(Locator.XPath, "//*[text()='Additional Privileges']");

        private readonly ElementLocator
            roleDropDown = new ElementLocator(Locator.CssSelector, "div.ui.active.visible.selection.dropdown");

        private readonly ElementLocator
          roleDropDownOptions = new ElementLocator(Locator.CssSelector, "div.visible.menu.transition div.item span.text");

        private readonly ElementLocator
          userRoleColumnValues = new ElementLocator(Locator.CssSelector, "td.userType");

        private readonly ElementLocator
          userTypeHeader = new ElementLocator(Locator.XPath, "//tr/th[@class='userType']");

        private readonly ElementLocator
            itemperpagecount = new ElementLocator(Locator.CssSelector, "div.totalPage");

        private string nmitemPerPageCount = "Item Per Page Count";
        private string nmselectpageItemsCount = "Count of Items to be displayed Per Page ";
        private string nmautoSuggestionsList = "List of elements after search";
        private string nmselectNoOfItemsperPage = "Dropdown icon to Select Number of items per Page";
        private string nmNameAfterSearch = "Name field displayed after search";
        private string nmuserEmailAfterSearch = "Email field displayed after search";
        private string nmuserRoleAfterSearch = "Role field displayed after search";
        private string nmuserNameAfterSearch = "UserName field displayed after search";
        private string nmautosuggestionField = "Auto suggestion TextBox Field";
        private string nmsearchBox = "Search Box Field";
        private string nmuser = "User Link";
        private string nmselectrolefromdropdown = "Select Role From Dropdown";

        public InternallStaffUsersPage(DriverContext driverContext)

            : base(driverContext)
        {
        }

        public void IsUserNameColumnVisibleInUsersPageList(string expectedUserName)
        {
            this.Driver.WaitUntilElementIsFound(this.userNameColumnInPageList, BaseConfiguration.LongTimeout);
            var actualUsername = this.Driver.GetText(this.userNameColumnInPageList);
            this.Driver.IsExpectedTextMatchWithActualText(this.userNameColumnInPageList, expectedUserName, actualUsername);
        }

        public void IsNameColumnVisibleInUserspageList(string expectedName)
        {
            var actualname = this.Driver.GetText(this.nameColumnInPageList);
            this.Driver.IsExpectedTextMatchWithActualText(this.nameColumnInPageList, expectedName, actualname);
        }

        public void IsEmailColumnVisibleInUserspageList(string expectedEmailID)
        {
            var actualEmailID = this.Driver.GetText(this.emailColumnInPageList);
            this.Driver.IsExpectedTextMatchWithActualText(this.emailColumnInPageList, expectedEmailID, actualEmailID);
        }

        public void IsRoleColumnVisibleInUserspageList(string expectedRole)
        {
            var actualRole = this.Driver.GetText(this.userRoleColumnInPageList);
            this.Driver.IsExpectedTextMatchWithActualText(this.userRoleColumnInPageList, expectedRole, actualRole);
        }

        public void IsActionColumnVisibleInUserspageList(string expectedAction)
        {
            var actualAction = this.Driver.GetText(this.actionColumnInPageList);
            this.Driver.IsExpectedTextMatchWithActualText(this.actionColumnInPageList, expectedAction, actualAction);
        }

        public void IsHintTextVisibleInSearchBox(string expectedHintText)
        {
            var webelement = this.Driver.GetElement(this.searchBox);
            string actualHintText = webelement.GetAttribute("placeholder");
            try
            {
                Assert.AreEqual(expectedHintText, actualHintText);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Expected Value is matching with Actual text ", "The expected Value is " + expectedHintText + " and  actual value is " + actualHintText + " matching successfully");
            }
            catch (Exception)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify text on " + expectedHintText + "with Actual Text " + actualHintText, "An exception occurred while finding text on " + expectedHintText);
                throw;
            }
        }

        public void IsUserableToEnterTextInSearchBox(string searchText)
        {
            this.Driver.WaitUntilElementIsFound(this.searchBox, BaseConfiguration.LongTimeout);
            this.Driver.EnterText(this.searchBox, searchText, this.nmsearchBox);
        }

        public void IsSearchMessageDisplayed(string expectedSearchmessage)
        {
            string actualSearchMessage = this.Driver.GetText(this.searchMessage);
            try
            {
                Assert.AreEqual(expectedSearchmessage, actualSearchMessage);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Expected Value is matching with Actual text ", "The expected Value is " + expectedSearchmessage + " and  actual value is " + actualSearchMessage + " matching successfully");
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To Verify whether search Message is Displayed", "Search message is displayed Successfully");
            }
            catch (Exception)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify text on " + expectedSearchmessage + "with Actual Text " + actualSearchMessage, "An exception occurred while finding text on " + expectedSearchmessage);
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify whether search Message is Displayed", "Search message is not displayed Successfully");
                throw;
            }
        }

        public void EnterTextAndSelectAutoSuggestion(string searchText)
        {
            this.Driver.WaitUntilElementIsFound(this.searchBox, BaseConfiguration.LongTimeout);
            this.Driver.EnterText(this.searchBox, searchText, this.nmsearchBox);
            this.Driver.IsElementClickable(this.searchBox, this.nmsearchBox);
            this.Driver.IsElementClickable(this.autosuggestionField, this.nmautosuggestionField);
        }

        public void IsExpectedUserNameDisplayedAfterSearchOperation(string expecteduserName)
        {
            this.Driver.WaitUntilElementIsFound(this.userNameAfterSearch, BaseConfiguration.LongTimeout);
            string actualuserName = this.Driver.IsElementTextDisplayed(this.userNameAfterSearch, this.nmuserNameAfterSearch);
            this.Driver.IsExpectedTextMatchWithActualText(this.userNameAfterSearch, expecteduserName, actualuserName);
        }

        public void IsExpectedNameDisplayedAfterSearchOperation(string expectedName)
        {
            string actualName = this.Driver.IsElementTextDisplayed(this.nameAfterSearch, this.nmNameAfterSearch);
            this.Driver.IsExpectedTextMatchWithActualText(this.nameAfterSearch, expectedName, actualName);
        }

        public void IsExpectedEmailDisplayedAfterSearchOperation(string expecteduserEmail)
        {
            string actualuserEmail = this.Driver.IsElementTextDisplayed(this.userEmailAfterSearch, this.nmuserEmailAfterSearch);
            this.Driver.IsExpectedTextMatchWithActualText(this.userEmailAfterSearch, expecteduserEmail, actualuserEmail);
        }

        public void IsExpectedRoleDisplayedAfterSearchOperation(string expecteduserRole)
        {
            string actualuserRole = this.Driver.IsElementTextDisplayed(this.userRoleAfterSearch, this.nmuserRoleAfterSearch);
            this.Driver.IsExpectedTextMatchWithActualText(this.userRoleAfterSearch, expecteduserRole, actualuserRole);
        }

        public void IsUserableToSelectNoOfItemsPerPage(string name, bool value = true)
        {
            this.Driver.ScrollToWebElement(this.selectNoOfItemsperPage);
            this.Driver.IsElementClickable(this.selectNoOfItemsperPage, this.nmselectNoOfItemsperPage);
            if (value == true)
            {
                this.Driver.IsElementClickable(this.selectpageItemsCount.Format(name), this.nmselectpageItemsCount);
            }
        }

        public void IsUserAbletoGetTheItemPerPageText(string countArry1 = "")
        {
            try
            {
                this.Driver.ScrollToWebElement(this.itemperpagecount);
                this.Driver.WaitUntilElementIsFound(this.itemperpagecount, BaseConfiguration.LongTimeout);
                this.Driver.IsElementVisible(this.itemperpagecount, this.nmitemPerPageCount);
                string counttext = this.Driver.GetText(this.itemperpagecount);
                string[] countArry = counttext.Split(' ');
                countArry1 = countArry[2];
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To Verify Item Per Page Count", countArry1 + " : Item Per Page Count is Visble Successfully");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to verify text on with Actual Text " + countArry1 + " Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify count on " + countArry1, "An exception occurred while finding count on " + countArry1);
                throw;
            }
        }

        public void IsUserableToGetCountOfSuggenstionsFromSearchBox(string searchText, int expectedCount)
        {
            this.IsUserableToEnterTextInSearchBox(searchText);
            this.Driver.AreElementsVisible(this.autoSuggestionsList, this.nmautoSuggestionsList);
            var lstElements = this.Driver.GetElements(this.searchCount);
            int actualCount = lstElements.Count;
            try
            {
                Assert.AreEqual(expectedCount, actualCount);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Expected Value is matching with Actual text ", "The expected Value is " + expectedCount + " and  actual value is " + actualCount + " matching successfully");
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To Verify whether autoSuggestions search List has 10 records", "Search List consists of 10 records successfully");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to verify text on " + -expectedCount + "with Actual Text " + actualCount + " Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify count on " + expectedCount + "with Actual count " + actualCount, "An exception occurred while finding count on " + expectedCount);
                throw;
            }
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
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To Verify whether Items displayed for page in user Management contains 25, 50, 75, 100 count in list", " Items displayed for page in user Management contains 25, 50, 75, 100 count in list");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to verify drop down values from items per page Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify item per page drop down An exception occurred while finding count on ");
                throw;
            }
        }

        public void IsUserIsAbleToSelectUsersFromList(int i)
        {
            this.Driver.IsElementVisibleFromListOfElement(this.userNameHyperlink, this.nmuser);
            this.Driver.ClickonSelectedElementfromList(this.userNameHyperlink, this.nmuser, i);
        }

        public void IsUserAbleToClickOnEditIcon()
        {
            this.Driver.WaitUntilElementIsFound(this.editIcon, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.editIcon);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsUserIsAbleToClickOnUserDropDownList()
        {
            this.Driver.WaitUntilElementIsFound(this.userDropdown, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.userDropdown);
            this.Driver.JavaScriptClick(webElement);
        }

        public void SelectRoleFromList(int i)
        {
            this.Driver.IsElementVisibleFromListOfElement(this.selectRoleFromDropdown, this.nmselectrolefromdropdown);
            this.Driver.ClickonSelectedElementfromList(this.selectRoleFromDropdown, this.nmselectrolefromdropdown, i);
        }

        public void IsUserAbleToAddPrivilegesToExistingUser()
        {
            try
            {
                this.Driver.ScrollToWebElement(this.privilegeCheckBoxforAll);
                var webelement = this.Driver.GetElement(this.privilegeCheckBoxforAll, BaseConfiguration.LongTimeout);
                bool value = this.Driver.IsCheckBoxChecked(this.privilegeCheckBoxforAll);
                if (value == false)
                {
                    this.Driver.JavaScriptClick(webelement);
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify All- checkBox is clicked ", " All - checkBox is clicked successfully");
                    Logger.Info(" All-  checkBox is clicked successfully");
                }
                else
                {
                    this.Driver.JavaScriptClick(webelement);
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify All-checkBox status ", " All- checkBox is checked already");
                }
            }
            catch (Exception)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify  All- checkBox is not clicked ", " All - checkBox is not clicked ");
                throw;
            }
        }

        public void IsUserIsAbleToClickOnUpdateButton()
        {
            this.Driver.WaitUntilElementIsFound(this.updateButton, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.updateButton);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsUserAbleToViewAdditionalPrivileges(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.additionalPrivileges, BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(this.additionalPrivileges, expected);
        }

        public void IsUserUpdatedMessageDisplayedSuccessfully(string updateSuccessmessage)
        {
            this.Driver.WaitUntilElementIsFound(this.successMessage, BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(this.successMessage, updateSuccessmessage);
        }

        public void IsAllUserRecordsBasedOnRolesInFilterDrpDwn(string roleName)
        {
            this.Driver.WaitUntilElementIsFound(this.roleDropDownOptions, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickableFromListofElementWithText(this.roleDropDownOptions, roleName);
        }

        public void IsUserRoleDisplayedInAllRecordsBasedOnRoleSelectionFromDropDown(string userRoleColumnValues)
        {
            try
            {
                this.Driver.WaitUntilElementIsFound(this.userTypeHeader, BaseConfiguration.LongTimeout);
                IList<IWebElement> lstTableElements = this.Driver.GetElements(this.userRoleColumnValues);
                bool exist = lstTableElements.All(x => x.Text == userRoleColumnValues);
                if (exist == true)
                {
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify " + userRoleColumnValues + " is visible under the User column ", userRoleColumnValues + " is visible successfully under user Column");
                    Logger.Info(userRoleColumnValues + " is visible successfully under User Column");
                }
                else
                {
                    Assert.IsFalse(exist);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("An exception occured while waiting for the element to become visible " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify " + userRoleColumnValues + " is visible with in provided time " + BaseConfiguration.LongTimeout, "An exception occurred waiting for " + userRoleColumnValues + " to become visible");
                throw;
            }
        }
    }
}