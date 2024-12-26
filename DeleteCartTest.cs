using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class DeleteCartTest
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

            driver.FindElement(By.LinkText("HTC One M9")).Click();

            wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'HTC One M9')]")).Displayed);

            driver.FindElement(By.XPath("//a[text()='Add to cart']")).Click();

            wait.Until(driver => driver.SwitchTo().Alert() != null);
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Popup confirm: " + alert.Text);

            alert.Accept();

            driver.FindElement(By.Id("cartur")).Click();

            wait.Until(driver => driver.FindElement(By.XPath("//td[contains(text(),'HTC One M9')]")));

            var productInCart = driver.FindElement(By.XPath("//td[contains(text(),'HTC One M9')]"));
            Console.WriteLine("Product successfully added to cart: " + productInCart.Text);

            Console.WriteLine("Remove products from cart...");
            driver.FindElement(By.XPath("//a[text()='Delete']")).Click();

            wait.Until(driver => !driver.FindElements(By.XPath("//td[contains(text(),'HTC One M9')]")).Any());
            Console.WriteLine("Product successfully removed from cart.");

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
