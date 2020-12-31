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

            var home = new List<Apartament>();

            var title = driver.FindElements(By.XPath("//*[@class=\"lheight22 margintop5\"]"));
            var price = driver.FindElements(By.XPath("//*[@class=\"price\"]"));
            var location = driver.FindElements(By.XPath("//*[@class=\"lheight16\"]/small[1]/span"));
            var time = driver.FindElements(By.XPath("//*[@class=\"lheight16\"]/small[2]/span"));

            for (var i = 0; i <= title.Count - 1; i++)
            {
                home.Add(new Apartament()
                {
                    Title = title[i].Text,
                    Price = price[i].Text,
                    Location = location[i].Text,
                    Time = time[i].Text
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
