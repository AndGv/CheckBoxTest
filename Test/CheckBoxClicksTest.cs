using CheckBoxTest.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CheckBoxTest.Test
{
    public class CheckBoxClicksTest
    {
        private static IWebDriver Driver;
        private static CheckBoxClicksPage Page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            Driver = new ChromeDriver();
            Page = new CheckBoxClicksPage(Driver);
            Driver.Url = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
            Driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        { 
            Driver.Quit();
        }


        [Test]
        public static void Test1OneCheckbox()
        {
            Page.ClickOnCheckbox(true);
            Assert.IsTrue("Success - Check box is checked".Equals(Page.AgeTxtElement.Text), $"Text is not the same, actual text is {Page.AgeTxtElement.Text}");
        }

        [Test]
        public static void Test2ManyCheckboxes()
        {
            Page.ClickOnCheckbox(false);
            Page.ClickAllCheckboxes(true);
            Assert.IsTrue(Page.IsButtonWithValue( "Uncheck All"), "Text is not correct");
        }

        [Test]
        public static void Test3ManyCheckboxs()
        {
            Page.ClickOnCheckbox(false);
            if (!Page.IsButtonWithValue("Uncheck All"))
            {
                Page.ClickAllCheckboxes(true);
            }
            Page.ClickButton();

            foreach (IWebElement checkbox in Page.CheckboxElements)
            {
                Assert.IsFalse(checkbox.Selected);
            }
            Assert.IsTrue(Page.IsButtonWithValue("Check All"), "Text is not correct");
        }
    }
}
