using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class AddToCartTest
{
    public void Run()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        try
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Samsung galaxy s6")).Displayed);

            driver.FindElement(By.LinkText("Samsung galaxy s6")).Click();

            wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Samsung galaxy s6')]")).Displayed);

            Console.WriteLine("Add products to cart...");
            driver.FindElement(By.XPath("//a[text()='Add to cart']")).Click();

            wait.Until(driver => driver.SwitchTo().Alert() != null);
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Popup confirm: " + alert.Text);

            alert.Accept();

            driver.FindElement(By.Id("cartur")).Click();

            wait.Until(driver => driver.FindElement(By.XPath("//td[contains(text(),'Samsung galaxy s6')]")).Displayed);

            var productInCart = driver.FindElement(By.XPath("//td[contains(text(),'Samsung galaxy s6')]")).Text;
            Console.WriteLine("Product successfully added to cart: " + productInCart);

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
