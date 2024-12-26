using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class LoginTest
{
    public void Run()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        try
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");

            driver.FindElement(By.Id("login2")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("loginusername")).Displayed);

            driver.FindElement(By.Id("loginusername")).Clear();
            driver.FindElement(By.Id("loginusername")).SendKeys("afifah123@gmail.com");
            driver.FindElement(By.Id("loginpassword")).Clear();
            driver.FindElement(By.Id("loginpassword")).SendKeys("afifah123");
            driver.FindElement(By.XPath("//button[text()='Log in']")).Click();

            wait.Until(driver => driver.FindElement(By.Id("nameofuser")).Displayed);
            Console.WriteLine("Login success: " + driver.FindElement(By.Id("nameofuser")).Text);

            driver.FindElement(By.Id("logout2")).Click();

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
