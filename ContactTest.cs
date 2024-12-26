using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class ContactTest
{
    public void Run()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        try
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");

            driver.FindElement(By.LinkText("Contact")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("recipient-email")).Displayed);

            driver.FindElement(By.Id("recipient-email")).SendKeys("afifah123@gmail.com");
            driver.FindElement(By.Id("recipient-name")).SendKeys("Nurul Afifah");
            driver.FindElement(By.Id("message-text")).SendKeys("Hello");

            driver.FindElement(By.XPath("//button[text()='Send message']")).Click();

            wait.Until(driver => driver.SwitchTo().Alert() != null);
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Message Confirm: " + alert.Text);
            alert.Accept();

            Console.WriteLine("Test completed. Contact message sent successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            driver.Quit();
        }
    }
}
