using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class PlaceOrderTest
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

            driver.FindElement(By.XPath("//a[text()='Add to cart']")).Click();

            wait.Until(driver => driver.SwitchTo().Alert() != null);
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Popup confirm: " + alert.Text);
            alert.Accept();

            driver.FindElement(By.Id("cartur")).Click();

            wait.Until(driver => driver.FindElement(By.XPath("//td[contains(text(),'Samsung galaxy s6')]")));

            driver.FindElement(By.XPath("//button[text()='Place Order']")).Click();

           bool isProductInCart = driver.FindElement(By.XPath("//td[contains(text(),'Samsung galaxy s6')]")).Displayed;

            driver.FindElement(By.Id("name")).SendKeys("Nurul Afifah");
            driver.FindElement(By.Id("country")).SendKeys("Indonesia");
            driver.FindElement(By.Id("city")).SendKeys("Semarang");
            driver.FindElement(By.Id("card")).SendKeys("123456789");
            driver.FindElement(By.Id("month")).SendKeys("December");
            driver.FindElement(By.Id("year")).SendKeys("2024");

            driver.FindElement(By.XPath("//button[text()='Purchase']")).Click();

            wait.Until(driver => driver.FindElement(By.ClassName("sweet-alert")).Displayed);
            var confirmationMessage = driver.FindElement(By.ClassName("sweet-alert")).Text;
            Console.WriteLine("Pesan confirm: " + confirmationMessage);

            Console.WriteLine("Order successfully completed.");
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
