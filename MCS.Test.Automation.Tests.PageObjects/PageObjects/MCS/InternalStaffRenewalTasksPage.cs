// <copyright file="InternalStaffRenewalTasksPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using global::MCS.Test.Automation.Common;
    using global::MCS.Test.Automation.Common.Extensions;
    using global::MCS.Test.Automation.Common.Types;
    using global::MCS.Test.Automation.Tests.PageObjects;
    using NLog;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using RelevantCodes.ExtentReports;

    public class InternalStaffRenewalTasksPage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator
            renewalTasksHeader = new ElementLocator(Locator.CssSelector, " div.headingTitle.clearfix > h2");

        private readonly ElementLocator
            addTasksBtn = new ElementLocator(Locator.XPath, "//*[text()=' Add Task']");

        private readonly ElementLocator
            addTasksPopupHeader = new ElementLocator(Locator.CssSelector, "div.header");

        private readonly ElementLocator
            titleTextBox = new ElementLocator(Locator.XPath, "//*[@name='Title']");

        private readonly ElementLocator
           renewalTaskYear = new ElementLocator(Locator.XPath, "(//div[@class='ui selection dropdown'])[2]");

        private readonly ElementLocator
            startDateSelection = new ElementLocator(Locator.XPath, "//*[@name='StartDate']");

        private readonly ElementLocator
            endDateSelection = new ElementLocator(Locator.XPath, "//*[@name='EndDate']");

        private readonly ElementLocator
          descriptionBox = new ElementLocator(Locator.CssSelector, "div.notranslate.public-DraftEditor-content");

        private readonly ElementLocator
         assigneeTextBox = new ElementLocator(Locator.XPath, "//*[@name='AssigneeId']/*[@type='text']");

        private readonly ElementLocator
        dependsOnTextBox = new ElementLocator(Locator.XPath, "//*[@name='NewDependsList']/*[@type='text']");

        private readonly ElementLocator
            textInsidedependsOnTextBox = new ElementLocator(Locator.XPath, "//*[@name='NewDependsList']/*[@class='ui label']");

        private readonly ElementLocator
         saveBtn = new ElementLocator(Locator.XPath, "//*[@type='submit']");

        private readonly ElementLocator
         renewalTaskName = new ElementLocator(Locator.XPath, "//div[@class='taskName ellip']/a");

        private readonly ElementLocator
         taskTitle = new ElementLocator(Locator.CssSelector, "div.taskTitle");

        private readonly ElementLocator
         editBtn = new ElementLocator(Locator.XPath, "//h4[text()='{0}']/a/i");

        private readonly ElementLocator
        taskId = new ElementLocator(Locator.CssSelector, "span.taskID");

        private readonly ElementLocator
        inactiveCheckBox = new ElementLocator(Locator.XPath, "//*[@type='checkbox']");

        private readonly ElementLocator
        reasonTextfield = new ElementLocator(Locator.XPath, "//*[@name='DeleteReason']");

        private readonly ElementLocator
        updateBtn = new ElementLocator(Locator.CssSelector, "i.check.icon");

        private readonly ElementLocator
           successfullMsg = new ElementLocator(Locator.CssSelector, "div.content > p");

        private readonly ElementLocator
            successmsg = new ElementLocator(Locator.CssSelector, "div.ui.compact.message.success div.content p");

        private readonly ElementLocator
       openTasksList = new ElementLocator(Locator.CssSelector, "div.taskName.ellip a");

        private readonly ElementLocator
            cards = new ElementLocator(Locator.CssSelector, "div.ui.card.taskCard.overdue");

        private readonly ElementLocator
            generalInfoEditbutton = new ElementLocator(Locator.XPath, "//*[text()='General Information']/a/i");

        private readonly ElementLocator
        closeBtn = new ElementLocator(Locator.XPath, "//h4[text()='{0}']//i[@class='close icon']");

        private readonly ElementLocator
         inactivestatusChkBoxText = new ElementLocator(Locator.XPath, "//*[text()='Inactive this Task']");

        private readonly ElementLocator
            inactiveDescTextBox = new ElementLocator(Locator.XPath, "//*[@name='DeleteReason']");

        private readonly ElementLocator
            updateBtnForInactiveTask = new ElementLocator(Locator.CssSelector, "i.check.icon");

        private readonly ElementLocator
            watcherslabel = new ElementLocator(Locator.CssSelector, "span.view-watchers");

        private readonly ElementLocator
            dependsOnAddButton = new ElementLocator(Locator.XPath, "//button[text()=' Add ']");

        private readonly ElementLocator
            dependencySearchBox = new ElementLocator(Locator.XPath, "//div[@name='DependsOnId']/input");

        private readonly ElementLocator
            dependenciesList = new ElementLocator(Locator.XPath, "//*[@class='visible menu transition']/div/span[contains(text(), '{0}')]");

        private readonly ElementLocator
            newlyaddedDependenciesTable = new ElementLocator(Locator.CssSelector, " th.membershipName");

        private readonly ElementLocator
           addButtonAfterDependenciesadded = new ElementLocator(Locator.XPath, "//*[@class='description']//*[@class='column actions']/button[text()='Add']");

        private readonly ElementLocator
            noDependenciesText = new ElementLocator(Locator.XPath, "//div[text()='Not depended on any Tasks.']");

        private readonly ElementLocator
           defaultRenewalYear = new ElementLocator(Locator.XPath, "//*[@class='ui label']");

        private readonly ElementLocator
           selectRenewalYear = new ElementLocator(Locator.XPath, "//*[@class='visible menu transition']/div/span");

        private readonly ElementLocator
           clickRenewalYearTextBox = new ElementLocator(Locator.XPath, "//*[@class='ui fluid multiple selection dropdown']");

        private readonly ElementLocator
           generalInfoCancelbutton = new ElementLocator(Locator.XPath, "//h4//button[@title='Cancel']");

        private readonly ElementLocator
          loadbutton = new ElementLocator(Locator.XPath, "//*[@class='ui active transition visible dimmer']");

        private readonly ElementLocator
           titleErrorMessage = new ElementLocator(Locator.XPath, "//span[contains(text(),'Title is required.')]");

        private readonly ElementLocator
           startDateErrorMessage = new ElementLocator(Locator.XPath, "//span[contains(text(),'Start Date is required')]");

        private readonly ElementLocator
           endDateErrorMessage = new ElementLocator(Locator.XPath, "//span[contains(text(),'End Date is required')]");

        private readonly ElementLocator
           inputStartDateErrorMessage = new ElementLocator(Locator.XPath, "//span[contains(text(),'Start Date is invalid')]");

        private readonly ElementLocator
           inputEndDateErrorMessage = new ElementLocator(Locator.XPath, "//span[contains(text(),'End Date is invalid')]");

        private readonly ElementLocator
            popupCloseBtn = new ElementLocator(Locator.XPath, "//i[@class='close']");

        private readonly ElementLocator
            upcomingTasksCount = new ElementLocator(Locator.XPath, "//*[starts-with(text(),'Upcoming')]/span");

        private readonly ElementLocator
            upcomingtasksListNo = new ElementLocator(Locator.XPath, "//*[@class='upcomingDv']//*[@class='taskName ellip']");

        private readonly ElementLocator
           openDvTasksCount = new ElementLocator(Locator.XPath, "//*[starts-with(text(),'Open')]/span");

        private readonly ElementLocator
            openDvtasksListNo = new ElementLocator(Locator.XPath, "//*[@class='openDv']//*[@class='taskName ellip']");

        private readonly ElementLocator
         doneDvTasksCount = new ElementLocator(Locator.XPath, "//*[starts-with(text(),'Done')]/span");

        private readonly ElementLocator
           doneDvtasksListNo = new ElementLocator(Locator.XPath, "//*[@class='doneDv']//*[@class='taskName ellip']");

        private readonly ElementLocator
            viewTaskId = new ElementLocator(Locator.XPath, "//span[text()='Task ID']");

        private readonly ElementLocator
            viewTitle = new ElementLocator(Locator.XPath, "//span[text()='Title']");

        private readonly ElementLocator
            viewStartDate = new ElementLocator(Locator.XPath, "//div[@class='column twoColInput']//span[text()='Start Date']");

        private readonly ElementLocator
            viewEndDate = new ElementLocator(Locator.XPath, "//div[@class='column twoColInput']//span[text()='End Date']");

        private readonly ElementLocator
            viewRenewalYear = new ElementLocator(Locator.XPath, "//div[@class='column twoColInput']//span[text()='Renewal Year']");

        private readonly ElementLocator
            viewDescription = new ElementLocator(Locator.XPath, "//span[text()='Description']");

        private readonly ElementLocator
            viewAssignee = new ElementLocator(Locator.XPath, "//div[@class='column twoColInput']//span[text()='Assignee']");

        private readonly ElementLocator
            viewStatus = new ElementLocator(Locator.XPath, "//div[@class='column twoColInput']//span[text()='Status']");

        private readonly ElementLocator
            viewRenewalTaskDetailsPage = new ElementLocator(Locator.CssSelector, "div.active.section");

        private readonly ElementLocator
           viewSortyBy = new ElementLocator(Locator.XPath, "//span[@id='Upcoming']");

        private readonly ElementLocator
           viewSortEndDate = new ElementLocator(Locator.XPath, "//li[contains(.,'End Date')]");

        private readonly ElementLocator
            viewIncomingTitle = new ElementLocator(Locator.XPath, "//a[contains(.,'{0}')]");

        private readonly ElementLocator
           viewOpenSortyBy = new ElementLocator(Locator.XPath, "//span[@id='Open']");

        private readonly ElementLocator
           viewOpenSortEndDate = new ElementLocator(Locator.XPath, "//li[contains(.,'End Date')]");

        private readonly ElementLocator
            viewOpenTitle = new ElementLocator(Locator.XPath, "//a[contains(.,'{0}')]");

        private readonly ElementLocator
            viewBannerTitle = new ElementLocator(Locator.XPath, "//div[@class='taskTitle'][contains(.,'{0})]");

        private readonly ElementLocator
            viewBannerStatus = new ElementLocator(Locator.XPath, "//div[@class='taskStatus false']");

        private readonly ElementLocator
            viewBannerTaskID = new ElementLocator(Locator.XPath, "//span[contains(@class,'taskID')]");

        private readonly ElementLocator
            viewBannerRenewalYear = new ElementLocator(Locator.XPath, "//div[contains(@class,'taskYear')]");

        private readonly ElementLocator
            viewBannerAssignee = new ElementLocator(Locator.XPath, "(//a[@class='banner-link'])[2]");

        private readonly ElementLocator
            viewBannerTaskOwner = new ElementLocator(Locator.XPath, "(//a[@class='banner-link'])[1]");

        private readonly ElementLocator
           viewBannerWatchersCount = new ElementLocator(Locator.XPath, "//span[@class='watch-counter']");

        private readonly ElementLocator
           viewBannerDateTimeStamp = new ElementLocator(Locator.XPath, "//div[@class='updatedByInfo']");

        private readonly ElementLocator
          viewBannerStartWatcherIssue = new ElementLocator(Locator.XPath, "//*[@class='actionItem']/ul/li[3]/i");

        private readonly ElementLocator
          viewBannerSetReminder = new ElementLocator(Locator.XPath, "//*[@class='actionItem']/ul/li[1]/i");

        private readonly ElementLocator
          viewBannerCloneIssue = new ElementLocator(Locator.XPath, "//*[@class='actionItem']/ul/li[2]/i");

        private readonly ElementLocator
        communicationsTab = new ElementLocator(Locator.XPath, "//a[text()='Communication Log']");

        private readonly ElementLocator
            commentTextBox = new ElementLocator(Locator.CssSelector, "div.commentposteditor");

        private readonly ElementLocator
           submitBtn = new ElementLocator(Locator.XPath, "//button[text()='Submit']");

        private readonly ElementLocator
          usernameOfComment = new ElementLocator(Locator.XPath, "//div[@class='comment']//span[@class='edit-delete']");

        private readonly ElementLocator
        deleteCommentIcon = new ElementLocator(Locator.XPath, "//*[@class='edit-delete']//i[@class='delete icon']");

        private readonly ElementLocator
            deleteCommentPopupWindow = new ElementLocator(Locator.XPath, "//*[@class='ui small modal transition visible active confirm-box']//div[@class='content']");

        private readonly ElementLocator
       deleteYesButton = new ElementLocator(Locator.XPath, "//*[@class='ui primary button']");

        private readonly ElementLocator
               searchBarforRenewalTask = new ElementLocator(Locator.XPath, "//div[@class='ui input searchInput']/input");

        private readonly ElementLocator
            searchIconforTasks = new ElementLocator(Locator.XPath, "//*[@class='ui button primary']/i");

        private readonly ElementLocator
           renewalTaskCardName = new ElementLocator(Locator.XPath, "//div[@class='taskName ellip']/a[text()='{0}']");

        private readonly ElementLocator
         renewalTaskSearchBox = new ElementLocator(Locator.XPath, " //div[@role='alert']/following::input[1]");

        private readonly ElementLocator
        searchBtnIcon = new ElementLocator(Locator.CssSelector, "i.search.icon");

        private readonly ElementLocator
                systemGeneratedRenewalTaskID = new ElementLocator(Locator.XPath, "//p[@class='taskID']/a[1]");

        private readonly ElementLocator
           renewalTaskSelection = new ElementLocator(Locator.XPath, "//div[@class='text'][contains(text(),'Renewal Tasks')]");

        private readonly ElementLocator
          renewalSearchHint = new ElementLocator(Locator.XPath, "//input[contains(@title,'{0}')]");

        private readonly ElementLocator
          renewalSearchInput = new ElementLocator(Locator.XPath, "//input[@placeholder='Search Task by Task ID, Title, Assignee']");

        private readonly ElementLocator
         renewalSearch = new ElementLocator(Locator.XPath, "//i[@class='search icon']");

        private readonly ElementLocator
        searchfeatureDropdownIcon = new ElementLocator(Locator.XPath, "//*[@class='ui compact selection dropdown']/i");

        private readonly ElementLocator
        searchfeatureDropdownList = new ElementLocator(Locator.XPath, "//*[@class='visible menu transition']/div");

        private readonly ElementLocator
            dependencyTaskInfo = new ElementLocator(Locator.XPath, "//td/a[text()='{0}']");

        private readonly ElementLocator
            dependantTasksColumn = new ElementLocator(Locator.XPath, "//h4[text()='Dependent Tasks']/../../..//th[text()='{0}']");

        private readonly ElementLocator
        renewalDependentCombo = new ElementLocator(Locator.XPath, "//div[contains(@name,'NewDependsList')]");

        private readonly ElementLocator
         renewalDependentInput = new ElementLocator(Locator.XPath, "//div[@name='NewDependsList']//input[@class='search']");

        private readonly ElementLocator
        renewalDependentSort = new ElementLocator(Locator.XPath, "(//td[@class='Name'])[1]");

        private readonly ElementLocator
        renewalDependentSelection = new ElementLocator(Locator.XPath, "(//span[contains(@class,'text')])[34]");

        private readonly ElementLocator
            dependsOnassigneeNameToRedirect = new ElementLocator(Locator.XPath, "//table[@class='customTable']//td/a[text()='{0}']");

        private readonly ElementLocator
            bannerUserName = new ElementLocator(Locator.XPath, "//span[text()='Username']/following-sibling :: span[text()='{0}']");

        private readonly ElementLocator
          renewalTaskHeaders = new ElementLocator(Locator.XPath, "//div[@class='taskCount' and contains(text(),'{0}')]");

        private readonly ElementLocator
           assigneeRenewalTask = new ElementLocator(Locator.XPath, "//a[contains(@title,'Assignee')]");

        private readonly ElementLocator
          yearDateRenewalTask = new ElementLocator(Locator.XPath, "//span[contains(@class,'yearDate')]");

        private readonly ElementLocator
          startDateRenewalTask = new ElementLocator(Locator.XPath, "//span[contains(@title,'Start Date')]");

        private readonly ElementLocator
          endDateRenewalTask = new ElementLocator(Locator.XPath, "//span[contains(@title,'End Date')]");

        private readonly ElementLocator
          taskIDRenewalTask = new ElementLocator(Locator.XPath, "//p[@class='taskID']//a");

        private readonly ElementLocator
          clockIconRenewalTask = new ElementLocator(Locator.XPath, "//i[contains(@class,'clock outline icon')]");

        private readonly ElementLocator
          copyIconRenewalTask = new ElementLocator(Locator.XPath, "//i[@class='copy outline icon']");

        private readonly ElementLocator
          eyeIconRenewalTask = new ElementLocator(Locator.XPath, "//i[@class='eye icon']");

        private readonly ElementLocator
            watcherEyeIcon = new ElementLocator(Locator.XPath, "//i[@class='eye slash icon']");

        private readonly ElementLocator
            noWatchersText = new ElementLocator(Locator.XPath, "//span[text()='No watchers to display.']");

        private readonly ElementLocator
         dragToOpen = new ElementLocator(Locator.XPath, "//div[@class='openDv']");

        private readonly ElementLocator
         dragfromUpComing = new ElementLocator(Locator.XPath, "//p[@class='taskID']//a");

        private readonly ElementLocator
         dragfromUpComingIndexWise = new ElementLocator(Locator.XPath, "//div[@class='upcomingDv']//div[@class='cardCell'][{0}]//p[@class='taskID']//a[1]");

        private string nmassigneeRenewalTask = "Assignee";
        private string nmyearDateRenewalTask = "Year Date";
        private string nmstartDateRenewalTask = "Start Date";
        private string nmendDateRenewalTask = "End Date";
        private string nmtaskIDRenewalTask = "Task ID";
        private string nmclockIconRenewalTask = "Clock Icon";
        private string nmcopyIconRenewalTask = "Copy Icon";
        private string nmeyeIconRenewalTask = "Eye Icon";
        private string nmRenewalTaskHeaders = "Renewal Header : {0}";
        private string nmdependantTasksColumn = "Task column displayed in dependant Task";
        private string nmdependenciesList = "Task displayed in dependencies List";
        private string nmdependencySearchBox = "Search Box to add dependencies";
        private string nmdeleteCommentIcon = "Delete icon for Comment";
        private string nmusernameOfComment = "User name of Comment";
        private string nmclickRenewalYearTextBox = "click RenewalYear TextBox";
        private string nmselectRenewalYear = "Selecting Renewal Year";
        private string nmNoDependenciesText = "Text to validate if No Dependencies";
        private string nmnewlyaddedDependenciesTable = "Dependency list after dependants are Added";
        private string nmaddButtonAfterDependenciesadded = "Add button in  dependencies Popup Window";
        private string nminactiveDescTextBox = "TextBox to enter Reason for Making Task as Inactive";
        private string nminactivestatusChkBox = "Inactive CheckBox";
        private string nmrenewalTasksHeader = "Renewal Tasks Header";
        private string nmaddTasksBtn = "Add Tasks Button";
        private string nmaddTasksPopupHeader = "Add Tasks Window Header";
        private string nmtitleTextBox = "Title Name text field";
        private string nmrenewalTaskYear = "Renewal Task Yearfield";
        private string nmstartDateSelection = "Start Date";
        private string nmendDateSelection = "End Date";
        private string nmdescriptionBox = "Description Text Area";
        private string nmassigneeTextBox = "Assignee Field";
        private string nmdependsOnTextBox = "Depends On Field";
        private string nmsaveBtn = "Save Button";
        private string nmrenewalTaskName = "Name of Renewal Task";
        private string nmtaskTitle = "Task Title";
        private string nmtaskId = "Task Id";
        private string nmeditBtn = "Edit Button";
        private string nmreasonTextfield = "Inactive CheckBox Text Field";
        private string nmupdateBtn = "Update Button";
        private string nmsuccessfullmessage = "Record created successfully.";
        private string nmpopupcloseBtn = "Popup Closed Button";
        private string nmaddSortByBtn = "Sort By Button";
        private string nmaddSortEndDateBtn = "End Date Button";
        private string nmaRenewalTitleBtn = "Renewal Title Link";
        private string nmBannerStatus = "Banner Status";
        private string nmBannerTaskID = "Banner TaskId";
        private string nmBannerRenewalYear = "Banner Renewal Year";
        private string nmBannerAssignee = "Banner Assignee";
        private string nmBannerTaskOwner = "Banner Task Owner";
        private string nmBannerWatchersCount = "Banner Watchers Count";
        private string nmBannerDateTimeStampCount = "Banner DateTime Stamp";
        private string nmBannerStartWachingIssue = "Banner - Start Watching this Issue";
        private string nmBannerStopWachingIssue = "Banner - Stop Watching this Issue";
        private string nmStartWachingIssueClass = "eye icon";
        private string nmStopWachingIssueClass = "eye slash icon";
        private string nmStartWachingErrorMessage = "Watching Issue Class";
        private string nmRenewalTaskSearchBox = "Renewal Task Search Box";
        private string nmSearchIcon = "Search Icon";
        private string nmsystemGeneratedRenewalTaskID = "system Generated Renewal Task ID";

        private string nmBannerSetReminder = "Banner - Set Reminder";
        private string nmSetReminderClass = "clock outline icon";
        private string nmSetReminderErrorMessage = "Set Reminder Class";

        private string nmBannerCloneTask = "Banner - Clone Task";
        private string nmCloneTaskClass = "copy outline icon";
        private string nmCloneTaskErrorMessage = "Clone Task Class";
        private string nmrenewalSearchHint = "Renewal Task Hint Text (Search Task by Task ID, Title, Assignee)";
        private string nmrenewalSearchTask = "Renewal Task Search";
        private string nmrenewalSearchTaskBtn = "Renewal Task Search Button";
        private string nmaddrenewalDependent = "Renewal Task Dependent";
        private string nmwatcherEyeIcon = "Watcher Eye Icon";
        private string nmnoWatchersText = "No watchers to display";
        private string nmViewWatchersPopup = "View Watchers Popup";
        private string nmViewWatchers = "View Watchers";

        // private string nmeditrenewalDependent = "Edit Renewal Dependent";
        private string nmrenewalDependentSelection = "Renewal Task Select";
        private string nmSeachUpcomingBoxIndex = "Renewal Task Card Index : {0}";

        public InternalStaffRenewalTasksPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void IsUserableToEnterTitleInSearchBoxClear()
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.successmsg, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.renewalSearchInput, this.nmrenewalSearchTask);
            this.Driver.EnterText(this.renewalSearchInput, "  ", this.nmrenewalSearchTask);
        }

        public string DragEligibleUpComingIndexWise(int firstIndex, int secondIndex)
        {
            this.Driver.WaitUntilElementIsFound(this.dragfromUpComingIndexWise.Format(firstIndex), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.dragfromUpComingIndexWise.Format(firstIndex), string.Format(this.nmSeachUpcomingBoxIndex, firstIndex));
            string text = this.Driver.GetText(this.dragfromUpComingIndexWise.Format(firstIndex));
            this.Driver.DragDropFromLocatorToLocator(this.dragfromUpComingIndexWise.Format(firstIndex), this.dragfromUpComingIndexWise.Format(secondIndex));
            return text;
        }

        public void ValidateRenewalTaskFirstRecordCardName(string expected, int firstIndex)
        {
            this.Driver.WaitUntilElementIsFound(this.dragfromUpComingIndexWise.Format(firstIndex), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.dragfromUpComingIndexWise.Format(firstIndex), string.Format(this.nmSeachUpcomingBoxIndex, firstIndex));
            this.Driver.IsExpectedTextMatchWithActualText(this.dragfromUpComingIndexWise.Format(firstIndex), expected);
        }

        public void DragEligibleToOpenFromUpComing()
        {
            this.Driver.DragDropFromLocatorToLocator(this.dragfromUpComing, this.dragToOpen);
        }

        public void IsAssigneeRenewalTaskVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.assigneeRenewalTask, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.assigneeRenewalTask, this.nmassigneeRenewalTask);
        }

        public void IsYearDateRenewalTaskVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.yearDateRenewalTask, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.yearDateRenewalTask, this.nmyearDateRenewalTask);
        }

        public void IsStartDateRenewalTaskVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.startDateRenewalTask, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.startDateRenewalTask, this.nmstartDateRenewalTask);
        }

        public void IsEndDateRenewalTaskVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.endDateRenewalTask, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.endDateRenewalTask, this.nmendDateRenewalTask);
        }

        public void IsTaskIDRenewalTaskVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.taskIDRenewalTask, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.taskIDRenewalTask, this.nmtaskIDRenewalTask);
        }

        public void IsClockIconRenewalTaskVisible()
        {
            this.Driver.IsElementPresentOrNot(this.clockIconRenewalTask, this.nmclockIconRenewalTask, string.Empty);
        }

        public void IsCopyIconRenewalTaskVisible()
        {
            this.Driver.IsElementPresentOrNot(this.copyIconRenewalTask, this.nmcopyIconRenewalTask, string.Empty);
        }

        public void IsEyeIconRenewalTaskVisible()
        {
            this.Driver.IsElementPresentOrNot(this.eyeIconRenewalTask, this.nmeyeIconRenewalTask, string.Empty);
        }

        public void IsRenewalHeaderDisplayed(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.renewalTaskHeaders.Format(expected), BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.renewalTaskHeaders.Format(expected), string.Format(this.nmRenewalTaskHeaders, expected));
        }

        public void IsRenewalTasksHeaderVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.renewalTasksHeader, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.renewalTasksHeader, this.nmrenewalTasksHeader);
        }

        public void IsAddTasksBtnClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.renewalTasksHeader, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.addTasksBtn, this.nmaddTasksBtn);
            this.Driver.IsElementClickable(this.addTasksBtn, this.nmaddTasksBtn);
        }

        public void IsAddTasksPopupVisible()
        {
            this.Driver.WaitForPageLoad();
            this.Driver.IsElementVisible(this.addTasksPopupHeader, this.nmaddTasksPopupHeader);
        }

        public string IsUserableToEnterTitle(string text)
        {
            this.Driver.WaitUntilElementIsFound(this.titleTextBox, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.titleTextBox, this.nmtitleTextBox);
            this.Driver.EnterText(this.titleTextBox, text, this.nmtitleTextBox);
            this.Driver.WaitUntilElementIsFound(this.titleTextBox, BaseConfiguration.LongTimeout);
            string titleText = this.Driver.GetValue(this.titleTextBox);
            return titleText;
        }

        public string IsUserableToEnterTitleInSearchBox(string text)
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.successmsg, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.renewalSearchInput, this.nmrenewalSearchTask);
            this.Driver.EnterText(this.renewalSearchInput, text, this.nmrenewalSearchTask);
            this.Driver.WaitUntilElementIsFound(this.renewalSearchInput, BaseConfiguration.LongTimeout);
            string titleText = this.Driver.GetValue(this.renewalSearchInput);
            return titleText;
        }

        public void IsUserableToSelectRenewalYear(string value)
        {
            this.Driver.IsElementVisible(this.renewalTaskYear, this.nmrenewalTaskYear);
            this.Driver.SelectByValue(this.renewalTaskYear, value);
        }

        public string IsUserAbleToSelectStartDate(string date)
        {
            this.Driver.IsElementVisible(this.startDateSelection, this.nmstartDateSelection);
            this.Driver.IsElementClickable(this.startDateSelection, this.nmstartDateSelection);
            var webelement = this.Driver.GetElement(this.startDateSelection, BaseConfiguration.LongTimeout);
            for (int i = 0; i <= 10; i++)
            {
                webelement.SendKeys(Keys.Backspace);
            }

            this.Driver.EnterText(this.startDateSelection, date, this.nmstartDateSelection);
            this.Driver.WaitUntilElementIsFound(this.startDateSelection, BaseConfiguration.LongTimeout);
            string startDate = this.Driver.GetValue(this.startDateSelection);
            return startDate.Replace('/', '-');
        }

        public string IsUserAbleToSelectEndDate(string date)
        {
            this.Driver.IsElementVisible(this.endDateSelection, this.nmendDateSelection);
            this.Driver.IsElementClickable(this.endDateSelection, this.nmendDateSelection);
            var webelement = this.Driver.GetElement(this.endDateSelection, BaseConfiguration.LongTimeout);
            for (int i = 0; i <= 10; i++)
            {
                webelement.SendKeys(Keys.Backspace);
            }

            this.Driver.EnterText(this.endDateSelection, date, this.nmendDateSelection);
            this.Driver.WaitUntilElementIsFound(this.endDateSelection, BaseConfiguration.LongTimeout);
            string endDate = this.Driver.GetValue(this.endDateSelection);
            return endDate.Replace('/', '-');
        }

        public string IsUserAbleToEnterTextInDescription(string text)
        {
            this.Driver.IsElementVisible(this.descriptionBox, this.nmdescriptionBox);
            this.Driver.EnterText(this.descriptionBox, text, this.nmdescriptionBox);
            this.Driver.WaitUntilElementIsFound(this.descriptionBox, BaseConfiguration.LongTimeout);
            string descriptionText = this.Driver.GetValue(this.descriptionBox);
            return descriptionText;
        }

        public string IsSystemGeneratedUniqueTaskID()
        {
            this.Driver.IsElementVisible(this.systemGeneratedRenewalTaskID, this.nmsystemGeneratedRenewalTaskID);
            var uniqueTaskID = this.Driver.GetText(this.systemGeneratedRenewalTaskID);
            return uniqueTaskID;
        }

        public void IsEnterTextInRenewalTaskSearchBoxAndClickSearchIcon(string title)
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.successmsg, BaseConfiguration.LongTimeout);
            this.Driver.WaitUntilElementIsFound(this.renewalTaskSearchBox, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.renewalTaskSearchBox);
            this.Driver.PageScrollUpToTop();
            this.Driver.WaitUntilElementIsFound(this.renewalTaskSearchBox, BaseConfiguration.LongTimeout);
            this.Driver.EnterText(this.renewalTaskSearchBox, title, this.nmRenewalTaskSearchBox);
            this.Driver.IsElementVisible(this.searchBtnIcon, this.nmSearchIcon);
            this.Driver.IsElementClickable(this.searchBtnIcon, this.nmSearchIcon);
        }

        public string IsUserAbleToEnterAssigneeName(string text)
        {
            this.Driver.IsElementVisible(this.assigneeTextBox, this.nmassigneeTextBox);
            var webelement = this.Driver.GetElement(this.assigneeTextBox, BaseConfiguration.LongTimeout);
            this.Driver.JavaScriptClick(webelement);
            this.Driver.EnterText(this.assigneeTextBox, text, this.nmassigneeTextBox);
            this.Driver.WaitUntilElementIsFound(this.assigneeTextBox, BaseConfiguration.LongTimeout);
            string assigneeText = this.Driver.GetValue(this.assigneeTextBox);
            return assigneeText;
        }

        public string IsUserAbleToEnterDependsOnTask(string dependsTask)
        {
            this.Driver.IsElementVisible(this.dependsOnTextBox, this.nmdependsOnTextBox);
            var webelement = this.Driver.GetElement(this.dependsOnTextBox, BaseConfiguration.LongTimeout);
            this.Driver.JavaScriptClick(webelement);
            this.Driver.EnterText(this.dependsOnTextBox, dependsTask, this.nmdependsOnTextBox);
            this.Driver.IsElementClickable(this.dependenciesList.Format(dependsTask), this.nmdependenciesList);
            this.Driver.WaitUntilElementIsFound(this.textInsidedependsOnTextBox, BaseConfiguration.LongTimeout);
            string dependsOnText = this.Driver.GetText(this.textInsidedependsOnTextBox);
            return dependsOnText;
        }

        public void IsUserableToSaveTask()
        {
            this.Driver.IsElementVisible(this.saveBtn, this.nmsaveBtn);
            this.Driver.IsElementClickable(this.saveBtn, this.nmsaveBtn);
        }

        public void IsUserableToSlectTasksForEditFromList(int i)
        {
            this.Driver.IsElementVisibleFromListOfElement(this.renewalTaskName, this.nmrenewalTaskName);
            this.Driver.ClickonSelectedElementfromList(this.renewalTaskName, this.nmrenewalTaskName, i);
        }

        public string IsTaskTitleVisible()
        {
            this.Driver.WaitForPageLoad();
            this.Driver.IsElementVisible(this.taskTitle, this.nmtaskTitle);
            var title = this.Driver.GetText(this.taskTitle);
            return title;
        }

        public string IsUserableToGetTaskId()
        {
            this.Driver.IsElementVisible(this.taskId, this.nmtaskId);
            var taskIdNo = this.Driver.GetText(this.taskId);
            return taskIdNo;
        }

        public void IsEditButtonClickable(string name = "General Information")
        {
            this.Driver.IsElementVisible(this.editBtn.Format(name), this.nmeditBtn);
            this.Driver.IsElementClickable(this.editBtn.Format(name), this.nmeditBtn);
        }

        public void IsInactiveCheckBoxVisible(string text)
        {
            try
            {
                bool chkBoxStatus = this.Driver.IsCheckBoxChecked(this.inactiveCheckBox);
                if (chkBoxStatus)
                {
                    this.Driver.SelectCheckBoxifUnselected(this.inactiveCheckBox);
                    this.Driver.EnterText(this.reasonTextfield, text, this.nmreasonTextfield);
                }

                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify CheckBox Status is Unselected and then Select CheckBox ", " CheckBox is clicked successfully");
                Logger.Info(" is clicked successfully");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed  Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify if CheckBox Status is Selected ", "An exception occurred while Verifying Status Of CheckBox ");
                throw;
            }
        }

        public void IsUserableToClickUpdateBtn()
        {
            this.Driver.IsElementVisible(this.updateBtn, this.nmupdateBtn);
            this.Driver.IsElementClickable(this.updateBtn, this.nmupdateBtn);
        }

        public void IsTaskRecordUpdatedSuccessfully(string updateSuccessmessage)
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.successfullMsg, this.nmsuccessfullmessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.successfullMsg, updateSuccessmessage, this.nmsuccessfullmessage);
        }

        public void IsSuccessMessageDisplayed(string updateSuccessmessage)
        {
            this.Driver.WaitUntilElementIsFound(this.successmsg, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.successmsg, this.nmsuccessfullmessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.successmsg, updateSuccessmessage, this.nmsuccessfullmessage);
            this.Driver.Navigate().Refresh();
        }

        public void IsUserableToSelectTaskCard()
        {
            this.Driver.WaitForPageLoad();
            this.Driver.WaitUntilElementIsFound(this.openTasksList, BaseConfiguration.LongTimeout);
            IList<IWebElement> items = this.Driver.GetElements(this.openTasksList);
            items.First().Click();
        }

        public void IsGeneralInfoEditButtonClickable()
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.loadbutton, BaseConfiguration.LongTimeout);
            this.Driver.WaitUntilElementIsFound(this.generalInfoEditbutton, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.generalInfoEditbutton);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsGeneralInfoCancelButtonClickable()
        {
            this.Driver.WaitForPageLoad();
            this.Driver.WaitUntilElementIsFound(this.generalInfoCancelbutton, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.generalInfoCancelbutton);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsInactiveCheckBoxClickable()
        {
            this.Driver.IsElementVisible(this.inactivestatusChkBoxText, this.nminactivestatusChkBox);
            this.Driver.MouseOverOnWebElement(this.inactivestatusChkBoxText, "Inactive this Task");
            var webElement = this.Driver.GetElement(this.inactivestatusChkBoxText);
            this.Driver.JavaScriptClick(webElement);
         }

        public void IsInactiveCheckBoxVisible()
        {
            this.Driver.IsElementTextDisplayed(this.inactivestatusChkBoxText, "Inactive this Task");
        }

        public void IsCloseButtonClickable(string name = "General Information")
        {
            this.Driver.WaitUntilElementIsFound(this.closeBtn.Format(name), BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.closeBtn.Format(name));
            this.Driver.JavaScriptClick(webElement);
        }

        public void EnterTextInInactiveDescriptionBox(string text)
        {
            this.Driver.EnterText(this.inactiveDescTextBox, text, this.nminactiveDescTextBox);
        }

        public void IsupdateBtnClickableforInactiveTask()
        {
            this.Driver.WaitUntilElementIsFound(this.updateBtnForInactiveTask, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.updateBtnForInactiveTask);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsWatchersDetailsVisible()
        {
            this.Driver.IsElementTextDisplayed(this.watcherslabel, this.nmViewWatchers);
        }

        public void IsViewWatchersPopupClickable()
        {
            this.Driver.IsElementClickable(this.watcherslabel, this.nmViewWatchersPopup);
        }

        public void IsWatcherEyeIconClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.watcherEyeIcon, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.watcherEyeIcon, this.nmwatcherEyeIcon);
        }

        public void IsDependsOnAddButtonClickable()
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.loadbutton, BaseConfiguration.LongTimeout);
            this.Driver.WaitUntilElementIsFound(this.dependsOnAddButton, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.dependsOnAddButton);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsDependencySearchBoxClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.dependencySearchBox, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.dependencySearchBox);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsDependenciesSelectablefromList(string name)
        {
            this.Driver.WaitUntilElementIsFound(this.dependencySearchBox, BaseConfiguration.LongTimeout);
            this.Driver.EnterText(this.dependencySearchBox, name, this.nmdependencySearchBox);
            this.Driver.IsElementClickable(this.dependenciesList.Format(name), this.nmdependenciesList);
        }

        public void IsAddButtonClickableInADDDependenciesPopupWindow()
        {
            this.Driver.IsElementClickable(this.addButtonAfterDependenciesadded, this.nmaddButtonAfterDependenciesadded);
        }

        public void IsAddedDependenciesvisible()
        {
            bool value = this.Driver.IsElementVisibleWithSoftAssertion(this.newlyaddedDependenciesTable, this.nmnewlyaddedDependenciesTable);
            Assert.IsTrue(value);
        }

        public void IsDependenciesNOTVisible()
        {
            try
            {
                bool value = this.Driver.IsElementVisibleWithSoftAssertion(this.noDependenciesText, this.nmNoDependenciesText);
                Assert.IsTrue(value);

                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Dependencies options Visible ", " Dependencies option is Not visible successfully");
                Logger.Info("Dependencies not visible successfully");
        }
            catch (Exception ex)
            {
                Logger.Error("Failed  Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify if Dependencies options is visible", "An exception occurred while Verifying Dependencies visible");
                throw;
            }
}

        public string IsUserableToaddNewTask(string title, string date, string descText, string assigneeName, string dependsOn = "")
        {
            this.Driver.WaitForPageLoad();
            string taskid = string.Empty;
            this.IsAddTasksBtnClickable();
            this.IsUserableToEnterTitle(title);
            this.IsUserAbleToSelectStartDate(date);
            this.IsUserAbleToSelectEndDate(date);
            this.IsUserAbleToEnterTextInDescription(descText);
            this.IsUserAbleToEnterAssigneeName(assigneeName);
            if (dependsOn != string.Empty)
            {
                taskid = this.IsUserAbleToEnterDependsOnTask(dependsOn);
            }

            this.IsUserableToSaveTask();
            return taskid;
        }

        public void IsDefaultRenewalYearDisplayed()
        {
            var text = this.Driver.GetText(this.defaultRenewalYear);
            Assert.IsNotNull(text);
        }

        public void IsRenewalDropDownClickable()
        {
            this.Driver.IsElementClickable(this.clickRenewalYearTextBox, this.nmclickRenewalYearTextBox);
            IList<IWebElement> lstElements = this.Driver.GetElements(this.selectRenewalYear);
            int countOfYears = lstElements.Count;
            Assert.That(countOfYears, Is.GreaterThanOrEqualTo(1));
        }

        public void SelectYearfromList()
        {
            this.Driver.IsElementClickable(this.selectRenewalYear, this.nmselectRenewalYear);
        }

        public void IsTitleErrorMessageDisplayed(string expected)
        {
            this.IsErrorMessageDisplayed(expected, this.titleErrorMessage);
        }

        public void IsEndDateErrorMessageDisplayed(string expected)
        {
            this.IsErrorMessageDisplayed(expected, this.endDateErrorMessage);
        }

        public void IsStartDateErrorMessageDisplayed(string expected)
        {
            this.IsErrorMessageDisplayed(expected, this.startDateErrorMessage);
        }

        public void IsInputEndDateErrorMessageDisplayed(string expected)
        {
            this.IsErrorMessageDisplayed(expected, this.inputEndDateErrorMessage);
        }

        public void IsInputStartDateErrorMessageDisplayed(string expected)
        {
            this.IsErrorMessageDisplayed(expected, this.inputStartDateErrorMessage);
        }

        public void IsUserableToPopUpCloseTask()
        {
            this.Driver.IsElementVisible(this.popupCloseBtn, this.nmpopupcloseBtn);
            this.Driver.IsElementClickable(this.popupCloseBtn, this.nmpopupcloseBtn);
        }

        public void IsUpcomingStatusLaneTaskCountVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.upcomingTasksCount, BaseConfiguration.LongTimeout);
            var count = this.Driver.GetText(this.upcomingTasksCount);
            IList<IWebElement> lstElements = this.Driver.GetElements(this.upcomingtasksListNo);
            int cardcount = lstElements.Count;
            Console.WriteLine("Count = " + cardcount);
            Assert.AreEqual(count, cardcount);
        }

        public void IsDoneStatusLaneTaskCountVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.doneDvTasksCount, BaseConfiguration.LongTimeout);
            var count = this.Driver.GetText(this.doneDvTasksCount);
            this.Driver.ScrollToWebElement(this.cards);
            IList<IWebElement> lstElements = this.Driver.GetElements(this.doneDvtasksListNo);
            int cardcount = lstElements.Count;
            Console.WriteLine("Count = " + cardcount);
            Assert.AreEqual(count, cardcount);
        }

        public void IsOpenStatusLaneTaskCountVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.openDvTasksCount, BaseConfiguration.LongTimeout);
            var count = this.Driver.GetText(this.openDvTasksCount);
            this.Driver.ScrollToWebElement(this.cards);
            IList<IWebElement> lstElements = this.Driver.GetElements(this.openDvtasksListNo);
            int cardcount = lstElements.Count;
            Console.WriteLine("Count = " + cardcount);
            Assert.AreEqual(count, cardcount);
        }

        public void IsUserableToViewTaskId(string expected)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.viewTaskId, expected);
        }

        public void IsUserableToViewTaskTitle(string expected)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.viewTitle, expected);
        }

        public void IsUserableToViewStartDate(string expected)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.viewStartDate, expected);
        }

        public void IsUserableToViewEndDate(string expected)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.viewEndDate, expected);
        }

        public void IsUserableToViewRenewalYear(string expected)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.viewRenewalYear, expected);
        }

        public void IsUserableToViewDescription(string expected)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.viewDescription, expected);
        }

        public void IsUserableToViewAssignee(string expected)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.viewAssignee, expected);
        }

        public void IsUserableToViewSatus(string expected)
        {
            this.Driver.IsExpectedTextMatchWithActualText(this.viewStatus, expected);
        }

        public void IsUserableToViewTaskDetailsTitle(string title)
        {
            try
            {
                string actualTitle = this.Driver.Title;
                Assert.AreEqual(actualTitle, title);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Expected Value " + title + " Title is matching with Actual text ", "The expected title is " + title + " and  actual title is " + actualTitle + " matching successfully");
                Logger.Info("Expected text " + title + " and Actual text is " + actualTitle);
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to verify text on " + title + "with Actual Text Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify text on " + title + "with Actual Text ", "An exception occurred while finding text on " + title);
                throw;
            }
        }

        public void GetRenewalTasksPageTitle(string expectedTitle)
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

        public void IsSortBtnClickable()
        {
            this.Driver.IsElementVisible(this.viewSortyBy, this.nmaddSortByBtn);
            this.Driver.IsElementClickable(this.viewSortyBy, this.nmaddSortByBtn);
        }

        public void EndDateErrorMessageDisplayed(string expectedText)
        {
            string actualText = this.Driver.GetText(this.endDateErrorMessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.endDateErrorMessage, expectedText, actualText);
        }

        public void IsSortEndDateBtnClickable()
        {
            this.Driver.IsElementVisible(this.viewSortEndDate, this.nmaddSortEndDateBtn);
            this.Driver.IsElementClickable(this.viewSortEndDate, this.nmaddSortEndDateBtn);
        }

        public void IsUpcomingRenewalTaskTitleDisplayed(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.viewIncomingTitle.Format(expected), BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(this.viewIncomingTitle.Format(expected), expected);
        }

        public void IsOpenSortBtnClickable()
        {
            this.Driver.IsElementVisible(this.viewOpenSortyBy, this.nmaddSortByBtn);
            this.Driver.IsElementClickable(this.viewOpenSortyBy, this.nmaddSortByBtn);
        }

        public void IsOpenSortEndDateBtnClickable()
        {
            this.Driver.IsElementVisible(this.viewOpenSortEndDate, this.nmaddSortEndDateBtn);
            this.Driver.IsElementClickable(this.viewOpenSortEndDate, this.nmaddSortEndDateBtn);
        }

        public void IsOpenRenewalTaskTitleDisplayed(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.viewOpenTitle.Format(expected), BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(this.viewOpenTitle.Format(expected), expected);
        }

        public void IsOpenRenewalTaskTitle(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.viewOpenTitle.Format(expected), BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.viewOpenTitle.Format(expected), expected);
        }

        public void IsOpenRenewalTaskTitleWithThreeDotsDisplayed(string expected)
        {
            this.GetTextFromElementSearchThreeDots(this.viewOpenTitle.Format(expected), this.nmrenewalSearchTask);
        }

        public void IsRenewalTaskTitleBtnClickable(string expected)
        {
            this.Driver.IsElementVisible(this.viewOpenTitle.Format(expected), this.nmaRenewalTitleBtn);
            this.Driver.IsElementClickable(this.viewOpenTitle.Format(expected), this.nmaRenewalTitleBtn);
        }

        public void IsBannerTitleDisplayed(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.viewBannerTitle.Format(expected), BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(this.viewBannerTitle.Format(expected), expected);
        }

        public void IsBannerStatusDisplayed()
        {
            this.GetTextFromElement(this.viewBannerStatus, this.nmBannerStatus);
        }

        public void IsBannerTaskIdDisplayed()
        {
            this.GetTextFromElement(this.viewBannerTaskID, this.nmBannerTaskID);
        }

        public void IsBannerRenewalYearDisplayed()
        {
            this.GetTextFromElement(this.viewBannerRenewalYear, this.nmBannerRenewalYear);
        }

        public void IsBannerAssigneeDisplayed()
        {
            this.GetTextFromElement(this.viewBannerAssignee, this.nmBannerAssignee);
        }

        public void IsBannerTaskOwnerDisplayed()
        {
            this.GetTextFromElement(this.viewBannerTaskOwner, this.nmBannerTaskOwner);
        }

        public void IsBannerWatchersCountDisplayed()
        {
            this.GetTextFromElement(this.viewBannerWatchersCount, this.nmBannerWatchersCount);
        }

        public void IsBannerDateTimeStampDisplayed()
        {
            this.GetTextFromElement(this.viewBannerDateTimeStamp, this.nmBannerDateTimeStampCount);
        }

        public void IsWatcherStampDisplayed()
        {
            this.GetClassFromElement(this.viewBannerStartWatcherIssue, this.nmStartWachingIssueClass, this.nmStopWachingIssueClass, this.nmBannerStartWachingIssue, this.nmBannerStopWachingIssue, this.nmStartWachingErrorMessage);
        }

        public void IsSetReminderDisplayed()
        {
            this.GetClassFromElementForSingleClass(this.viewBannerSetReminder, this.nmSetReminderClass, this.nmBannerSetReminder, this.nmSetReminderErrorMessage);
        }

        public void IsCloneTaskDisplayed()
        {
            this.GetClassFromElementForSingleClass(this.viewBannerCloneIssue, this.nmCloneTaskClass, this.nmBannerCloneTask, this.nmCloneTaskErrorMessage);
        }

        public void IsRenewalSearchBtnClickable()
        {
            this.Driver.IsElementVisible(this.renewalSearch, this.nmrenewalSearchTaskBtn);
            this.Driver.IsElementClickable(this.renewalSearch, this.nmrenewalSearchTaskBtn);
        }

        public void GetClassFromElementForSingleClass(ElementLocator elementLoctr, string className, string classElementText, string errorMessage)
        {
            bool checkClassAvaible = false;
            try
            {
                var getElement = this.Driver.GetElement(elementLoctr);
                var getClassName = getElement.GetAttribute("class");
                if (getClassName == className)
                {
                    checkClassAvaible = true;
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "Element Text is :" + classElementText, "Element Text is " + classElementText + " found successfully");
                    Logger.Info("Element Text is :" + classElementText);
                }

                if (checkClassAvaible == false)
                {
                    Assert.IsTrue(checkClassAvaible);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Element Class is :" + errorMessage + " Due to exception: " + ex.ToString());
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "Failed to get Element Class : " + errorMessage, "An exception occurred while finding Element Class : " + errorMessage);
                throw;
            }
        }

        public void GetClassFromElement(ElementLocator elementLoctr, string className1, string className2, string classElementText1, string classElementText2, string errorMessage)
        {
            bool checkClassAvaible = false;
            try
            {
                var getElement = this.Driver.GetElement(elementLoctr);
                var getClassName = getElement.GetAttribute("class");
                if (getClassName == className1)
                {
                    checkClassAvaible = true;
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "Element Text is :" + classElementText1, "Element Text is " + classElementText1 + " found successfully");
                    Logger.Info("Element Text is :" + classElementText1);
                }

                if (getClassName == className2)
                {
                    checkClassAvaible = true;
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "Element Text is :" + classElementText2, "Element Text is " + classElementText2 + " found successfully");
                    Logger.Info("Element Text is :" + classElementText2);
                }

                if (checkClassAvaible == false)
                {
                    Assert.IsTrue(checkClassAvaible);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Element Class is :" + errorMessage + " Due to exception: " + ex.ToString());
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "Failed to get Element Class : " + errorMessage, "An exception occurred while finding Element Class : " + errorMessage);
                throw;
            }
        }

        public void IsRenewalTaskSelectionDisplayed(string expected)
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.successmsg, BaseConfiguration.LongTimeout);
            this.Driver.WaitUntilElementIsFound(this.renewalTaskSelection, BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(this.renewalTaskSelection, expected);
        }

        public void IsRenewalSearchHintDisplayed(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.renewalSearchHint.Format(expected), BaseConfiguration.LongTimeout);
            this.Driver.MouseOverOnWebElement(this.renewalSearchHint.Format(expected), this.nmrenewalSearchHint);
        }

        public string IsRenewalDepedent(string text)
        {
            this.Driver.IsElementVisible(this.renewalDependentCombo, this.nmaddrenewalDependent);
            this.Driver.IsElementClickable(this.renewalDependentCombo, this.nmaddrenewalDependent);
            this.Driver.EnterText(this.renewalDependentInput, text, this.nmaddrenewalDependent);
            this.IsDependOnSelectionClickable();
            this.Driver.WaitUntilElementIsFound(this.renewalDependentInput, BaseConfiguration.LongTimeout);
            string titleText = this.Driver.GetValue(this.renewalDependentInput);
            return titleText;
        }

        public void IsDependOnSelectionClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.renewalDependentSelection, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.renewalDependentSelection, this.nmrenewalDependentSelection);
            this.Driver.IsElementClickable(this.renewalDependentSelection, this.nmrenewalDependentSelection);
        }

        public void IsRenewalTaskDependentSortDisplayed(string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.renewalDependentSort, BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(this.renewalDependentSort, expected);
        }

        public void GetTextFromElementSearchThreeDots(ElementLocator elementLoctr, string elementName)
        {
            string actualText = string.Empty;
            try
            {
                this.Driver.WaitUntilElementIsFound(elementLoctr, BaseConfiguration.LongTimeout);
                this.Driver.IsElementVisible(elementLoctr, elementName);
                var getElement = this.Driver.GetElement(elementLoctr);
                actualText = getElement.Text;
                if (actualText.Contains("..."))
                {
                    DriverContext.ExtentStepTest.Log(LogStatus.Pass, "Element Name: " + elementName + " and Element Text is (" + actualText + ")", "The  Element Name is " + elementName + " and  Element Text is " + actualText + " matching successfully");
                    Logger.Info("Element Name: " + elementName + " and Element Text is (" + actualText + ")");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to get Element Name: " + elementName + " and Element Text is not maching with condition applied (...) (" + actualText + " ) Due to exception: " + ex.ToString());
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "Failed to get Element Name: " + elementName + " and Element Text is not maching with condition applied (...) (" + actualText + " )", "An exception occurred while finding Element : " + elementName);
                throw;
            }
        }

        public void GetTextFromElement(ElementLocator elementLoctr, string elementName)
        {
            string actualText = string.Empty;
            try
            {
                this.Driver.WaitUntilElementIsFound(elementLoctr, BaseConfiguration.LongTimeout);
                this.Driver.IsElementVisible(elementLoctr, elementName);
                var getElement = this.Driver.GetElement(elementLoctr);
                actualText = getElement.Text;
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "Element Name: " + elementName + " and Element Text is (" + actualText + ")", "The  Element Name is " + elementName + " and  Element Text is " + actualText + " matching successfully");
                Logger.Info("Element Name: " + elementName + " and Element Text is (" + actualText + ")");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to get Element Name: " + elementName + " and Element Text is " + actualText + " Due to exception: " + ex.ToString());
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "Failed to get Element Name: " + elementName + " and Element Text is (" + actualText + ")", "An exception occurred while finding Element : " + elementName);
                throw;
            }
        }

        public void IsErrorMessageDisplayed(string expected, ElementLocator elemlocatar)
        {
            this.Driver.WaitUntilElementIsFound(elemlocatar, BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(elemlocatar, expected);
        }

        public void VerifyingAllSectionEditableForTask(string actual, string expected, string name)
        {
            Verify.That(this.DriverContext, () => Assert.AreEqual(expected, actual), "Verifying whether the :" + name + ": field is in editable format", name + ": Field is editable", "Field is non-editable");
        }

        public void IsCommunicationsLogTabClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.communicationsTab, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.communicationsTab);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsUserAbleToAddComment(string text)
        {
            this.Driver.WaitUntilElementIsFound(this.commentTextBox, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.commentTextBox);
            webElement.SendKeys(Keys.Enter);
            webElement.SendKeys(text);
         }

        public void IsUserAbletoClickSubmitButton()
        {
           var webElement = this.Driver.GetElement(this.submitBtn, BaseConfiguration.LongTimeout);
           this.Driver.JavaScriptClick(webElement);
        }

        public void IsUserableToClickDeleteComment()
        {
            this.Driver.ScrollToWebElement(this.usernameOfComment);
            this.Driver.MouseOverOnWebElement(this.usernameOfComment, this.nmusernameOfComment);
            this.Driver.IsElementClickable(this.deleteCommentIcon, this.nmdeleteCommentIcon);
        }

        public void IsDeleteCommentPopupWindowVisible(string expectedText)
        {
            this.Driver.WaitUntilElementIsFound(this.deleteCommentPopupWindow, BaseConfiguration.LongTimeout);
            var actualText = this.Driver.GetText(this.deleteCommentPopupWindow);
            this.Driver.IsExpectedTextMatchWithActualText(this.deleteCommentPopupWindow, expectedText, actualText);
            var webEle = this.Driver.GetElement(this.deleteYesButton, BaseConfiguration.LongTimeout);
            this.Driver.JavaScriptClick(webEle);
            }

        public void IsuserAbleToEnterTextInSearchBoxFeature(string titlename)
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.successmsg, BaseConfiguration.LongTimeout);
            this.Driver.WaitUntilElementIsFound(this.renewalTaskSearchBox, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.renewalTaskSearchBox);
            this.Driver.PageScrollUpToTop();
            this.Driver.WaitUntilElementIsFound(this.renewalTaskSearchBox, BaseConfiguration.LongTimeout);
            this.Driver.EnterText(this.renewalTaskSearchBox, titlename, this.nmRenewalTaskSearchBox);
            this.Driver.IsElementVisible(this.searchBtnIcon, this.nmSearchIcon);
            this.Driver.IsElementClickable(this.searchBtnIcon, this.nmSearchIcon);
        }

        public void IsUserableToSelectTaskCardBasedOnName(string titlename)
        {
            this.Driver.IsElementClickable(this.renewalTaskCardName.Format(titlename), this.nmrenewalTaskName);
        }

        public void IsDependentTaskColumnVisible(string columnName)
        {
            bool value = this.Driver.IsElementVisibleWithSoftAssertion(this.dependantTasksColumn.Format(columnName), this.nmdependantTasksColumn);
            Verify.That(this.DriverContext, () => Assert.IsTrue(value), "Verifying whether the :" + columnName + ": column is visible", columnName + ": column  is visible", "column field  is not visible");
        }

        public void IsUserableToSelectTypeOfSearchUsingDropdown(string name)
        {
            var webElement = this.Driver.GetElement(this.searchfeatureDropdownIcon);
            this.Driver.JavaScriptClick(webElement);
            this.Driver.IsElementClickableFromListofElementWithText(this.searchfeatureDropdownList, name);
            this.Driver.WaitForPageLoad();
        }

        public void IsUserabletoViewTaskAfterPerformingSearch(string titlename)
        {
            this.Driver.WaitUntilElementIsNoLongerFound(this.loadbutton, BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(this.renewalTaskCardName.Format(titlename), titlename);
        }

        public void IsuserAbleToViewTaskDetails(string title, string taskid, string sdate, string edate, string desc, string assignee, string status)
        {
            this.IsUserableToViewTaskTitle(title);
            this.IsUserableToViewTaskId(taskid);
            this.IsUserableToViewStartDate(sdate);
            this.IsUserableToViewEndDate(edate);
            this.IsUserableToViewDescription(desc);
            this.IsUserableToViewAssignee(assignee);
            this.IsUserableToViewSatus(status);
        }

        public void IsAddedDependenciesTaskInfovisible(string name)
        {
            try
            {
                bool value = this.Driver.IsElementVisibleWithSoftAssertion(this.dependencyTaskInfo.Format(name), this.nmnewlyaddedDependenciesTable);
                Assert.IsTrue(value);
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to get Element Visible: " + name + " and Element Text is " + name + " Due to exception: " + ex.ToString());
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "Failed to get Element Visible: " + name + " and Element Visible is (" + name + ")", "An exception occurred while finding Element : " + name);
                throw;
            }
        }

        public bool IsSystemGeneratedUniqueTaskIdWithPrefixREN(string uniqueTaskID)
        {
            bool isPrefixREN = false;
            try
            {
                if (uniqueTaskID != null)
                {
                    string prefix = uniqueTaskID.Substring(0, 3);
                    if (prefix == "REN")
                    {
                        isPrefixREN = true;
                        DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Unique Task ID " + uniqueTaskID + " begins with prefix REN ", "The expected System Generated Unique Task ID is " + uniqueTaskID + " and  actual System Generated Unique Task ID is " + uniqueTaskID + " matching successfully");
                        Logger.Info("Expected System Generated Unique Task ID " + uniqueTaskID + " and Actual System Generated Unique Task ID is " + uniqueTaskID);
                    }
                }

                if (isPrefixREN == false)
                {
                    Assert.IsTrue(isPrefixREN);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed  Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify Unique Task ID with prefix REN ", "An exception occurred while Verifying Unique Task ID prefix REN ");
                throw;
            }

            return isPrefixREN;
        }

        public string IsGetDefaultRenewalYear()
        {
            var text = this.Driver.GetText(this.defaultRenewalYear);
            Assert.IsNotNull(text);
            return text;
        }

        public void IsUniqueIDWithSelectedYear(string uniqueTaskID, string renewalYear)
        {
            bool isSelectedRenewalYear = false;
            try
            {
                if (renewalYear != null)
                {
                    string[] numbers = Regex.Split(uniqueTaskID, @"\D+");
                    string dateChk = numbers[1];
                    string year = dateChk.Substring(0, 4);
                    if (year == renewalYear)
                    {
                        isSelectedRenewalYear = true;
                        DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Unique Task ID holds Renewal Year " + renewalYear + " ", "The expected System Generated Unique Task ID holds Renewal Year " + renewalYear + " and  actual System Generated Unique Task ID holds Renewal Year " + renewalYear + " ");
                        Logger.Info("Expected System Generated Unique Task ID holds Renewal Year " + renewalYear + " and Actual System Generated Unique Task ID holds Renewal Year " + renewalYear);
                    }
                    else
                    {
                        Assert.IsTrue(isSelectedRenewalYear);
                    }

                    var integerSequence = dateChk.Substring(dateChk.Length - 3);
                    if (Convert.ToInt32(integerSequence) <= 999)
                    {
                        DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Unique Task ID holds Sequential Series of numbers for Renewal Year " + renewalYear + " ", "The expected System Generated Unique Task ID holds  Sequential Series of numbers for Renewal Year " + renewalYear + " and  actual System Generated Unique Task ID holds Sequential Series of numbers for Renewal Year " + renewalYear + " ");
                        Logger.Info("Expected System Generated Unique Task ID holds  Sequential Series of numbers for Renewal Year " + renewalYear + " and Actual System Generated Unique Task ID holds  Sequential Series of numbers for Renewal Year " + renewalYear);
                    }
                    else
                    {
                        throw new Exception("Sequencial series of the Record number for the Renewal Year " + renewalYear + " exceeds 999");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed  Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify Unique Task ID holds Sequential Series of numbers for Renewal Year ", "An exception occurred while Verifying Unique Task ID with Sequential Series of numbers for Renewal Year ");
                throw;
            }
        }

        public void IsUserAbleToRedirectToAssigneePage(string assigneeName)
        {
             this.Driver.IsElementVisibleWithSoftAssertion(this.dependsOnassigneeNameToRedirect.Format(assigneeName), assigneeName);
             var webelement = this.Driver.GetElement(this.dependsOnassigneeNameToRedirect.Format(assigneeName), BaseConfiguration.LongTimeout);
             this.Driver.JavaScriptClick(webelement);
             this.Driver.WaitUntilElementIsNoLongerFound(this.loadbutton, BaseConfiguration.LongTimeout);
             bool value = this.Driver.IsElementVisibleWithSoftAssertion(this.bannerUserName.Format(assigneeName), assigneeName);
             Verify.That(this.DriverContext, () => Assert.IsTrue(value), "Verifying whether user is redirected to :" + assigneeName + ": userName Page", assigneeName + ": userName  is visible and redirected successfully ", "userName   is not visible and user is redirected to different page");
        }

        public void IsUserAbleToViewNoWatchersToDisplayText()
        {
            this.Driver.WaitUntilElementIsFound(this.viewBannerWatchersCount, BaseConfiguration.LongTimeout);
            var watchersCount = this.Driver.GetText(this.viewBannerWatchersCount);
            if (watchersCount == "0")
            {
                this.IsWatchersDetailsVisible();
                this.IsViewWatchersPopupClickable();
                this.Driver.IsElementVisible(this.noWatchersText, this.nmnoWatchersText);
            }
            else
            {
                throw new Exception("Watchers Count is not equal to 0");
            }
        }
    }
}