using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace No_Such_Element_Exception_Handle
{

    class Entrypoint
    {
        static void Main()
        {


            IWebDriver driver = new ChromeDriver("./");
            driver.Navigate().GoToUrl("https://www.mycabtravel.com");

            IWebElement Flightno = driver.FindElement(By.Id("selectedFlight:input"));
            Flightno.SendKeys("EK1" + Keys.Enter);

            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));   //This works perfectly, the driver depends on timespan to look for an element.
            //IWebElement flightresolve=wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("flightTickImg")));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1)); // This I have got from selenium official but its not work appropriately. Though it does not generate an error and identify the element.
            IWebElement flightresolve = wait.Until(e => e.FindElement(By.Id("selectedFlight:input")));


            if (flightresolve.Displayed)

            {
                System.Console.WriteLine("The element found");

            }

            else
            {
                System.Console.WriteLine("The element not found");

            }
           driver.Close();
           driver.Quit();
        }


    }
}

//References
// https://stackoverflow.com/questions/6992993/selenium-c-sharp-webdriver-wait-until-element-is-present
//https://sqa.stackexchange.com/questions/15327/explicit-wait-is-not-reliable-with-selenium-c
//https://selenium.dev/docs/site/en/webdriver/waits/