using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class RegisterTest
{
    public void Run()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        try
        {
        
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");

            driver.FindElement(By.Id("signin2")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("sign-username")).Displayed);

            driver.FindElement(By.Id("sign-username")).Clear();
            driver.FindElement(By.Id("sign-username")).SendKeys("afifahmuth123@gmail.com");
            driver.FindElement(By.Id("sign-password")).Clear();
            driver.FindElement(By.Id("sign-password")).SendKeys("afifah123");
            driver.FindElement(By.XPath("//button[text()='Sign up']")).Click();

            wait.Until(driver => driver.SwitchTo().Alert() != null);
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert message (Valid Input): " + alert.Text);
            alert.Accept();

            Console.WriteLine("Successful registration with valid input.");

            Console.WriteLine("Test complete.");
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
