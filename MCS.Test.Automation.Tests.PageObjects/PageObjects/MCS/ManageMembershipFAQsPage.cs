﻿// <copyright file="ManageMembershipFAQsPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using global::MCS.Test.Automation.Common;
    using global::MCS.Test.Automation.Common.Extensions;
    using global::MCS.Test.Automation.Common.Types;
    using global::MCS.Test.Automation.Tests.PageObjects;
    using global::NUnit.Framework;
    using NLog;
    using OpenQA.Selenium;
    using RelevantCodes.ExtentReports;

    public class ManageMembershipFAQsPage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly ElementLocator
        membershipFAQsHeading = new ElementLocator(Locator.CssSelector, "div.headingTitle.clearfix > h2");

        private readonly ElementLocator
        addmembershipFAQBtn = new ElementLocator(Locator.CssSelector, "button.ui.secondary.button");

        private readonly ElementLocator
       faqQuestionsColumn = new ElementLocator(Locator.CssSelector, "th.questions");

        private readonly ElementLocator
        faqAnswersColumn = new ElementLocator(Locator.CssSelector, "th.answers");

        private readonly ElementLocator
       faqStatusColumn = new ElementLocator(Locator.CssSelector, "th.status");

        private readonly ElementLocator
        addmembershipFAQsHeading = new ElementLocator(Locator.CssSelector, "div > div.header");

        private readonly ElementLocator
            addFAQsQuestion = new ElementLocator(Locator.XPath, "//label[text()='Question']/following-sibling::div//div[@class='notranslate public-DraftEditor-content']");

        private readonly ElementLocator
             addFAQsAnswer = new ElementLocator(Locator.XPath, "//label[text()='Answer']/following-sibling::div//div[@class='notranslate public-DraftEditor-content']");

        private readonly ElementLocator
            saveBtn = new ElementLocator(Locator.XPath, "//button[text()='Save']");

        private readonly ElementLocator
            cancelBtn = new ElementLocator(Locator.XPath, "//button[text()='Cancel']");

        private readonly ElementLocator
           successfullMsg = new ElementLocator(Locator.CssSelector, "div.content p");

        private readonly ElementLocator
             fAQname = new ElementLocator(Locator.CssSelector, "td.question div.truncatedText");

        private readonly ElementLocator
             statusheader = new ElementLocator(Locator.CssSelector, "span.statusActive");

        private readonly ElementLocator
            faqQuestionlabeltext = new ElementLocator(Locator.XPath, "//div[@class='questionLabel']/p");

        private readonly ElementLocator
             editBtn = new ElementLocator(Locator.CssSelector, "a.editBtn");

        private readonly ElementLocator
            membershipUpdateFAQsHeading = new ElementLocator(Locator.CssSelector, "div.header");

        private readonly ElementLocator
          faqQuestionsList = new ElementLocator(Locator.XPath, "//table[@class='customTable faqTable']//td//p");

        private readonly ElementLocator
            closeButtonforFAQPopupWindow = new ElementLocator(Locator.CssSelector, "i.close");

        private readonly ElementLocator
           deleteFAQButton = new ElementLocator(Locator.XPath, "//*[text()='{0}']/../../following :: td[3]/a/i");

        private readonly ElementLocator
            confirmationHeader = new ElementLocator(Locator.CssSelector, "div.header");

        private readonly ElementLocator
            yesButton = new ElementLocator(Locator.CssSelector, "button.ui.primary.button");

        private readonly ElementLocator
            errorMessageforQuestionField = new ElementLocator(Locator.XPath, "//span[text()='Question is required.']");

        private readonly ElementLocator
            errorMessageforAnswerField = new ElementLocator(Locator.XPath, "//span[text()='Answer is required.']");

        private readonly ElementLocator
          cancelButton = new ElementLocator(Locator.XPath, "//button[text()='Cancel']");

        private string nmyesButton = "Select Yes Button";
        private string nmdeleteFAQButton = "Delete FAQ icon";
        private string nmdeletedSuccessfullyMsg = "FAQ deleted Successfully.";
        private string nmfaqQuestionlabeltext = "Selected Question Text in Popup Window";
        private string nmcloseButtonforFAQPopupWindow = "Close Button in FAQPopup Window";
        private string nmfaqquestionsList = "Selected Question from All FAQ Questions List";
        private string nmsuccessfullmessage = "New FAQ added successfully.";
        private string nmupdatedSuccessMsg = " FAQ Updated Successfully";
        private string nmaddmembershipFAQBtn = "Add Membership FAQ Button";
        private string nmMembershipFAQsHeading = "Membership FAQs Heading";
        private string nmFAQQuestion = "FAQ Question TextBox";
        private string nmFAQAnswer = "FAQ Answer Textbox";
        private string nmaddmembershipFAQsHeading = "Add membership FAQs Heading";
        private string nmsaveBtn = "Save Button";
        private string nmFAQname = "Name of FAQ";
        private string nmstatusheader = "FAQ status header";
        private string nmeditBtn = "Edit FAQ Button";
        private string nmMembershipUpdateFAQsHeading = "Membership Update FAQs Heading";
        private string nmCancelBtn = "Cancel Button";

        public ManageMembershipFAQsPage(DriverContext driverContext)

        : base(driverContext)
        {
        }

        public void IsMembershipFAQsHeaderVisible()
        {
            this.Driver.IsElementVisibleWithSoftAssertion(this.membershipFAQsHeading, this.nmMembershipFAQsHeading);
        }

        public void IsQuestionColumnVisible(string expectedcolumnText)
        {
            this.Driver.WaitUntilElementIsFound(this.faqQuestionsColumn, BaseConfiguration.LongTimeout);
            string actualColumnText = this.Driver.GetText(this.faqQuestionsColumn);
            this.Driver.IsExpectedTextMatchWithActualText(this.faqQuestionsColumn, expectedcolumnText, actualColumnText);
        }

        public void IsAnswersColumnVisible(string expectedcolumnText)
        {
            this.Driver.WaitUntilElementIsFound(this.faqAnswersColumn, BaseConfiguration.LongTimeout);
            string actualColumnText = this.Driver.GetText(this.faqAnswersColumn);
            this.Driver.IsExpectedTextMatchWithActualText(this.faqAnswersColumn, expectedcolumnText, actualColumnText);
        }

        public void IsStatusColumnVisible(string expectedcolumnText)
        {
            this.Driver.WaitUntilElementIsFound(this.faqStatusColumn, BaseConfiguration.LongTimeout);
            string actualColumnText = this.Driver.GetText(this.faqStatusColumn);
            this.Driver.IsExpectedTextMatchWithActualText(this.faqStatusColumn, expectedcolumnText, actualColumnText);
        }

        public void IsAddFAQButtonVisible(string expectedButtonText)
        {
            this.Driver.WaitUntilElementIsFound(this.addmembershipFAQBtn, BaseConfiguration.LongTimeout);
            string actualColumnText = this.Driver.GetText(this.addmembershipFAQBtn);
            this.Driver.IsExpectedTextMatchWithActualText(this.addmembershipFAQBtn, expectedButtonText, actualColumnText);
        }

        public void IsAddFAQButtonClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.addmembershipFAQBtn, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.addmembershipFAQBtn);
            this.Driver.IsElementVisible(this.addmembershipFAQBtn, this.nmaddmembershipFAQBtn);
            this.Driver.JavaScriptClick(webElement);
        }

        public void IsAddMembershipFAQsPopUpWindowTitleVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.addmembershipFAQsHeading, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.addmembershipFAQsHeading, this.nmaddmembershipFAQsHeading);
        }

        public void EnterFAQQuestionTextInEditorWindow(string text)
        {
            this.Driver.IsElementVisible(this.addFAQsQuestion, this.nmFAQQuestion);
            this.Driver.EnterText(this.addFAQsQuestion, text, this.nmFAQQuestion);
        }

        public void EnterFAQAnswerTextInEditorWindow(string text)
        {
            this.Driver.IsElementVisible(this.addFAQsAnswer, this.nmFAQAnswer);
            this.Driver.EnterText(this.addFAQsAnswer, text, this.nmFAQAnswer);
        }

        public void IsQuestionListTextNotEmpty()
        {
            try
            {
                Collection<string> faqsList = this.Driver.GetTableElementsList(this.faqQuestionsList);
                Assert.IsNotEmpty(faqsList);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify whether List Value is Not Empty");
                Logger.Info("List Values are non-empty ");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed as the List value is Empty - " + "Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify List Value is Not Empty", "An exception occurred while verify List Value");
                throw ex;
            }
        }

        public void IsAddFAQsSaveButtonCllickable()
        {
            this.Driver.WaitUntilElementIsFound(this.saveBtn, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.saveBtn);
            this.Driver.IsElementVisible(this.saveBtn, this.nmsaveBtn);
            this.Driver.JavaScriptClick(webElement);
            this.Driver.WaitForPageLoad();
        }

        public void IsAddFAQCancelButtonClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.cancelBtn, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.cancelBtn);
            this.Driver.IsElementVisible(this.cancelBtn, this.nmCancelBtn);
            this.Driver.JavaScriptClick(webElement);
            this.Driver.WaitForPageLoad();
        }

        public void IsMembershipFAQsAddedMessageDisplayedSuccessfully(string updateSuccessmessage)
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.successfullMsg, this.nmsuccessfullmessage);
            this.Driver.IsExpectedTextMatchWithActualText(this.successfullMsg, updateSuccessmessage, this.nmsuccessfullmessage);
        }

        public void SelectFAQFromListWithText(string text)
        {
            this.Driver.IsElementVisibleFromListOfElement(this.fAQname, text);
        }

        public void SelectFAQFromList(int i)
        {
            this.Driver.IsElementVisibleFromListOfElement(this.fAQname, this.nmFAQname);
            this.Driver.ClickonSelectedElementfromList(this.fAQname, this.nmFAQname, i);
        }

        public void VerifyFAQFromList(string fAQQuestionToVerify)
        {
            this.Driver.IsElementVisibleFromListOfElement(this.fAQname, fAQQuestionToVerify);
            this.Driver.ClickonSelectedElementfromList(this.fAQname, this.nmFAQname, 0);
        }

        public void IsStatusOfFAQPopupWindowVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.statusheader, 50);
            this.Driver.IsElementVisible(this.statusheader, this.nmstatusheader);
        }

        public void IsUserableToCloseFAQPopupWindow()
        {
            this.Driver.IsElementClickable(this.closeButtonforFAQPopupWindow, this.nmcloseButtonforFAQPopupWindow);
        }

        public string IsUserableToGetTextFromStatusPopup()
        {
            this.Driver.IsElementVisible(this.faqQuestionlabeltext, this.nmfaqQuestionlabeltext);
            var questiontext = this.Driver.GetText(this.faqQuestionlabeltext);
            return questiontext;
        }

        public void IsEditFAQBtnClickable()
        {
            this.Driver.IsElementVisible(this.editBtn, this.nmeditBtn);
            this.Driver.IsElementClickable(this.editBtn, this.nmeditBtn);
        }

        public void IsUpdateMembershipFAQsPopUpWindowVisible()
        {
            this.Driver.WaitUntilElementIsFound(this.membershipUpdateFAQsHeading, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.membershipUpdateFAQsHeading, this.nmMembershipUpdateFAQsHeading);
        }

        public string IsQuestiontextCaptured()
        {
            var text = this.Driver.GetText(this.addFAQsQuestion);
            return text;
        }

        public void IsFAQUpdatedMessageDisplayedSuccessfully(string updateSuccessmessage)
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.successfullMsg, this.nmupdatedSuccessMsg);
            this.Driver.IsExpectedTextMatchWithActualText(this.successfullMsg, updateSuccessmessage, this.nmupdatedSuccessMsg);
        }

        public void IsUserabletoViewFAQDetails(int index)
        {
            try
            {
                this.Driver.WaitForPageLoad();
                var actualquestiontext = this.Driver.GetTextFromListOfElementsBasedOnIndex(this.faqQuestionsList, this.nmfaqquestionsList, index);
                this.SelectFAQFromList(index);
                this.IsStatusOfFAQPopupWindowVisible();
                var expectedquestiontext = this.IsUserableToGetTextFromStatusPopup();
                Assert.AreEqual(expectedquestiontext, actualquestiontext);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify whether Question Value is same as in popup window for the Question- " + expectedquestiontext + ".", "Both values in the questions list and in the popup window are same");
                Logger.Info("Both values in the questions list and in the popup window are same");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed as the values are differed - Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify whether Question Value is same as in popup window", "An exception occurred while verifying question value");
                throw;
            }
        }

        public void AddFAQs(string questionTxt, string answerTxt)
        {
            try
            {
                this.IsAddFAQButtonClickable();
                this.IsAddMembershipFAQsPopUpWindowTitleVisible();
                this.EnterFAQQuestionTextInEditorWindow(questionTxt);
                this.EnterFAQAnswerTextInEditorWindow(answerTxt);
                this.IsAddFAQsSaveButtonCllickable();
            }
            catch (Exception e)
            {
                Logger.Error("Failed to add FAQ Question Due to exception: " + e.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify FAQ Question added ", "An exception occurred while creating membershipFAQ");
                throw e;
            }
        }

        public void IsDeleteButtonClickable(string questionToDelete)
        {
            this.Driver.WaitUntilElementIsFound(this.deleteFAQButton.Format(questionToDelete), 60);
            this.Driver.IsElementVisible(this.deleteFAQButton.Format(questionToDelete), this.nmdeleteFAQButton);
            this.Driver.IsElementClickable(this.deleteFAQButton.Format(questionToDelete), this.nmdeleteFAQButton);
        }

        public void IsUserabletoClickOnYesButtonFromFAQConfirmationDialogWindow()
        {
            this.Driver.WaitUntilElementIsFound(this.yesButton, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.yesButton, this.nmyesButton);
            this.Driver.IsElementClickable(this.yesButton, this.nmyesButton);
        }

        public void IsFAQDeletedMessageDisplayedSuccessfully(string deleteMessage)
        {
            this.Driver.WaitUntilElementIsFound(this.successfullMsg, BaseConfiguration.LongTimeout);
            this.Driver.IsExpectedTextMatchWithActualText(this.successfullMsg, deleteMessage, this.nmdeletedSuccessfullyMsg);
        }

        public void VerifyFAQIsDetletedAndNotVisibleInList(string fAQQuestionToVerify)
        {
            try
            {
                IList<IWebElement> deletedstatusofFAQ = this.Driver.GetElements(this.fAQname);
                for (int i = 0; i < deletedstatusofFAQ.Count; i++)
                {
                    if (deletedstatusofFAQ[i].Text.Trim().Contains(fAQQuestionToVerify))
                    {
                        if (true)
                        {
                            DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify questiontext  - " + fAQQuestionToVerify + " is available in the list", "FAQ - " + fAQQuestionToVerify + " is visible in the List");
                            Logger.Info(" FAQ - " + fAQQuestionToVerify + " is deleted successfully and not visible in the FAQlist");
                            throw new ElementNotVisibleException("Able to see Delete text from list of Element");
                        }
                    }
                }

                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify questiontext  - " + fAQQuestionToVerify + " is not available in the list", "FAQ - " + fAQQuestionToVerify + " is not visible in the List");
                Logger.Info(" FAQ - " + fAQQuestionToVerify + " is deleted successfully and not visible in the FAQlist");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To verify FAQ Question is deleted from FAQsList", "An exception occurred while verifying Deleted FAQ from List");
                throw;
            }
        }

        public void IsMandatoryFieldErrorMessageDisplayedforFAQsQuestionField(string expectedQuestionFielderrormessage)
        {
            var actualQuestionFielderrormessage = this.Driver.GetText(this.errorMessageforQuestionField);
            this.Driver.IsExpectedTextMatchWithActualText(this.errorMessageforQuestionField, expectedQuestionFielderrormessage, actualQuestionFielderrormessage);
        }

        public void IsMandatoryFieldErrorMessageDisplayedforFAQsAnswerField(string expectedAnswerFielderrormessage)
        {
            var actualAnswerFielderrormessage = this.Driver.GetText(this.errorMessageforAnswerField);
            this.Driver.IsExpectedTextMatchWithActualText(this.errorMessageforAnswerField, expectedAnswerFielderrormessage, actualAnswerFielderrormessage);
        }

        public int IsuserabletogetCountOfFAQs()
        {
            IList<IWebElement> lstElements = this.Driver.GetElements(this.fAQname);
            int elementcount = lstElements.Count;
            return elementcount;
        }

        public void FAQsPageRefresh()
        {
            this.Driver.Navigate().Refresh();
        }

        public string IsQuestionTextcapturedfromListOfQuestions(int index)
        {
            string questiontextfromlist = this.Driver.GetTextFromListOfElementsBasedOnIndex(this.fAQname, this.nmFAQname, index);
            return questiontextfromlist;
        }

        public void VerifyWhetherFAQlistIssortedInFIFOOrder(string actualText, string expectedText)
        {
            try
            {
                Assert.AreEqual(expectedText, actualText);
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To verify Expected Value is matching with Actual text ", "The expected Value is " + expectedText + " and  actual value is " + actualText + " matching successfully");
                DriverContext.ExtentStepTest.Log(LogStatus.Pass, "To Verify FAQs are sorted in FIFO order", "FAQs are sorted in FIFO order successfully");
                Logger.Info("Expected text " + expectedText + " and Actual text is " + actualText);
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to verify text on " + expectedText + "with Actual Text " + actualText + " Due to exception: " + ex.ToString());

                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify text on " + expectedText + "with Actual Text " + actualText, "An exception occurred while finding text on " + expectedText);
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, "To Verify FAQs sorting Order", " An exception occured in FIFO Sort Order");
                throw;
            }
        }

        public void IsAddFAQsCancelButtonCllickable()
        {
            this.Driver.WaitUntilElementIsFound(this.cancelButton, BaseConfiguration.LongTimeout);
            var webElement = this.Driver.GetElement(this.cancelButton);
            this.Driver.IsElementVisible(this.cancelButton, this.nmCancelBtn);
            this.Driver.JavaScriptClick(webElement);
            this.Driver.WaitForPageLoad();
        }
    }
}