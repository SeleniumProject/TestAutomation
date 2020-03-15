﻿// <copyright file="HomePage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS
{
    using System;
    using global::MCS.Test.Automation.Common;
    using global::MCS.Test.Automation.Common.Extensions;
    using global::MCS.Test.Automation.Common.Types;
    using global::MCS.Test.Automation.Tests.PageObjects;
    using NLog;
    using RelevantCodes.ExtentReports;

    public class HomePage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator
customerLogo = new ElementLocator(Locator.CssSelector, "img.ui.image");

        private readonly ElementLocator
            adddocumentlist = new ElementLocator(Locator.CssSelector, "table.customTable.membershipDocTable tbody tr td");

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
              membershiptypeheader = new ElementLocator(Locator.XPath, "//*[@class='headingTitle clearfix']/h2[text()='{0}']");

        private readonly ElementLocator
             editMemeberShipTypeRecord = new ElementLocator(Locator.CssSelector, "i.pencil.icon");

        private readonly ElementLocator
            manageMemberClassifications = new ElementLocator(Locator.CssSelector, "ul > li:nth-child(4)");

        private readonly ElementLocator
            addApplicationbtn = new ElementLocator(Locator.CssSelector, "button.ui.secondary.button");

        private readonly ElementLocator
            successfullMsg = new ElementLocator(Locator.CssSelector, "div.ui.compact.message.success div.content p");

        private readonly ElementLocator
            applicationName = new ElementLocator(Locator.Name, "add_appName");

        private readonly ElementLocator
            contactName = new ElementLocator(Locator.Name, "add_contactName");

        private readonly ElementLocator
            emailId = new ElementLocator(Locator.Name, "add_email");

        private readonly ElementLocator
            savebtn = new ElementLocator(Locator.XPath, "//*[@class='column actions']/button[1]");

        private readonly ElementLocator
            cancelBtn = new ElementLocator(Locator.XPath, "//*[@class='column actions']/button[2]");

        private readonly ElementLocator
            addClassifficationTypebtn = new ElementLocator(Locator.CssSelector, "button.ui.secondary.button");

        private readonly ElementLocator
            addDocumentBtn = new ElementLocator(Locator.CssSelector, "button.ui.secondary.button");

        private readonly ElementLocator
            addClassificationTypeheader = new ElementLocator(Locator.XPath, "//*[@class='ui modal transition visible active tiny']/div[1]");

        private readonly ElementLocator
            classificationtxt = new ElementLocator(Locator.XPath, "//*[@placeholder='Classification Type']");

        private readonly ElementLocator
            adddocumenttxt = new ElementLocator(Locator.Name, "add_Name");

        private readonly ElementLocator
            descriptiontxt = new ElementLocator(Locator.XPath, "//*[@name='Description']");

        private readonly ElementLocator
            uploadbutton = new ElementLocator(Locator.CssSelector, "div.uploadBtn input#file.input-file");

        private readonly ElementLocator
            classificationsavebtn = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
        classificationCancelbtn = new ElementLocator(Locator.CssSelector, " button.ui.button.cancel");

        private readonly ElementLocator
            errormsgforClassification = new ElementLocator(Locator.CssSelector, "span.errorMessage");

        private readonly ElementLocator
            applicationError = new ElementLocator(Locator.XPath, "//span[@class='errorMessage' and contains(text(),'Application Name is required.')]");

        private readonly ElementLocator
            contactError = new ElementLocator(Locator.XPath, "//span[@class='errorMessage' and contains(text(),'Contact Name is required.')]");

        private readonly ElementLocator
            emailError = new ElementLocator(Locator.XPath, "//span[@class='errorMessage' and contains(text(),'Email ID is required.')]");

        private readonly ElementLocator
             profilemenu = new ElementLocator(Locator.CssSelector, "div.ui.active.visible.dropdown span i.user.icon");

        private readonly ElementLocator
            signOutLink = new ElementLocator(Locator.XPath, "(//div[@class='item'])[3]");

        private readonly ElementLocator
            classificationRecordList = new ElementLocator(Locator.XPath, "//*[@class='customTable']/tbody/tr/td/a");

        private readonly ElementLocator
            classificationTable = new ElementLocator(Locator.XPath, "//*[@class='customTable']/tbody");

        private readonly ElementLocator
            editClassificationRecord = new ElementLocator(Locator.CssSelector, "div.actions a.editBtn");

        private readonly ElementLocator
            loggedUser = new ElementLocator(Locator.CssSelector, "span.maxName.ellip");

        private readonly ElementLocator
            updatebutton = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
            membershipTypeList = new ElementLocator(Locator.CssSelector, "table.customTable.memberShipTable tbody tr td a");

        private readonly ElementLocator
            usermanagement = new ElementLocator(Locator.CssSelector, "div:nth-child(4)>p>i");

        private readonly ElementLocator
           userrecord = new ElementLocator(Locator.XPath, "//td[@class='userName']/a[contains(text(),'{0}')]");

        private readonly ElementLocator
            usersHeader = new ElementLocator(Locator.XPath, "//h2[contains(text(), 'Users ')]");

        private readonly ElementLocator
            viewUserHeader = new ElementLocator(Locator.CssSelector, "div.headingTitle.clearfix.mb20 > h2");

        private readonly ElementLocator
            adddocumentsavebtn = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
            loggedUserDropdown = new ElementLocator(Locator.XPath, "//*[@id='root']//*[@class='dropdown icon']");

        private readonly ElementLocator
            adminMenuitem = new ElementLocator(Locator.XPath, "//*[text()='Admin']");

        private readonly ElementLocator
          userPermissionSubmenuitem = new ElementLocator(Locator.XPath, "//*[text()='User Permissions']");

        private readonly ElementLocator
          rolesAdminSubmenuitem = new ElementLocator(Locator.XPath, "//a[text()='Roles']");

        private readonly ElementLocator
            errormsgforUniqueAddClassification = new ElementLocator(Locator.CssSelector, "span.errorMessage");

        private readonly ElementLocator
            popupCloseButton = new ElementLocator(Locator.XPath, "//i[@class='close']");

        private readonly ElementLocator
                  userMemberShipDocumentTableFirstIndex = new ElementLocator(Locator.XPath, "(//td[@class='Name'])[1]");

        private readonly ElementLocator
          userMemberShipDocumentTableDeleteIconFirstIndex = new ElementLocator(Locator.XPath, "(//i[@class='trash bordered icon squareIcon'])[1]");

        private readonly ElementLocator
          userMemberShipDocumentTableDeleteYesButton = new ElementLocator(Locator.XPath, "//button[text()='Yes']");

        private readonly ElementLocator
            deleteMsg = new ElementLocator(Locator.CssSelector, "div.ui.compact.message.success div.content p");

        private readonly ElementLocator
           documentNames = new ElementLocator(Locator.CssSelector, "td.Name");

        private readonly ElementLocator
            classificationType = new ElementLocator(Locator.CssSelector, "td.appName");

        private readonly ElementLocator
          classificationDescription = new ElementLocator(Locator.CssSelector, "td.appId");

        private string nmadminMenu = "Admin Menu";
        private string nmloggedUserDropdown = "Signout Link Dropdown";
        private string nmadddocumentxt = "Document text box";
        private string nmadddocumentbtn = "Add Document button";
        private string nmusermanagement = "User Management Menu";
        private string nmcustomerlogo = "Customer logo";
        private string nmeditMemeberShipTypeRecord = "Edit button";
        private string nmmembership = "Memebership Management Menu";
        private string nmcommitteemanagement = "Committee Management Menu";
        private string nmapplicationmanagement = "Application Management Menu";
        private string nmmanagememebershiptype = "Manage Membership Type option";
        private string nmmanagemembershipFaqs = "Manage Membership FAQ's option";
        private string nmmanagemembershipdocument = "Manage Membership Documents option";
        private string nmmanagememeberclassifications = "Manage Member Classifications option";
        private string nmaddapplicationbtn = "Add Application Button";
        private string nmapplicationname = "Application Name field";
        private string nmcontactName = "Contact Name field";
        private string nmemail = "Email Field";
        private string nmsavebtn = "Save button";
        private string nmCancelbtn = "Cancel button";
        private string nmAddClassificationTypeBtn = "Add Classification button";
        private string nmAdddocumentsavebtn = "Add Doument Save button";
        private string nmClassficationtxt = "Classfication Text field";
        private string nmClassificationDescrition = "Classification Description Text Field";
        private string nmclassificationsavebutton = "Save button";
        private string nmclassificationCancelbutton = "Cancel button";
        private string nmclassificationrecordlist = "Classification Record";
        private string nmEditClassification = "Edit Classification record";
        private string nmsuccessfullmsg = "Membership Classification added Successfully";
        private string nmadddocumentsuccessmsgmessage = "New Membership Document added successfully.";
        private string nmAddApplicationsuccessfullmsg = "Membership Application added Successfully";
        private string nmloggeduser = "Logged In User";
        private string nmmemebershiptypeheader = "Membership Types header";
        private string nmmembershiptypeList = "Membership Type from List of records";
        private string nmuserrecord = "User Record To Edit";
        private string nmuserheader = "UserRecords header";
        private string nmViewUserHeader = "View Users Header";
        private string nmTableDeletebtn = "Membership Document Table Delete button";
        private string nmTableYesbtn = "Membership Document Table Yes button";
        private string nmdeletemsgmessage = "Membership Document deleted successfully.";
        private string nmPopupCloseButton = "Add Classification Pop Close Button";

        public HomePage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void IsCustomerLogoDisplayed()
        {
            this.Driver.IsElementVisible(this.customerLogo, this.nmcustomerlogo);
        }

        public void IsAddDocumentSavedToListOfRecordsSuccessfully(string documentName)
        {
            this.Driver.IsElementVisibleFromListOfElement(this.adddocumentlist, documentName);
        }

        public void IsLoggedUserDisplayed()
        {
            this.Driver.IsElementVisibleWithSoftAssertion(this.loggedUser, this.nmloggeduser);
        }

        public void IsUserManagementSectionClickable()
        {
            this.Driver.IsElementVisible(this.usermanagement, this.nmusermanagement);
            this.Driver.IsElementClickable(this.usermanagement, this.nmusermanagement);
        }

        public void IsUsersHeaderVisible(string header)
        {
            this.Driver.WaitUntilElementIsFound(this.usersHeader, 90);
            this.Driver.IsElementVisible(this.usersHeader.Format(header), this.nmuserheader);
        }

        public void IsViewUsersPageDisplayed(string headername)
        {
            this.Driver.IsElementVisible(this.viewUserHeader.Format(headername), this.nmViewUserHeader);
        }

        public void IsUserRecordclickable(string userrecord)
        {
            this.Driver.IsElementVisible(this.userrecord.Format(userrecord), this.nmuserrecord);
            this.Driver.IsElementClickable(this.userrecord.Format(userrecord), this.nmuserrecord);
        }

        public void IsUpdateButtonClickable()
        {
            this.Driver.IsElementVisible(this.customerLogo, this.nmcustomerlogo);
            this.Driver.IsElementClickable(this.customerLogo, this.nmcustomerlogo);
        }

        public void IsAddDocumentSaveButtonClickableFromPopUpWindow()
        {
            this.Driver.IsElementVisible(this.adddocumentsavebtn, this.nmAdddocumentsavebtn);
            this.Driver.IsElementClickable(this.adddocumentsavebtn, this.nmAdddocumentsavebtn);
        }

        public string GetDocumentNameFirstIndexFromTableList()
        {
            this.Driver.WaitUntilElementIsFound(this.userMemberShipDocumentTableFirstIndex, BaseConfiguration.LongTimeout);
            var actualUsername = this.Driver.GetText(this.userMemberShipDocumentTableFirstIndex);
            return actualUsername;
        }

        public void IsDeleteButtonFromMembershipDocumentTableClickable()
        {
            this.Driver.IsElementVisible(this.userMemberShipDocumentTableDeleteIconFirstIndex, this.nmTableDeletebtn);
            this.Driver.IsElementClickable(this.userMemberShipDocumentTableDeleteIconFirstIndex, this.nmTableDeletebtn);
        }

        public void IsYesButtonFromMembershipDocumentTableClickable()
        {
            this.Driver.IsElementVisible(this.userMemberShipDocumentTableDeleteYesButton, this.nmTableYesbtn);
            this.Driver.IsElementClickable(this.userMemberShipDocumentTableDeleteYesButton, this.nmTableYesbtn);
        }

        public void IsDeleteMessageForAddMembershipDocumentDisplayed(string documentdeletemessage, string expected)
        {
            this.Driver.WaitUntilElementIsFound(this.deleteMsg, 60);
            this.Driver.IsElementVisible(this.deleteMsg, this.nmdeletemsgmessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.deleteMsg, documentdeletemessage, this.nmdeletemsgmessage);
            this.Driver.GetTextFromListOfElementsBasedOnName(this.documentNames, expected);
        }

        public void IsUserAbleToViewInfoInClassificationTypeColumn(string expected)
        {
            string actual = this.Driver.GetText(this.classificationType);
            this.Driver.IsExpectedTextMatchWithActualTextToLower(this.classificationType, expected, actual);
        }

        public void PageRefresh()
        {
            this.Driver.Navigate().Refresh();
        }

        public void IsUserAbleToViewInfoInClassificationDescriptionColumn(string expected)
        {
            string actual = this.Driver.GetText(this.classificationDescription);
            this.Driver.IsExpectedTextMatchWithActualTextToLower(this.classificationDescription, expected, actual);
        }

        public void IsUserAbleToViewManageMembershipClassificationListInLifoOrder(int i, string expected)
        {
            var actualMembership = this.Driver.GetText(this.classificationType);
            this.Driver.IsExpectedTextMatchWithActualTextToLower(this.classificationType, expected, actualMembership);
        }

        public void IsErrorMessageDisplayedforMembershipClassificationUnique(string expectedErrorMessage)
        {
            try
            {
                var actualErrorMessage = this.Driver.GetText(this.errormsgforUniqueAddClassification);
                this.Driver.IsExpectedTextMatchWithActualText(this.errormsgforUniqueAddClassification, expectedErrorMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void IsPopUpCloseButtonClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.popupCloseButton, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.popupCloseButton, this.nmPopupCloseButton);
        }

        public void IsLoggedInUserDisplayed(string uname)
        {
            this.Driver.IsElementTextDisplayed(this.loggedUser.Format(uname), this.nmloggeduser);
        }

        public void IsMembershipTypeHeaderDisplayed(string header)
        {
            this.Driver.IsElementTextDisplayed(this.membershiptypeheader.Format(header), this.nmmemebershiptypeheader);
        }

        public void IsMembershipTypeRecordClickableFromList(string membershiptype)
        {
            this.Driver.WaitUntilElementIsFound(this.membershipTypeList, BaseConfiguration.LongTimeout);
            this.Driver.ClickOnMembershipTypeFromListofRecords(this.membershipTypeList, this.nmmembershiptypeList, membershiptype);
        }

        public void IsApplicationManagementSectionDisplayed()
        {
            // this.Driver.WaitUntilElementIsFound(this.applicationManagement, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.applicationManagement, this.nmapplicationmanagement);
        }

        public void IsMemebershipTypeRecordEditable()
        {
            this.Driver.IsElementVisible(this.editMemeberShipTypeRecord, this.nmeditMemeberShipTypeRecord);
            this.Driver.IsElementClickable(this.editMemeberShipTypeRecord, this.nmeditMemeberShipTypeRecord);
        }

        public void IsMembershipManagementSectionClickable()
        {
            this.Driver.IsElementVisible(this.membershipmenu, this.nmmembership);
            this.Driver.IsElementClickable(this.membershipmenu, this.nmmembership);
        }

        public void IsSuccessfullMessageForAddMembershipClassificationDisplayed()
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, 60);
            this.Driver.IsElementVisibleWithSoftAssertion(this.successfullMsg, this.nmsuccessfullmsg);
        }

        public void IsSuccessfullMessageForAddMembershipDocumentDisplayed(string documentsavemessage)
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, 60);
            this.Driver.IsElementVisible(this.successfullMsg, this.nmadddocumentsuccessmsgmessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.successfullMsg, documentsavemessage, this.nmadddocumentsuccessmsgmessage);
        }

        public void AreAddApplicationValidationMessagesDisplayed(string appError, string contactError, string emailError)
        {
            this.IsApplicationNameErrorMsgDisplayed(appError);
            this.IsApplicationContactNameErrorMsgDisplayed(contactError);
            this.IsApplicationEmialIdErrorMsgDisplayed(emailError);
        }

        public void IsApplicationNameErrorMsgDisplayed(string expectedApplicationErrormsg)
        {
            var actualApplicationNameErrortext = this.Driver.GetText(this.applicationError);
            this.Driver.IsExpectedTextMatchWithActualText(this.applicationError, expectedApplicationErrormsg, actualApplicationNameErrortext);
        }

        public void IsApplicationContactNameErrorMsgDisplayed(string expectedApplicationErrormsg)
        {
            var actualApplicationContactNameErrortext = this.Driver.GetText(this.contactError);
            this.Driver.IsExpectedTextMatchWithActualText(this.contactError, expectedApplicationErrormsg, actualApplicationContactNameErrortext);
        }

        public void IsApplicationEmialIdErrorMsgDisplayed(string expectedApplicationErrormsg)
        {
            var actualApplicationEmailIdErrortext = this.Driver.GetText(this.emailError);
            this.Driver.IsExpectedTextMatchWithActualText(this.emailError, expectedApplicationErrormsg, actualApplicationEmailIdErrortext);
        }

        public void IsClassificationRecordEditable()
        {
            this.Driver.WaitUntilElementIsFound(this.classificationRecordList, BaseConfiguration.LongTimeout);
            this.Driver.ClickonSelectedElementfromList(this.classificationRecordList, this.nmclassificationrecordlist, 0);
        }

        public void IsEditButtonClickable()
        {
            this.Driver.IsElementVisible(this.editClassificationRecord, this.nmEditClassification);
            this.Driver.IsElementClickable(this.editClassificationRecord, this.nmEditClassification);
        }

        public void IsCommitteeManagementSectionClickable()
        {
            this.Driver.IsElementVisible(this.committeemanagement, this.nmcommitteemanagement);
            this.Driver.IsElementClickable(this.committeemanagement, this.nmcommitteemanagement);
        }

        public void IsApplicationManagementSectionClickable()
        {
            this.Driver.IsElementVisible(this.applicationManagement, this.nmapplicationmanagement);
            this.Driver.IsElementClickable(this.applicationManagement, this.nmapplicationmanagement);
        }

        public void IsManageMembershipTypeClickable()
        {
            this.Driver.IsElementVisible(this.managemembershiptype, this.nmmanagememebershiptype);
            this.Driver.IsElementClickable(this.managemembershiptype, this.nmmanagememebershiptype);
        }

        public void IsManageMembershipFAQsClickable(string name)
        {
            this.Driver.WaitUntilElementIsFound(this.manageMembershipFAQs.Format(name), 60);
            this.Driver.IsElementVisible(this.manageMembershipFAQs.Format(name), this.nmmanagemembershipFaqs);
            this.Driver.IsElementClickable(this.manageMembershipFAQs.Format(name), this.nmmanagemembershipFaqs);
        }

        public void IsManageMembershipDocumentsClickable(string name)
        {
            this.Driver.IsElementVisible(this.manageMembershipDocuments.Format(name), this.nmmanagemembershipdocument);
            this.Driver.IsElementClickable(this.manageMembershipDocuments.Format(name), this.nmmanagemembershipdocument);
        }

        public void IsAddApplicationButtonClickable()
        {
            this.Driver.IsElementVisible(this.addApplicationbtn, this.nmaddapplicationbtn);
            var webElement = this.Driver.GetElement(this.addApplicationbtn);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsManageMembershipClassificationsClickable()
        {
            this.Driver.IsElementVisible(this.manageMemberClassifications, this.nmmanagememeberclassifications);
            this.Driver.IsElementClickable(this.manageMemberClassifications, this.nmmanagememeberclassifications);
        }

        public void IsManageMembershipDocumentClickable()
        {
            this.Driver.IsElementVisible(this.manageMembershipDocuments, this.nmmanagemembershipdocument);
            this.Driver.IsElementClickable(this.manageMembershipDocuments, this.nmmanagemembershipdocument);
        }

        public void IsAddClassificationTypeButtonClickable()
        {
            var webElement = this.Driver.GetElement(this.addClassifficationTypebtn);
            this.Driver.IsElementVisible(this.addClassifficationTypebtn, this.nmAddClassificationTypeBtn);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsAddDocumentButtonClickable()
        {
            var webElement = this.Driver.GetElement(this.addDocumentBtn);
            this.Driver.IsElementVisible(this.addDocumentBtn, this.nmadddocumentbtn);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsUserAbleToEnterClassificationTypeInPopUpWindowOfAddClassificationType(string name)
        {
            this.Driver.IsElementVisible(this.classificationtxt, this.nmClassficationtxt);
            this.Driver.EnterText(this.classificationtxt, name, this.nmClassficationtxt);
        }

        public void IsUserAbleToEnterDocumentNameInPopUpWindowOfAddDocument(string filepath)
        {
            this.Driver.IsElementVisible(this.adddocumenttxt, this.nmadddocumentxt);
            this.Driver.EnterText(this.adddocumenttxt, filepath, this.nmadddocumentxt);
        }

        public void IsUserAbleToEnterClassificationDescriptionInPopUpWindowOfAddClassificationType(string name)
        {
            this.Driver.IsElementVisible(this.descriptiontxt, this.nmClassificationDescrition);
            this.Driver.EnterText(this.descriptiontxt, name, this.nmClassificationDescrition);
        }

        public void IsUserAbletoUploadDocumentToAddDocument(string name)
        {
            // this.Driver.IsElementClickable(this.uploadbutton, this.nmuploadbtn);
            this.Driver.UploadFile(this.uploadbutton, name);
        }

        public void IsSaveButtonClickableOfPopUpWindowOfAddClassificationType()
        {
            this.Driver.IsElementVisible(this.classificationsavebtn, this.nmclassificationsavebutton);
            this.Driver.IsElementClickable(this.classificationsavebtn, this.nmclassificationsavebutton);
        }

        public void IsCancelButtonClickableOfPopUpWindowOfAddClassificationType()
        {
            this.Driver.IsElementClickable(this.classificationCancelbtn, this.nmclassificationCancelbutton);
        }

        public void IsMandatoryfieldErrorMessageDisplayedforMembershipClassification(string expectedErrorMessage)
        {
            try
            {
                var actualErrorMessage = this.Driver.GetText(this.errormsgforClassification);
                this.Driver.IsExpectedTextMatchWithActualText(this.errormsgforClassification, expectedErrorMessage, actualErrorMessage);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Error Message Displayed for Mandatory Fields in Add Membership Clasification ", "The error message for mandatory fields in Add Membership Clasification is displayed successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void IsUserAbletoEnterApplicationName(string name)
        {
            this.Driver.WaitForPageLoad();
            this.Driver.IsElementVisible(this.applicationName.Format(name), this.nmapplicationname);
            this.Driver.EnterText(this.applicationName.Format(name), name, this.nmapplicationname);
        }

        public void IsUserAbletoEnterContactName(string name)
        {
            this.Driver.IsElementVisible(this.contactName.Format(name), this.nmcontactName);
            this.Driver.EnterText(this.contactName.Format(name), name, this.nmcontactName);
        }

        public void IsUserAbletoEnterEmailID(string name)
        {
            this.Driver.IsElementVisible(this.emailId.Format(name), this.nmemail);
            this.Driver.EnterText(this.emailId.Format(name), name, this.nmemail);
        }

        public void IsAddApplicationSaveButtonClickable()
        {
            this.Driver.IsElementVisible(this.savebtn, this.nmsavebtn);
            this.Driver.IsElementClickable(this.savebtn, this.nmsavebtn);
        }

        public void IsAddApplicationSuccessfullMessageDisplayed()
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, 90);
            this.Driver.IsElementVisibleWithSoftAssertion(this.successfullMsg, this.nmAddApplicationsuccessfullmsg);
        }

        public void IsAddApplicationCancelButtonClickable()
        {
            this.Driver.IsElementVisible(this.cancelBtn, this.nmCancelbtn);
            this.Driver.IsElementClickable(this.cancelBtn, this.nmCancelbtn);
        }

        public void IsProfileMenuClickable()
        {
            var webElement = this.Driver.GetElement(this.profilemenu);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsSignOutClickable(string name)
        {
            this.Driver.WaitUntilElementIsFound(this.loggedUser, BaseConfiguration.LongTimeout);
            this.Driver.IsElementClickable(this.loggedUser, this.nmloggedUserDropdown);
            this.Driver.MouseOverOnWebElement(this.signOutLink, name);
        }

        public void SelectUserPermissionFromAdminMenuitem()
        {
            this.Driver.WaitUntilElementIsFound(this.adminMenuitem, BaseConfiguration.LongTimeout);
            this.Driver.MouseOverOnWebElement(this.adminMenuitem, this.nmadminMenu);
            var webElement = this.Driver.GetElement(this.userPermissionSubmenuitem);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsSelectRolesFromAdminMenuitem()
        {
            this.Driver.WaitUntilElementIsFound(this.adminMenuitem, BaseConfiguration.LongTimeout);
            this.Driver.MouseOverOnWebElement(this.adminMenuitem, this.nmadminMenu);
            var webElement = this.Driver.GetElement(this.rolesAdminSubmenuitem);
            this.Driver.JavaScriptClick(webElement);
        }
    }
}
