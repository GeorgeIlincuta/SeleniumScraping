using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;

namespace SeleniumScraping
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://www.olx.ro/imobiliare/apartamente-garsoniere-de-vanzare/bucuresti/");

            var home = new List<Apartment>();

            var parent = driver.FindElements(By.XPath("//*[@class=\"offer  \"]"));

            foreach (var item in parent)
            {
                var title    = item.FindElement(By.XPath(".//*[@class=\"lheight22 margintop5\"]")).Text;
                var price    = item.FindElement(By.XPath(".//*[@class=\"price\"]")).Text;
                var location = item.FindElement(By.XPath(".//*[@class=\"lheight16\"]/small[1]/span")).Text;
                var time     = item.FindElement(By.XPath(".//*[@class=\"lheight16\"]/small[2]/span")).Text;

                home.Add(new Apartment()
                {
                    Title    = title,
                    Price    = price,
                    Location = location,
                    Time     = time
                });
            }

            foreach (var item in home)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Location);
                Console.WriteLine(item.Time);
                Console.WriteLine("-----------------------------------------");
            }
            Console.WriteLine(home.Count);
        }
            
    }
}
