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
            using (var driver = new ChromeDriver())
            {
                Actions.Actions myActions = new Actions.Actions(driver);
                myActions.BrowserInitiation();
                myActions.AcceptCookies();
                await myActions.DropDownPicker("Z³oto");
                myActions.PriceViewSwitch();
                await myActions.ResultGenerator();
  
;
            }

        }
        [Test]
        public async Task SilverDigger()
        {
            using (var driver = new ChromeDriver())
            {
                Actions.Actions myActions = new Actions.Actions(driver);
                myActions.BrowserInitiation();
                myActions.AcceptCookies();
                await myActions.DropDownPicker("Srebro");
                myActions.PriceViewSwitch();
                await myActions.ResultGenerator();
            }

        }
    }
}