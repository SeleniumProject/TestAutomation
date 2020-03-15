// <copyright file="InternalStaffHomePage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.PageObjects.PageObjects.MCS
{
    using System.Drawing;
    using System.Windows.Forms;
    using global::MCS.Test.Automation.Common;
    using global::MCS.Test.Automation.Common.Extensions;
    using global::MCS.Test.Automation.Common.Types;
    using global::MCS.Test.Automation.Tests.PageObjects;
    using NLog;

    public class InternalStaffHomePage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator
        customerLogo = new ElementLocator(Locator.CssSelector, "img.ui.image");

        private readonly ElementLocator
           loggedUser = new ElementLocator(Locator.CssSelector, "span.maxName.ellip");

        private readonly ElementLocator
        renewalTasksMenu = new ElementLocator(Locator.XPath, "//a[contains(text(),'Renewal Tasks')]");

        private readonly ElementLocator
    renewalTasksMenuLocator = new ElementLocator(Locator.XPath, "//div[@class='menuWrapper']//a[text()='Renewal Tasks']");

        private readonly ElementLocator
           membersManagementmenu = new ElementLocator(Locator.XPath, "//div[@class='menuWrapper']//a[text()='Member Management']");

        private readonly ElementLocator
            memberSubMenuMember = new ElementLocator(Locator.XPath, "//a[@href='/member-management/members'][text()='Members']");

        private string nmcustomerlogo = "Customer logo";
        private string nmloggeduser = "Logged In User";
        private string nmrenewalTasksMenu = "Renewal Tasks Menu";
        private string nmmembershipSubMenuMember = "Member Sub Menu";
        private string nmmembership = "Memebership Management Menu";

        public InternalStaffHomePage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void IsCustomerLogoDisplayed()
        {
            this.Driver.IsElementVisible(this.customerLogo, this.nmcustomerlogo);
        }

        public void IsLoggedUserDisplayed()
        {
            this.Driver.IsElementVisibleWithSoftAssertion(this.loggedUser, this.nmloggeduser);
        }

        public void IsRenewalTasksMenuItemClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.renewalTasksMenu, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.renewalTasksMenu, this.nmrenewalTasksMenu);
            this.Driver.IsElementClickable(this.renewalTasksMenu, this.nmrenewalTasksMenu);
        }

        public void IsRenewalTasksMenuClickable()
        {
            this.Driver.WaitUntilElementIsFound(this.renewalTasksMenuLocator, BaseConfiguration.LongTimeout);
            this.Driver.IsElementVisible(this.renewalTasksMenuLocator, this.nmrenewalTasksMenu);
            this.Driver.IsElementClickable(this.renewalTasksMenuLocator, this.nmrenewalTasksMenu);
        }

        public void IsMembersManagementSectionClickable()
        {
            this.Driver.IsElementVisible(this.membersManagementmenu, this.nmmembership);
            this.Driver.IsElementClickable(this.membersManagementmenu, this.nmmembership);
        }

        public void IsMemberManagementSubMenuMemberClickable()
        {
            this.Driver.IsElementVisible(this.memberSubMenuMember, this.nmmembershipSubMenuMember);
            this.Driver.IsElementClickable(this.memberSubMenuMember, this.nmmembershipSubMenuMember);
        }
    }
}
