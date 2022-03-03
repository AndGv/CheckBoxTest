using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace CheckBoxTest.Page
{
    public class CheckBoxClicksPage
    {
        private readonly IWebDriver Driver;

        public IWebElement ButtonElement => Driver.FindElement(By.Id("check1"));
        public IWebElement AgeTxtElement => Driver.FindElement(By.Id("isAgeSelected"));
        public IWebElement AgeCheckboxElement => Driver.FindElement(By.Id("isAgeSelected"));
        public IReadOnlyCollection<IWebElement> CheckboxElements => Driver.FindElements(By.CssSelector(".cb1-element"));

        public CheckBoxClicksPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public void ClickButton()
        {
            ButtonElement.Click();
        }

        public bool IsButtonWithValue(string Value)
        {
            return Value.Equals(ButtonElement.GetAttribute("value"));
        }

        public void ClickOnCheckbox(bool ShouldBeChecked)
        {
            if (AgeCheckboxElement.Selected != ShouldBeChecked)
            {
                AgeCheckboxElement.Click();
            }
        }

        public void ClickAllCheckboxes(bool ShouldBeChecked)
        {
            foreach (IWebElement checkbox in CheckboxElements)
            {
                if (checkbox.Selected != ShouldBeChecked)
                {
                    checkbox.Click();
                }
            }
        }
    }
}
