
/*
• Open rozetka.com.ua; 
• Select any city; 
• Compare two first air conditioning; 
• Output equal parameters to the console;
*/

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Automation_task
{
    class Program
    {
        static void Main(string[] args)
        {          
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://rozetka.com.ua/");
   
            // Choose the city
            driver.FindElement(By.XPath("/html/body/app-root/div/div[1]/div[1]/header/div/div[1]/div[2]/div/a")).Click();         
            driver.FindElement(By.XPath("/html/body/app-root/div/div[1]/div[1]/header/div/div[1]/div[2]/div/modal-popup/div/common-city/ul/li[2]/a")).Click();

            // Find air conditioners
            driver.FindElement(By.Name("search")).SendKeys("Кондиционеры");
            driver.FindElement(By.Name("search")).SendKeys(Keys.Enter);

            Console.Clear();

            // Choose first air conditioner and put information about it to string
            driver.FindElement(By.CssSelector("div.g-i-tile:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(3) > a:nth-child(1)")).Click();
            IWebElement firstElement = driver.FindElement(By.XPath("/html/body/app-root/rz-main-app/pp-product-page/div/div/div/div/pp-tab-all/div[1]/div[3]/pp-short-details-block/div/pp-short-characteristics/ul"));
            string firstAirConditioningInfo = firstElement.Text;
        
            // Output information about first air conditioner to the console
            Console.WriteLine("Parameters of the first air conditioner:");
            Console.WriteLine(driver.FindElement(By.XPath("/html/body/app-root/rz-main-app/pp-product-page/div/div/pp-header/header/div[2]/h1")).Text);
            Console.WriteLine(firstAirConditioningInfo);

            driver.Navigate().Back();

            // Choose second air conditioner and put information about it to string
            driver.FindElement(By.CssSelector("div.g-i-tile:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(3) > a:nth-child(1)")).Click();
            IWebElement secondElement = driver.FindElement(By.XPath("/html/body/app-root/rz-main-app/pp-product-page/div/div/div/div/pp-tab-all/div[1]/div[3]/pp-short-details-block/div/pp-short-characteristics/ul"));
            string secondAirConditioningInfo = secondElement.Text;

            // Output information about second air conditioner to the console
            Console.WriteLine();
            Console.WriteLine("Parameters of the second air conditioner:");
            Console.WriteLine(driver.FindElement(By.XPath("/html/body/app-root/rz-main-app/pp-product-page/div/div/pp-header/header/div[2]/h1")).Text);
            Console.WriteLine(secondAirConditioningInfo);

            // Split each parameter into separate string (in array) for further comparison
            string[] firstArray = firstAirConditioningInfo.Split('\n');         
            string[] secondArray = secondAirConditioningInfo.Split('\n');

            // Compare parameters in each string and output the equal parameters
            Console.WriteLine();
            Console.WriteLine("The following parameters of air conditioners are equal:");

            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int j = 0; j < secondArray.Length; j++)
                {
                    if (firstArray[i].Equals(secondArray[j]))
                    {
                        Console.WriteLine(firstArray[i]);
                    }
                }               
            }

            driver.Close();

            Console.ReadKey();
        }
    }
}
