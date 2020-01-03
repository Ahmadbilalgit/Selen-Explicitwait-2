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
            Flightno.Click();
            Flightno.SendKeys("EK1" + Keys.Enter);
        
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement flightresolve = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("flightTickImg")));

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