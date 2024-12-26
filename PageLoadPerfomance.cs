using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;

public class PageLoadPerformanceTest
{
    public void Run()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        try
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            while (true)
            {
                string readyState = jsExecutor.ExecuteScript("return document.readyState").ToString();
                if (readyState.Equals("complete"))
                {
                    break;
                }
            }

            stopwatch.Stop();
            double loadTimeInSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Time taken to load the page: " + loadTimeInSeconds + " second");

            if (loadTimeInSeconds <= 3)
            {
                Console.WriteLine("Page successfully loads within the specified time: " + loadTimeInSeconds + " second");
            }
            else
            {
                Console.WriteLine("The page takes longer than 3 seconds to load: " + loadTimeInSeconds + " second");
            }
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
