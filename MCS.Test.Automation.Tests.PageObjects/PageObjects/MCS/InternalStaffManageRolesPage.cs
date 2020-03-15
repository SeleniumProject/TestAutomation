// <copyright file="InternalStaffManageRolesPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS
{
    using System;
    using System.Collections.ObjectModel;
    using global::MCS.Test.Automation.Common;
    using global::MCS.Test.Automation.Common.Extensions;
    using global::MCS.Test.Automation.Common.Types;
    using global::MCS.Test.Automation.Tests.PageObjects;
    using NLog;
    using OpenQA.Selenium;
    using RelevantCodes.ExtentReports;

    public class InternalStaffManageRolesPage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly ElementLocator
            rolesTasksHeader = new ElementLocator(Locator.XPath, "//h2[text()='Manage Roles']");

        private readonly ElementLocator
            addRoleBtn = new ElementLocator(Locator.XPath, "//button[text()=' Add Role']");

        private readonly ElementLocator
            addRolePopupHeader = new ElementLocator(Locator.XPath, "//div[@class='header'][text()='Add Role']");

        private readonly ElementLocator
            newRolePrivilegeCommitteeAll = new ElementLocator(Locator.XPath, "//p[text()='Committees']/..//input[@name='All']");

        private readonly ElementLocator
           newRolePrivilegeRolesAdd = new ElementLocator(Locator.XPath, "//p[text()='Roles']/..//input[@name='Add']");

        private readonly ElementLocator
           newRolePrivilegeRenewalAdd = new ElementLocator(Locator.XPath, "//p[text()='Manage Renewal Task']//..//input[@name='Add']");

        private readonly ElementLocator
          newRolePrivilegeRenewalUpdate = new ElementLocator(Locator.XPath, "//p[text()='Manage Renewal Task']//..//input[@name='Update']");

        private readonly ElementLocator
          newRolePrivilegeRenewalExport = new ElementLocator(Locator.XPath, "//p[text()='Manage Renewal Task']//..//input[@name='Export Renewal Tasks']");

        private readonly ElementLocator
            roleNameTextBox = new ElementLocator(Locator.XPath, "//*[@name='RoleName']");

        private readonly ElementLocator
            roleDescription = new ElementLocator(Locator.XPath, "//div/textarea[@name='Description']");

        private readonly ElementLocator
            committeeMgmtTab = new ElementLocator(Locator.XPath, "//div[contains(text(),'Committee Management')]");

        private readonly ElementLocator
            adminTab = new ElementLocator(Locator.XPath, "//div[contains(text(),'Admin')]");

        private readonly ElementLocator
            renewalTasksTab = new ElementLocator(Locator.XPath, "//div[contains(text(),'Renewal Tasks')]");

        private readonly ElementLocator
            roleInAlphabeticalOrder = new ElementLocator(Locator.XPath, "//div[@class='roleCard']//h4");

        private readonly ElementLocator
            membershipManagementPrivileges = new ElementLocator(Locator.XPath, "//div[text()='{0}']");

        private readonly ElementLocator
            roleEditIcon = new ElementLocator(Locator.XPath, "//div[@class='roleCard']//i[@class='pencil icon']");

        private readonly ElementLocator
            roleNameErrorMessage = new ElementLocator(Locator.XPath, "//span[@class='errorMessage']");

        private readonly ElementLocator
        updateBtn = new ElementLocator(Locator.XPath, "//button[@type='submit']");

        private readonly ElementLocator
        popwindowTitle = new ElementLocator(Locator.XPath, "//div[@class='header']");

        private readonly ElementLocator
        privilegeCheckBoxforAll = new ElementLocator(Locator.XPath, "//label[contains(text(), 'All')]");

        private readonly ElementLocator
        updateButton = new ElementLocator(Locator.XPath, "//button[text()='Update']");

        private string nmrolesTasksHeader = "Manage Roles Tasks Header";
        private string nmaddRoleBtn = "Add Role Button";
        private string nmaddRolePopupHeader = "Add Role Popup Header";
        private string nmroleNameTextBox = "Role Name Text Box";
        private string nmroleDescription = "Role Description";
        private string nmcommitteeMgmtTab = "Committee Management Tab";
        private string nmadminTab = "Admin Tab";
        private string nmRenewalTasksTab = "Renewal Tasks Tab";
        private string nmroleInAlphabeticalOrder = "role In Alphabetical Order";
        private string nmupdateBtn = "Update Button";
        private string nmroleNameErrorMessage = "Role Name Error Message";

        public InternalStaffManageRolesPage(DriverContext driverContext)
           : base(driverContext)
        {
        }

        public void IsManageRolessHeaderVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.rolesTasksHeader, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.rolesTasksHeader, this.nmrolesTasksHeader);
        }

        public void IsAddRoleBtnClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.addRoleBtn, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.addRoleBtn, this.nmaddRoleBtn);
            this.Driver.IsElementClickable(this.addRoleBtn, this.nmaddRoleBtn);
        }

        public void IsAddRolePopupVisible()
        {
            this.Driver.WaitForPageLoad();
            this.Driver.IsElementVisible(this.addRolePopupHeader, this.nmaddRolePopupHeader);
        }

        public void IsUserAbleToGivePrivilegesToNewRole()
        {
            try
            {
                this.Driver.WaitUntilElementIsFound(this.committeeMgmtTab, BaseConfiguration.LongTimeout);
                this.Driver.IsElementVisible(this.committeeMgmtTab, this.nmcommitteeMgmtTab);
                this.Driver.IsElementClickable(this.committeeMgmtTab, this.nmcommitteeMgmtTab);
                this.Driver.MouseOverOnWebElement(this.newRolePrivilegeCommitteeAll, this.nmcommitteeMgmtTab);
                bool chkBoxStatusCommittee = this.Driver.IsCheckBoxChecked(this.newRolePrivilegeCommitteeAll);
                if (!chkBoxStatusCommittee)
                {
                    this.Driver.SelectCheckBoxifUnselected(this.newRolePrivilegeCommitteeAll);
                }

                this.Driver.WaitUntilElementIsFound(this.adminTab, BaseConfiguration.LongTimeout);
                this.Driver.IsElementVisible(this.adminTab, this.nmadminTab);
                this.Driver.IsElementClickable(this.adminTab, this.nmadminTab);
                bool chkBoxStatusRoles = this.Driver.IsCheckBoxChecked(this.newRolePrivilegeRolesAdd);
                if (!chkBoxStatusRoles)
                {
                    this.Driver.SelectCheckBoxifUnselected(this.newRolePrivilegeRolesAdd);
                }

                this.Driver.WaitUntilElementIsFound(this.renewalTasksTab, BaseConfiguration.LongTimeout);
                this.Driver.IsElementVisible(this.renewalTasksTab, this.nmRenewalTasksTab);
                this.Driver.IsElementClickable(this.renewalTasksTab, this.nmRenewalTasksTab);
                bool chkBoxStatusRenewalAdd = this.Driver.IsCheckBoxChecked(this.newRolePrivilegeRenewalAdd);
                if (!chkBoxStatusRenewalAdd)
                {
                    this.Driver.SelectCheckBoxifUnselected(this.newRolePrivilegeRenewalAdd);
                }

                bool chkBoxStatusRenewalUpdate = this.Driver.IsCheckBoxChecked(this.newRolePrivilegeRenewalUpdate);
                if (!chkBoxStatusRenewalUpdate)
                {
                    this.Driver.SelectCheckBoxifUnselected(this.newRolePrivilegeRenewalUpdate);
                }

                bool chkBoxStatusRenewalExport = this.Driver.IsCheckBoxChecked(this.newRolePrivilegeRenewalExport);
                if (!chkBoxStatusRenewalExport)
                {
                    this.Driver.SelectCheckBoxifUnselected(this.newRolePrivilegeRenewalExport);
                }

                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Privileges are given for New Role added  ", " Privilege CheckBoxs are clicked successfully");
                Logger.Info(" Privilege checkboxes are checked successfully");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed  Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify if Privilege CheckBoxes is Selected ", "An exception occurred while giving Privileges");
                throw;
            }
        }

        public void IsUserableToEnterRoleName(string roleName)
        {
            this.Driver.IsElementVisible(this.roleNameTextBox, this.nmroleNameTextBox);
            this.Driver.EnterText(this.roleNameTextBox, roleName, this.nmroleNameTextBox);
        }

        public void IsUserAbleToEnterTextInRoleDescription(string text)
        {
            this.Driver.IsElementVisible(this.roleDescription, this.nmroleDescription);
            this.Driver.EnterText(this.roleDescription, text, this.nmroleDescription);
        }

        public void AreNewlyAddedRoleInInAlphabeticalOrder()
        {
            this.Driver.AreElementsSortedInAlphabeticalOrder(this.roleInAlphabeticalOrder, this.nmroleInAlphabeticalOrder);
        }

        public void IsUseAbleToViewMembershipManagementPrivilegesSection(string name)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.membershipManagementPrivileges.Format(name), name);
        }

        public string IsGetExistingRoleNameFromRolesList()
        {
            string existingRole = string.Empty;
            try
            {
                this.Driver.WaitForPageLoad();
                var webElementLocator = this.Driver.GetElements(this.roleInAlphabeticalOrder);
                ReadOnlyCollection<IWebElement> collection = new ReadOnlyCollection<IWebElement>(webElementLocator);
                if (collection.Count >= 0)
                {
                    existingRole = collection[0].Text;
                }
                else
                {
                    DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify the existence of Role in the Roles List", "No Role Exists in the Roles List");
                    Logger.Info("No Role Exists in the Roles List");
                }
            }
            catch (Exception ex)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify the existence of Role in the Roles List", "No Role Exists in the Roles List");
                Logger.Info("No Role Exists in the Roles List" + ex.Message);
                throw;
            }

            return existingRole;
        }

        public void IsEditIconClickOnExistingRole()
        {
            try
            {
                this.Driver.WaitForPageLoad();
                var webElementLocator = this.Driver.GetElements(this.roleEditIcon);
                ReadOnlyCollection<IWebElement> collection = new ReadOnlyCollection<IWebElement>(webElementLocator);
                if (collection.Count > 0)
                {
                    collection[1].Click();
                }
                else
                {
                    DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify the existence of Role in the Roles List", "Role does'nt Exists in the Roles List");
                    Logger.Info("Role does'nt Exists in the Roles List");
                }
            }
            catch (Exception ex)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify the existence of Role in the Roles List", "Role does'nt Exists in the Roles List");
                Logger.Info("Role does'nt Exists in the Roles List" + ex.Message);
                throw;
            }
        }

        public void IsRoleNameErrorMessageDisplayed(string expected)
        {
            this.Driver.IsElementVisible(this.roleNameErrorMessage, this.nmroleNameErrorMessage);
            this.IsErrorMessageDisplayed(expected, this.roleNameErrorMessage);
        }

        public void IsErrorMessageDisplayed(string expected, ElementLocator elemlocatar)
        {
            this.Driver.WaitUntilElementIsFound(elemlocatar, BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(elemlocatar, expected);
        }

        public void IsUserableToUpdateTask()
        {
            this.Driver.IsElementVisible(this.updateBtn, this.nmupdateBtn);
            this.Driver.IsElementClickable(this.updateBtn, this.nmupdateBtn);
        }

        public void IsUserAbleToViewPopupTitle()
        {
            this.Driver.IsElementVisible(this.popwindowTitle, this.nmaddRolePopupHeader);
        }

        public void IsUserAbleToUpdateRolesToExistingUser()
        {
            try
            {
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

        public void IsUserableToUpdateRoles()
        {
            this.Driver.IsElementVisible(this.updateButton, this.nmupdateBtn);
            this.Driver.IsElementClickable(this.updateButton, this.nmupdateBtn);
        }
    }
}
