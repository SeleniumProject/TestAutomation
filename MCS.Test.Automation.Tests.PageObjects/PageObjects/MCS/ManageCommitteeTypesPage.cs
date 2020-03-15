// <copyright file="ManageCommitteeTypesPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS
{
    using System;
    using global::MCS.Test.Automation.Common;
    using global::MCS.Test.Automation.Common.Extensions;
    using global::MCS.Test.Automation.Common.Types;
    using global::MCS.Test.Automation.Tests.PageObjects;
    using global::NUnit.Framework;
    using NLog;
    using RelevantCodes.ExtentReports;

    public class ManageCommitteeTypesPage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly ElementLocator
            committeTypeheader = new ElementLocator(Locator.CssSelector, "div.headingTitle.clearfix h2");

        private readonly ElementLocator
            addCommitteeTypeButton = new ElementLocator(Locator.CssSelector, "button.ui.secondary.button");

        private readonly ElementLocator
            committeeTypetext = new ElementLocator(Locator.Name, "CommitteeTypeName");

        private readonly ElementLocator
           manageCommitteeHierarchytext = new ElementLocator(Locator.Name, "level");

        private readonly ElementLocator
            addCommitteeTypesavebutton = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
            addLevel = new ElementLocator(Locator.XPath, "//a[@class='addBtn']");

        private readonly ElementLocator
            successfullMsg = new ElementLocator(Locator.CssSelector, "div.ui.compact.message.success div.content p");

        private readonly ElementLocator
            balanceRequiredForNoButton = new ElementLocator(Locator.XPath, "//label[text()='Balance Required']/..//div[contains(@class,'ui checked')]/input");

        private readonly ElementLocator
            balanceRequiredForYesButton = new ElementLocator(Locator.XPath, "//label[text()='Yes']");

        private readonly ElementLocator
            membershipTypeInBR = new ElementLocator(Locator.XPath, "//span[text()='Member Classification Type']/../ul/li");

        private readonly ElementLocator
               membershipTypeInBR2 = new ElementLocator(Locator.CssSelector, "div#classificationError ul li");

        private readonly ElementLocator
          loadbutton = new ElementLocator(Locator.XPath, "//*[@class='ui active transition visible dimmer']");

        private readonly ElementLocator
            selectDropdownForOperator = new ElementLocator(Locator.CssSelector, "div.ui.selection.dropdown div.text");

        private readonly ElementLocator
            operatorConditionSelection = new ElementLocator(Locator.CssSelector, "div.visible.menu.transition div span");

        private readonly ElementLocator
            brlabel = new ElementLocator(Locator.XPath, "//label[text()='Balance Required']");

        private readonly ElementLocator
             manageCommitteeHierarchyHeader = new ElementLocator(Locator.XPath, "//h5[contains(text(),'{0}')]");

        private readonly ElementLocator
            mandatoryFieldErrorMsg = new ElementLocator(Locator.CssSelector, "[class^='errorMessage']");

        private readonly ElementLocator
           membershipTypeEligibleTojoinHeader = new ElementLocator(Locator.XPath, "//h5[contains(text(),'{0}')]");

        private readonly ElementLocator
           balanceRequiredHeader = new ElementLocator(Locator.XPath, "//label[contains(text(),'{0}')]");

        private readonly ElementLocator
           enableCommitteeTypeonwebHeader = new ElementLocator(Locator.XPath, "//label[contains(text(),'{0}')]");

        private readonly ElementLocator
            errorMsgUnique = new ElementLocator(Locator.CssSelector, "div.ui.compact.message.error div.content p");

        private readonly ElementLocator
            dropDownIconforOperator = new ElementLocator(Locator.XPath, "//div[@class='operator ']//i");

        private readonly ElementLocator
            errorCommitteeTypeName = new ElementLocator(Locator.XPath, "//span[@class='errorMessage'][contains(.,'{0}')]");

        private readonly ElementLocator
           errorCommitteeTypeLevels = new ElementLocator(Locator.XPath, "//span[@class='errorMessage'][contains(.,'{0}')]");

        private readonly ElementLocator
           availableMembershipTypesHeader = new ElementLocator(Locator.XPath, "//h3[contains(text(),'{0}')]");

        private readonly ElementLocator
           selectedMembershipTypesHeader = new ElementLocator(Locator.XPath, "//h3[contains(text(),'{0}')]");

        private readonly ElementLocator
           selectedelegibletoJOinFrom = new ElementLocator(Locator.XPath, "(//div[@data-react-beautiful-dnd-draggable='0'])[1]");

        private readonly ElementLocator
           selectedelegibletoJOinEdit = new ElementLocator(Locator.XPath, "(//div[@data-react-beautiful-dnd-draggable='1'])[2]");

        private readonly ElementLocator
           selectedelegibletoJOinTo = new ElementLocator(Locator.XPath, "(//div[@class='sc-bxivhb bpKHpE'])[2]");

        private readonly ElementLocator
           getLatestRecord = new ElementLocator(Locator.XPath, "//table[1]//tr[1]//td[1]//a[contains(.,'{0}')]");

        private readonly ElementLocator
         errorMessageBlankOnCommiteeType = new ElementLocator(Locator.XPath, "//span[@class='errorMessage']");

        private readonly ElementLocator
            incorrectInput = new ElementLocator(Locator.CssSelector, "span.errorMessage");

        private readonly ElementLocator
            mandatoryInput = new ElementLocator(Locator.CssSelector, "span.errorMessage.mt0");

        private readonly ElementLocator
        editButton = new ElementLocator(Locator.XPath, "//i[@class='pencil icon']");

        private readonly ElementLocator
        getSecondRecord = new ElementLocator(Locator.XPath, "//table[1]//tr[2]//td[1]//a//text()");

        private readonly ElementLocator
        errorHierarchyUniqueLevel = new ElementLocator(Locator.XPath, "//span[contains(.,'{0}')]");

        private readonly ElementLocator
        parentChildHierarchyLevel = new ElementLocator(Locator.XPath, "(//span[@class='comitteName'])[{0}]");

        private readonly ElementLocator
       parentChildHierarchyLevelCloseButton = new ElementLocator(Locator.XPath, "(//i[@class='close icon'])[{0}]");

        private readonly ElementLocator
       parentChildHierarchyLevelDisplay = new ElementLocator(Locator.XPath, " //span[@class='levelPills'][contains(.,'{0}')]");

        private readonly ElementLocator
        selectedMembershipTypesText = new ElementLocator(Locator.XPath, "//div[@data-react-beautiful-dnd-draggable='1'][contains(.,'{0}')]");

        private readonly ElementLocator
            sortIconOfCommitteeType = new ElementLocator(Locator.CssSelector, "th.CommitteeName i.sort.icon");

        private readonly ElementLocator
          sortedIConForCommitteeType = new ElementLocator(Locator.CssSelector, "th.CommitteeName i.long.arrow.alternate.up.icon.activeSort");

        private readonly ElementLocator
           committeeTypeLink = new ElementLocator(Locator.XPath, "//table[@class='customTable CommitteeTable']/tbody//tr//a");

        private readonly ElementLocator
            enableCommitteeTypeonwebCheckBox = new ElementLocator(Locator.XPath, "//label[contains(.,'{0}')]");

        private readonly ElementLocator
            enableCommitteeTypeonwebEnableDiv = new ElementLocator(Locator.XPath, "(//div[contains(@class,'title')])[1]");

        private readonly ElementLocator
            sortIconOfbalanceRequired = new ElementLocator(Locator.CssSelector, "th.CommitteeFee i.sort.icon");

        private readonly ElementLocator
          sortedIConForbalanceRequired = new ElementLocator(Locator.CssSelector, "th.CommitteeFee i.long.arrow.alternate.up.icon.activeSort");

        private readonly ElementLocator
           balanceRequiredLink = new ElementLocator(Locator.XPath, "//table[@class='customTable CommitteeTable']/tbody//tr//td[2]");

        private readonly ElementLocator
           sortIconOfPermittedMembers = new ElementLocator(Locator.CssSelector, "th.isEnabled i.sort.icon");

        private readonly ElementLocator
          sortedIConForPermittedMembers = new ElementLocator(Locator.CssSelector, "th.isEnabled i.long.arrow.alternate.up.icon.activeSort");

        private readonly ElementLocator
             permittedMembersLink = new ElementLocator(Locator.XPath, "//table[@class='customTable CommitteeTable']/tbody//tr//td[3]");

        private readonly ElementLocator
             radioButtonForLimitedMembers = new ElementLocator(Locator.XPath, "//label[text()='Limited']");

        private readonly ElementLocator
            textBoxforNumbers = new ElementLocator(Locator.XPath, "//input[@name='NoOfMembersPermitted']");

        private readonly ElementLocator
          enableCommitteeTypeonwebEnablViewInfoDiv = new ElementLocator(Locator.XPath, "(//div[contains(@class,'title')])[{0}]");

        private readonly ElementLocator
          committeeTypeonwebEnablViewInfoDivLables = new ElementLocator(Locator.XPath, "(//label[contains(.,'{0}')])[{1}]");

        private readonly ElementLocator
           balanceRuleInViewPage = new ElementLocator(Locator.XPath, "//label[text()='Set Balance Rule']");

        private readonly ElementLocator
           operatorConditionInViewPage = new ElementLocator(Locator.XPath, "//div[@class='operator ']/div/div/div");

        private readonly ElementLocator
           manageCommitteeHierarchyLabels = new ElementLocator(Locator.XPath, "//label[@class='titleLabel'][text()='{0}']");

        private readonly ElementLocator
            balanceRequiredYes = new ElementLocator(Locator.XPath, "//div[@class='titleInfo'][text()='{0}']");

        private readonly ElementLocator
            operatorbalanceRequired = new ElementLocator(Locator.XPath, "//div[@class='text'][text()='{0}']");

        private readonly ElementLocator
            memberClassificationTypeFirstSecond = new ElementLocator(Locator.XPath, "//label[contains(text(),'{0}')]");

        private readonly ElementLocator
            unlimitedRadioButton = new ElementLocator(Locator.XPath, "//input[@name='IsUnlimitedMembers' and @value='Unlimited']");

        private readonly ElementLocator
            limitedRadioButton = new ElementLocator(Locator.XPath, "//input[@name='IsUnlimitedMembers' and @value='Limited']");

        private readonly ElementLocator
            limitedandUnlimitedRadioLabel = new ElementLocator(Locator.XPath, "//label[text()='{0}']");

        private readonly ElementLocator
            tableColumns = new ElementLocator(Locator.XPath, "//table[@class='customTable CommitteeTable']//th[text()='{0}']");

        private string nmtextBoxforNumbers = "TextBox to Enter Members Permitted";
        private string nmradioButtonForLimitedMembers = "Max No Of Members Permitted Radio Button";
        private string nmselectDropdown = " Operator selection Dropdown";
        private string nmHierarchyUniqueLevelerrormessage = "Hierarchy Unique Level";
        private string nmmembershipTypeInBR = "Select Membership Type";
        private string nmbalanceRequiredForYesButton = "Radio button :Yes : For Balance Required";
        private string nmaddcommiteeTypesuccessfullmessage = "Committee Type added successfully.";
        private string nmaddCommitteeTypeTitleButton = "Add Committee Type button";
        private string nmcommitteeTypetext = "Committee Type Name";
        private string nmcmanageCommitteeHierarchytext = "Committee Hierarchy Add level";
        private string nmaddCommitteeTypeSaveButton = "Add New Committee Type Save button";
        private string nmaddlevelbutton = "Add Committee Hierarchy level button";
        private string nmcommitteTypeheader = "Committee Type header";
        private string nmmanageCommitteeHierarchyheader = "Committee Hierarchy header";
        private string nmmembershipTypeEligibleTojoinHeader = "Membership Type Eligible To Join header";
        private string nmbalanceRequiredHeader = "Balance Required header";
        private string nmenableCommitteeTypeonwebHeader = "Enable Committee Type On Web header";
        private string nmavailableMembershipTypesHeader = "Available Membership Types header";
        private string nmselectedMembershipTypesHeader = "Selected Membership Types Header";
        private string nmgetlatestRecord = "Latest Record:  {0} ,";
        private string nmEditcommiteeMembersButton = "Edit Commitee Type Name : {0}";
        private string nmEditButton = "Edit Button";
        private string nmTextParentClient = "1.";
        private string nmParentChildHierarchyLevelCloseButton = "Hierarchy Level Close Button";
        private string nmParentHierarchyLevelVisible = "Parent Hierarchy Level";
        private string nmAvailableMembershipTypes = "Available Membership Types";
        private string nmSelectedMembershipTypesText = "Selected Membership Types {0}";
        private string nmsortIconCommitteeType = "Committee Type Sort ICon";
        private string nmsortedIconOfCommitteeType = "Committee Type Sorted ICon";
        private string nmCommitteeTypelink = "Committee Type Name";
        private string nmenableCommitteeTypeonwebCheckBox = "Enable Commiteee Type on Web CheckBox";
        private string nmenableCommitteeTypeonwebEnableDiv = "Enable Commiteee Type on Web Div";
        private string nmsortIconBalanceRequired = "Balance Required Sort ICon";
        private string nmsortedIconOfBalanceRequired = "Balance Required Sorted ICon";
        private string nmBalanceRequiredlink = "Balance Required Name";
        private string nmsortIconPermittedMembers = "Permitted Members Sort ICon";
        private string nmsortedIconOfPermittedMembers = "Permitted Members Sorted ICon";
        private string nmPermittedMemberslink = "Permitted Members Name";
        private string nmbalanceRequiredYes = "Balance Required Yes Button";
        private string nmbalanceRequiredOperator = "Balance Required Operator";
        private string nmmemberClassificationTypeFirstSecond = "Balance Required Member Classification Type {0}";
        private string nmUnlimitedRadioButton = "Unlimited Radio Button";
        private string nmLimitedRadioButton = "Limited Radio Button";
        private string nmUnlimitedRadioLabel = "Unlimited Radio Button Label";
        private string nmLimitedRadioLabel = "Limited Radio Button Label";
        private string nmTableColumns = "Table Column: {0}";

        public ManageCommitteeTypesPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void CheckCommitteeTypeonwebEnablViewInfoDivLables(string lablename, int index)
        {
            this.Driver.WaitUntilElementIsFound(this.committeeTypeonwebEnablViewInfoDivLables.Format(lablename, index), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.committeeTypeonwebEnablViewInfoDivLables.Format(lablename, index), this.nmenableCommitteeTypeonwebEnableDiv + " Label Name :" + lablename);
        }

        public void CheckManageCommitteeHierarchyLabels(string lablename)
        {
            this.Driver.WaitUntilElementIsFound(this.manageCommitteeHierarchyLabels.Format(lablename), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.manageCommitteeHierarchyLabels.Format(lablename), this.nmenableCommitteeTypeonwebEnableDiv + " Label Name :" + lablename);
        }

        public void IsbalanceRequiredYesDisplayed(string searchText)
        {
            this.Driver.WaitUntilElementIsFound(this.balanceRequiredYes.Format(searchText), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.balanceRequiredYes.Format(searchText), string.Format(this.nmbalanceRequiredYes));
        }

        public void IsnmbalanceRequiredOperatorDisplayed(string searchText)
        {
            this.Driver.WaitUntilElementIsFound(this.operatorbalanceRequired.Format(searchText), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.operatorbalanceRequired.Format(searchText), this.nmbalanceRequiredOperator);
        }

        public void IsmemberClassificationTypeFirstSecond(string searchText)
        {
            this.Driver.WaitUntilElementIsFound(this.memberClassificationTypeFirstSecond.Format(searchText), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.memberClassificationTypeFirstSecond.Format(searchText), string.Format(this.nmmemberClassificationTypeFirstSecond, searchText));
        }

        public void IsUnlimitedLabelDisplayed(string header)
        {
            this.Driver.WaitUntilElementIsFound(this.limitedandUnlimitedRadioLabel.Format(header), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.limitedandUnlimitedRadioLabel.Format(header), this.nmUnlimitedRadioLabel);
        }

        public void IsLimitedLabelDisplayed(string header)
        {
            this.Driver.WaitUntilElementIsFound(this.limitedandUnlimitedRadioLabel.Format(header), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.limitedandUnlimitedRadioLabel.Format(header), this.nmLimitedRadioLabel);
        }

        public void IsUnlimitedAttributeDisplayed(string expected)
        {
            this.Driver.IsElementGivenAttributePresent(this.unlimitedRadioButton, this.nmUnlimitedRadioButton, "type", expected, "ReadOnly");
        }

        public void IsLimitedAttributeDisplayed(string expected)
        {
            this.Driver.IsElementGivenAttributePresent(this.limitedRadioButton, this.nmLimitedRadioButton, "type", expected, "ReadOnly");
        }

        public void AreListOfPermittedMembersElementsDisplayInAlphabeticalOrderOrNot()
        {
            this.Driver.AreElementsSortedInAlphabeticalOrder(this.permittedMembersLink, this.nmPermittedMemberslink);
        }

        public void IsTableColumnDisplayed(string column)
        {
            this.Driver.WaitUntilElementIsFound(this.tableColumns.Format(column), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.tableColumns.Format(column), string.Format(this.nmTableColumns, column));
        }

        public void IsPermittedMembersIConSortedSuccessfully()
        {
            this.Driver.WaitUntilElementIsFound(this.sortedIConForPermittedMembers, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.sortedIConForPermittedMembers, this.nmsortedIconOfPermittedMembers);
        }

        public void IsPermittedMembersUserAbleToClickOnSortIcon()
        {
            this.Driver.WaitUntilElementIsFound(this.sortIconOfPermittedMembers, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.sortIconOfPermittedMembers, this.nmsortIconPermittedMembers);
        }

        public void IsCommitteeTypeonwebEnablViewInfoDivClick(int index)
        {
            this.Driver.WaitUntilElementIsFound(this.enableCommitteeTypeonwebEnablViewInfoDiv.Format(index), BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.enableCommitteeTypeonwebEnablViewInfoDiv.Format(index), this.nmenableCommitteeTypeonwebEnableDiv);
        }

        public void AreListOfElementsDisplayInAlphabeticalOrderOrNot()
        {
            this.Driver.AreElementsSortedInAlphabeticalOrder(this.committeeTypeLink, this.nmCommitteeTypelink);
        }

        public void IsCommitteeTypeIConSortedSuccessfully()
        {
            this.Driver.WaitUntilElementIsFound(this.sortedIConForCommitteeType, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.sortedIConForCommitteeType, this.nmsortedIconOfCommitteeType);
        }

        public void IsCommitteeTypeUserAbleToClickOnSortIcon()
        {
            this.Driver.WaitUntilElementIsFound(this.sortIconOfCommitteeType, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.sortIconOfCommitteeType, this.nmsortIconCommitteeType);
        }

        public void AreBalanceRequiredListOfElementsDisplayInAlphabeticalOrderOrNot()
        {
            this.Driver.AreElementsSortedInAlphabeticalOrder(this.balanceRequiredLink, this.nmBalanceRequiredlink);
        }

        public void IsBalanceRequiredIConSortedSuccessfully()
        {
            this.Driver.WaitUntilElementIsFound(this.sortedIConForbalanceRequired, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.sortedIConForbalanceRequired, this.nmsortedIconOfBalanceRequired);
        }

        public void IsBalanceRequiredUserAbleToClickOnSortIcon()
        {
            this.Driver.WaitUntilElementIsFound(this.sortIconOfbalanceRequired, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.sortIconOfbalanceRequired, this.nmsortIconBalanceRequired);
        }

        public void DragEligibleToFrom()
        {
            this.Driver.DragDropFromLocatorToLocator(this.selectedelegibletoJOinFrom, this.selectedelegibletoJOinTo);
        }

        public void IsMembershipTypeEligibleItemDisplayed(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.selectedMembershipTypesText.Format(expected), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.selectedMembershipTypesText.Format(expected), string.Format(this.nmSelectedMembershipTypesText, expected));
        }

        public string IsAvailableMembershipTypesSelection()
        {
            var webElementLocator = this.Driver.GetElement(this.selectedelegibletoJOinEdit);
            string returnDragText = webElementLocator.Text.Trim();
            this.Driver.IsDragDropFromLocatorToLocator(this.selectedelegibletoJOinEdit, this.selectedelegibletoJOinTo, this.nmAvailableMembershipTypes);
            return returnDragText;
        }

        public void IsenableCommitteeTypeonwebCheckBoxClicked(string message)
        {
            this.Driver.IsElementVisible(this.enableCommitteeTypeonwebCheckBox.Format(message), this.nmenableCommitteeTypeonwebCheckBox);
            this.Driver.IsElementClickable(this.enableCommitteeTypeonwebCheckBox.Format(message), this.nmenableCommitteeTypeonwebCheckBox);
        }

        public void IsenableCommitteeTypeonwebCheckBoxDiv()
        {
            this.Driver.IsElementPresentOrNot(this.enableCommitteeTypeonwebEnableDiv, this.nmenableCommitteeTypeonwebEnableDiv, string.Empty);
        }

        public void IsManageCommitteeHierarchyHeaderDisplayed(string header)
        {
            this.Driver.IsElementVisible(this.manageCommitteeHierarchyHeader.Format(header), this.nmmanageCommitteeHierarchyheader);
            this.Driver.WaitUntilElementIsFound(this.manageCommitteeHierarchyHeader.Format(header), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.manageCommitteeHierarchyHeader.Format(header), this.nmmanageCommitteeHierarchyheader);
        }

        public void IsMembershipTypeEligibleTojoinHeaderDisplayed(string header)
        {
            this.Driver.WaitUntilElementIsFound(this.membershipTypeEligibleTojoinHeader.Format(header), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.membershipTypeEligibleTojoinHeader.Format(header), this.nmmembershipTypeEligibleTojoinHeader);
        }

        public void IsBalanceRequiredHeaderDisplayed(string header)
        {
            this.Driver.WaitUntilElementIsFound(this.balanceRequiredHeader.Format(header), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.balanceRequiredHeader.Format(header), this.nmbalanceRequiredHeader);
        }

        public void IsEnableCommitteeTypeonwebHeaderDisplayed(string header)
        {
            this.Driver.WaitUntilElementIsFound(this.enableCommitteeTypeonwebHeader.Format(header), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.enableCommitteeTypeonwebHeader.Format(header), this.nmenableCommitteeTypeonwebHeader);
        }

        public void ScrollToCommitteeNameElement()
        {
            this.Driver.PageScrollUpToTop();
        }

        public void IsEnableavailableMembershipTypesHeaderDisplayed(string header)
        {
            this.Driver.WaitUntilElementIsFound(this.availableMembershipTypesHeader.Format(header), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.availableMembershipTypesHeader.Format(header), this.nmavailableMembershipTypesHeader);
        }

        public void IsEnableselectedMembershipTypesHeaderDisplayed(string header)
        {
            this.Driver.WaitUntilElementIsFound(this.selectedMembershipTypesHeader.Format(header), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.selectedMembershipTypesHeader.Format(header), this.nmselectedMembershipTypesHeader);
        }

        public void IsManageCommitteTypeHeaderDisplayed(string header)
        {
            try
            {
                var text = this.Driver.GetText(this.committeTypeheader);
                this.Driver.IsElementVisible(this.committeTypeheader.Format(header), this.nmcommitteTypeheader);
                Verify.That(this.DriverContext, () => Assert.AreEqual(header, text), "Verifying Member Committe Type Title header displayed or not", "Member committee type header displayed", "Member Committe Type Displayed");
            }
            catch (Exception ex)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify Member committe type header not visible" + ex, "An exception occurred waiting for " + header + " to visible");
                Logger.Error("Failed to visible header value " + header);
                throw;
            }
        }

        public void IsAddCommitteeTypeButtonClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.addCommitteeTypeButton, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.addCommitteeTypeButton);
            this.Driver.IsElementVisible(this.addCommitteeTypeButton, this.nmaddCommitteeTypeTitleButton);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsNewCommitteeTypeaddedsuccessfullyDisplayed(string message)
        {
            this.Driver.IsElementVisible(this.successfullMsg, this.nmaddcommiteeTypesuccessfullmessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.successfullMsg, message, this.nmaddcommiteeTypesuccessfullmessage);
        }

        public void IsGetLatestRecordDisplayed(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.getLatestRecord.Format(expected), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.getLatestRecord.Format(expected), string.Format(this.nmgetlatestRecord, expected));
        }

        public void IsNewCommitteeTypeUniqueErrorMessageDisplayed(string expected)
        {
            string actual = this.Driver.GetText(this.errorMsgUnique);
            this.Driver.IsExpectedTextMatchWithActualText(this.errorMsgUnique, expected, actual);
        }

        public void IsNewCommitteeTypeNameErrorMessageDisplayed(string expected)
        {
            string actual = this.Driver.GetText(this.errorCommitteeTypeName.Format(expected));
            this.Driver.IsExpectedTextMatchWithActualText(this.errorCommitteeTypeName.Format(expected), expected, actual);
        }

        public void IsNewCommitteeTypeLevelErrorMessageDisplayed(string expected)
        {
            string actual = this.Driver.GetText(this.errorCommitteeTypeLevels.Format(expected));
            this.Driver.IsExpectedTextMatchWithActualText(this.errorCommitteeTypeLevels.Format(expected), expected, actual);
        }

        public void IsUserAbletoEnterCommitteeTypeInTextBox(string committeeTypeNameText)
        {
            this.Driver.IsElementVisible(this.committeeTypetext, this.nmcommitteeTypetext);
            this.Driver.EnterText(this.committeeTypetext, committeeTypeNameText, this.nmcommitteeTypetext);
        }

        public void IsLimitedPersonsSelectedAndEnterNumber(string num)
        {
            this.Driver.IsElementClickable(this.radioButtonForLimitedMembers, this.nmradioButtonForLimitedMembers);
            this.Driver.EnterText(this.textBoxforNumbers, num, this.nmtextBoxforNumbers);
        }

        public void IsLimitedPersonsSelected()
        {
            this.Driver.IsElementClickable(this.radioButtonForLimitedMembers, this.nmradioButtonForLimitedMembers);
        }

        public void ScrollToTopWebPage()
        {
            this.Driver.PageScrollUpToTop();
        }

        public void IsUserAbletoEnterCommitteeHierarcyInTextBox(string committeeHierarchyNameText)
        {
            this.Driver.IsElementVisible(this.manageCommitteeHierarchytext, this.nmcmanageCommitteeHierarchytext);
            this.Driver.EnterText(this.manageCommitteeHierarchytext, committeeHierarchyNameText, this.nmcmanageCommitteeHierarchytext);
        }

        public void IsLevelInputType()
        {
            this.Driver.IsElementVisible(this.manageCommitteeHierarchytext, this.nmcmanageCommitteeHierarchytext);
            this.Driver.IsElementGivenAttributePresent(this.manageCommitteeHierarchytext, this.nmcmanageCommitteeHierarchytext, "type", "text");
        }

        public void IsAddNewCommitteeTypeSaveButtonClickable()
        {
            this.Driver.IsElementVisible(this.addCommitteeTypesavebutton, this.nmaddCommitteeTypeSaveButton);
            this.Driver.IsElementClickable(this.addCommitteeTypesavebutton, this.nmaddCommitteeTypeSaveButton);
        }

        public void IserrorMsgDisplayedForIncorrectInput(string errorMessage)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.incorrectInput, errorMessage);
        }

        public void IserrorMsgDisplayedFormandatoryInput(string errorMessage)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.mandatoryInput, errorMessage);
        }

        public void IsAddLevelButtonClickable()
        {
            this.Driver.IsElementVisible(this.addLevel, this.nmaddlevelbutton);
            this.Driver.IsElementClickable(this.addLevel, this.nmaddlevelbutton);
        }

        public void IsEditNewCommitteeTypeClickable(string expected)
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.successfullMsg, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.getLatestRecord.Format(expected), string.Format(this.nmEditcommiteeMembersButton, expected));
            this.Driver.IsElementClickable(this.getLatestRecord.Format(expected), string.Format(this.nmEditcommiteeMembersButton, expected));
        }

        public void IsNewCommitteeTypeLinkDisplayedClickable(string expected)
        {
            this.Driver.IsElementVisible(this.getLatestRecord.Format(expected), string.Format(this.nmEditcommiteeMembersButton, expected));
            this.Driver.IsElementClickable(this.getLatestRecord.Format(expected), string.Format(this.nmEditcommiteeMembersButton, expected));
        }

        public void IsHierarchyUniqueLevelErrorDisplayed(string header)
        {
            this.Driver.WaitUntilElementIsFound(this.errorHierarchyUniqueLevel.Format(header), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.errorHierarchyUniqueLevel.Format(header), this.nmHierarchyUniqueLevelerrormessage);
        }

        public void IsCommitteeTypeTextAttributeDisplayed()
        {
            this.Driver.IsElementGivenAttributePresent(this.committeeTypetext, this.nmcommitteeTypetext, "type", "text");
        }

        public void IsCommitteeTypeTextBlankErrorMessageDisplayed(string expected)
        {
            this.Driver.EnterText(this.committeeTypetext, string.Empty, this.nmcommitteeTypetext);
            string actual = this.Driver.GetText(this.errorMessageBlankOnCommiteeType);
            this.Driver.IsExpectedTextMatchWithActualText(this.errorMessageBlankOnCommiteeType, expected, actual);
        }

        public void IsCommitteeTypeTextAlreadyExistsErrorMessageDisplayed(string expected)
        {
            string actual = this.Driver.GetText(this.errorMsgUnique);
            this.Driver.IsExpectedTextMatchWithActualText(this.errorMsgUnique, expected, actual);
        }

        public void IsEditButtonCommitteeTypeClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.editButton, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.editButton, this.nmEditButton);
            this.Driver.IsElementClickable(this.editButton, this.nmEditButton);
        }

        public void IsDefaultBalanceReqiuredSelectedAsNo()
        {
            try
            {
                this.Driver.PageScrollDownToBottom();
                var defaultValue = this.Driver.GetValue(this.balanceRequiredForNoButton);
                Verify.That(this.DriverContext, () => Assert.AreEqual("No", defaultValue), "Verifying whether default value selected for Balance Required is : NO :", "default value selected for Balance Required is : NO : ", "Default value selected for Balance Required is : Yes :");
            }
            catch (Exception)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify Default Balance Required button not visible", "An exception occurred waiting for Default Balance Required to selected as NO");
                Logger.Error("Failed to select Balance Required Radio button");
                throw;
            }
        }

        public void IsUserAbleToClickYesButtonForBalancerequired()
        {
            this.Driver.PageScrollDownToBottom();
            this.Driver.IsElementVisible(this.brlabel, this.nmaddlevelbutton);
            this.Driver.IsElementClickable(this.balanceRequiredForYesButton, this.nmbalanceRequiredForYesButton);
        }

        public void SelectMembershipTypefromFirstListInBalanceRequired()
        {
            this.Driver.WaitUntilElementIsFound(this.membershipTypeInBR2, BaseConfiguration.LongTimeout);
            this.Driver.ClickonSelectedElementfromList(this.membershipTypeInBR, this.nmmembershipTypeInBR, 1);
        }

        public void SelectMembershipTypefromSecondListInBalanceRequired()
        {
            this.Driver.WaitUntilElementIsFound(this.membershipTypeInBR2, BaseConfiguration.LongTimeout);
            this.Driver.ClickonSelectedElementfromList(this.membershipTypeInBR2, this.nmmembershipTypeInBR, 3);
        }

        public string GetTextSelectMembershipTypefromFirstListInBalanceRequired()
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.loadbutton, BaseConfiguration.LongTimeout);
            return this.Driver.GetTextForSelectedElementfromList(this.membershipTypeInBR, this.nmmembershipTypeInBR, 1);
        }

        public string GetTextSelectMembershipTypefromSecondListInBalanceRequired()
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.loadbutton, BaseConfiguration.LongTimeout);
            return this.Driver.GetTextForSelectedElementfromList(this.membershipTypeInBR2, this.nmmembershipTypeInBR, 3);
        }

        public void IsErrorMessageDisplayedForNotSelectingOperator(string message)
        {
            this.Driver.GetText(this.mandatoryFieldErrorMsg);
            this.Driver.IsExpectedTextMatchWithActualText(this.mandatoryFieldErrorMsg, message);
        }

        public void IsOperatorSelectable(string conditionName)
        {
            this.Driver.IsElementClickable(this.selectDropdownForOperator, this.nmselectDropdown);
            this.Driver.IsElementClickableFromListofElementWithText(this.operatorConditionSelection, conditionName);
        }

        public void IsOperatorFieldADropdown()
        {
            try
            {
                var webElement = this.Driver.GetElement(this.dropDownIconforOperator, BaseConfiguration.LongTimeout);
                webElement.GetAttribute("class").Contains("dropdown");
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Operator field is dropDown ", " Operator field is dropdown");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed  Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify Operator field is dropDown ", "An exception occurred while Verifying operator field ");
                throw;
            }
        }

        public void IsChildDisplayedafterParentLevel(string message, int hierarchyLevelNo)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.parentChildHierarchyLevel.Format(hierarchyLevelNo), this.GetStringHierarchyLevel(this.nmTextParentClient, hierarchyLevelNo) + message);
        }

        public void IsChildLevelDisplayed(string message, int hierarchyLevelNo, string pagename)
        {
            string hierarchyLevelChildText = this.GetStringHierarchyLevel(this.nmTextParentClient, hierarchyLevelNo, pagename) + message;
            this.Driver.IsElementPresentOrNot(this.parentChildHierarchyLevelDisplay.Format(hierarchyLevelChildText), this.nmParentHierarchyLevelVisible, hierarchyLevelChildText);
        }

        public void IsParentLevelDisplayed(string message, int hierarchyLevelNo, string pagename)
        {
            string hierarchyLevelParentText = this.GetStringHierarchyLevel(this.nmTextParentClient, hierarchyLevelNo, pagename) + message;
            this.Driver.IsElementPresentOrNot(this.parentChildHierarchyLevelDisplay.Format(hierarchyLevelParentText), this.nmParentHierarchyLevelVisible, hierarchyLevelParentText);
        }

        public void ParentClildHieracyCloseButton(int hierarchyLevelNo)
        {
            this.Driver.IsElementVisible(this.parentChildHierarchyLevelCloseButton.Format(hierarchyLevelNo), this.nmParentChildHierarchyLevelCloseButton);
            this.Driver.IsElementClickable(this.parentChildHierarchyLevelCloseButton.Format(hierarchyLevelNo), this.nmParentChildHierarchyLevelCloseButton);
        }

        public string GetStringHierarchyLevel(string text, int loop, string pagename = "")
        {
            string resultText = string.Empty;
            if (loop > 1)
            {
                for (int i = 1; i <= loop; i++)
                {
                    resultText += text;
                }

                resultText = resultText.Remove(resultText.Length - 1, 1);
                resultText = resultText + " ";
            }
            else
            {
                resultText = "1.0 ";
            }

            if (pagename == "Display")
            {
                resultText = resultText + " ";
            }

            return resultText;
        }

        public void IsOperatorConditionVisibleAsExpected(string condition)
        {
            bool value = this.Driver.IsElementPresent(this.balanceRuleInViewPage, BaseConfiguration.LongTimeout);
            Verify.That(this.DriverContext, () => Assert.IsTrue(value), "Verifying whether Set Balance Rule is : Visible :", "Set Balance Rule  is : Visible : ", "Set  Balance Rule is : Not Visible :");
            this.Driver.IsExpectedTextMatchWithActualText(this.operatorConditionInViewPage, condition);
        }
    }
}