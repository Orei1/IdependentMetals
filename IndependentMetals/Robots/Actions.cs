using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using IndependentMetals;
using IndependentMetals.Functions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace IndependentMetals.Actions
{

    public class Actions
    {
        IWebDriver? driver;
        public Actions(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void BrowserInitiation()
        {
            driver.Navigate().GoToUrl("https://www.independentmetals.pl/oferty-sprzedazy");
        }
        public void AcceptCookies()
        {
            driver.FindElement(By.XPath("(//a[contains(@class,'btn btn-secondary')])[2]")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(PageObject.SecondaryAccept)).Click();
            System.Threading.Thread.Sleep(1000);
        }
        public async Task DropDownPicker(string type)
        {
            driver.FindElement(By.CssSelector(PageObject.TypeContainer)).Click();
            var typeContainer = driver.FindElement(By.XPath(PageObject.PressedContainer));
            typeContainer.Click();
            typeContainer.SendKeys(type);
            typeContainer.SendKeys(Keys.ArrowDown);
            typeContainer.SendKeys(Keys.Enter);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span[title = 'Złoto']"), "Złoto"));
            await Task.Delay(500);
            driver.FindElement(By.CssSelector(PageObject.FormContainer)).Click();
            var formContainer = driver.FindElement(By.XPath(PageObject.PressedContainer));
            formContainer.Click();
            formContainer.SendKeys(Parameters.form);
            formContainer.SendKeys(Keys.Enter);
            //wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span[title='Monety']"), "Monety"));
            await Task.Delay(500);
            driver.FindElement(By.CssSelector(PageObject.WeightContainer)).Click();
            var weightContainer = driver.FindElement(By.XPath(PageObject.PressedContainer));
            weightContainer.SendKeys(Parameters.weight);
            weightContainer.SendKeys(Keys.Enter);
            //wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span[title='1 oz']"), "1 oz"));
            await Task.Delay(500);
            driver.FindElement(By.CssSelector(PageObject.FinenessContainer)).Click();
            var finenessContainer = driver.FindElement(By.XPath(PageObject.PressedContainer));
            finenessContainer.SendKeys(Parameters.fineness);
            finenessContainer.SendKeys(Keys.Enter);
            //wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span[title='999.99']"), "999.99"));
            await Task.Delay(500);
        }
        public void PriceViewSwitch()
        {
            driver.FindElement(By.CssSelector(PageObject.PriceSwitch)).Click();
        }
        public async Task ResultGenerator()
        {
            await Task.Delay(3000);
            for (int i = 2; i <= 4; i++)
            {
                await Task.Delay(3000);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                var lastEl = wait.Until(ExpectedConditions.ElementExists(
                By.CssSelector($"div#w1>div:nth-of-type({i})>div:nth-of-type(2)>div:nth-of-type(3)")));
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                js.ExecuteScript("window.scrollBy(0,950);");
                Console.WriteLine(lastEl.Text);
                string path = @"C:\Users\Kuba\source\repos\IndependentMetals\IndependentMetals\Tools\Results.txt";
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(lastEl.Text);
                    }
                
            }
        }
    }
}
