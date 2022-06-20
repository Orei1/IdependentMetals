using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using IndependentMetals.Actions;
using System.Threading.Tasks;

namespace IndependentMetals
{
    public class Tests
    {

        [Test]
        public async Task GoldDigger()
        {
            using(var driver = new ChromeDriver())
            {
                Actions.Actions myActions = new Actions.Actions(driver);
                myActions.BrowserInitiation();
                myActions.AcceptCookies();
                await myActions.DropDownPicker();
                myActions.PriceViewSwitch();
                await myActions.ResultGenerator();
            }

        }
    }
}