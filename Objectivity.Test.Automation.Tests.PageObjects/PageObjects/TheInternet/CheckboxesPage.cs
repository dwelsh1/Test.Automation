﻿namespace Objectivity.Test.Automation.Tests.PageObjects.PageObjects.TheInternet
{
    using Common.Extensions;
    using Common.WebElements;
    using NLog;
    using Objectivity.Test.Automation.Common;
    using Objectivity.Test.Automation.Common.Types;

    /// <summary>
    /// The checkboxes page.
    /// </summary>
    public class CheckboxesPage : ProjectPageBase
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator
            checkboxesPageHeader = new ElementLocator(Locator.XPath, "//h3[text()='Checkboxes']"),
            checkbox1 = new ElementLocator(Locator.CssSelector, "#checkboxes>input:nth-of-type(1)"),
            checkbox1Checked = new ElementLocator(Locator.XPath, "//input[1][@checked='']"),
            checkbox2 = new ElementLocator(Locator.CssSelector, "#checkboxes>input:nth-of-type(2)"),
            checkbox2Checked = new ElementLocator(Locator.XPath, "//input[2][@checked='']");

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckboxesPage" /> class.
        /// </summary>
        /// <param name="driverContext">The driver context.</param>
        public CheckboxesPage(DriverContext driverContext) : base(driverContext)
        {
            Logger.Info("Create checkboxes page.");
            Logger.Info("Check if checkboxes page is displayed.");
            this.Driver.IsElementPresent(this.checkboxesPageHeader, BaseConfiguration.MediumTimeout);
        }

        public bool IsCheckmarkOneTicked
        {
            get
            {
                Logger.Info("Check if checkbox1 is ticked.");
                return this.Driver.IsElementPresent(this.checkbox1Checked, BaseConfiguration.ShortTimeout);
            }
        }

        /// <summary>
        /// Verification of checkbox selection.
        /// </summary>
        public bool IsCheckmarkTwoTicked
        {
            get
            {
                Logger.Info("Check if checkbox2 is ticked.");
                return this.Driver.IsElementPresent(this.checkbox2Checked, BaseConfiguration.ShortTimeout);
            }
        }

        /// <summary>
        /// Ticks checkbox one.
        /// </summary>
        /// <returns><see cref="CheckboxesPage"/></returns>
        public CheckboxesPage TickCheckboxOne()
        {
            Logger.Info("Tick checkmark1.");
            this.Driver.GetElement<Checkbox>(this.checkbox1).TickCheckbox();
            return this;
        }

        /// <summary>
        /// Uncheck checkbox one.
        /// </summary>
        /// <returns>Checkboxes Page</returns>
        public CheckboxesPage UnTickCheckboxOne()
        {
            Logger.Info("Untick checkmark1.");
            this.Driver.GetElement<Checkbox>(this.checkbox1).UntickCheckbox();
            return this;
        }

        /// <summary>
        /// Ticks the checkbox two.
        /// </summary>
        /// <returns>Checkboxes Page</returns>
        public CheckboxesPage TickCheckboxTwo()
        {
            Logger.Info("Tick checkmark2.");
            this.Driver.GetElement<Checkbox>(this.checkbox2).TickCheckbox();
            return this;
        }

        public CheckboxesPage UnTickCheckboxTwo()
        {
            Logger.Info("Untick checkmark2.");
            this.Driver.GetElement<Checkbox>(this.checkbox2).UntickCheckbox();
            return this;
        }
    }
}
