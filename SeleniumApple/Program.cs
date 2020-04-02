using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeleniumApple
{
    class Program
    {
        static IWebDriver driver;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LaunchBrowser();
            ClickButton("Someone");
            SelectSecondFlow();
            CompleteFlow();
        }

        static void LaunchBrowser()
        {
            driver = new ChromeDriver("C:/ProgramData/Chrome_driver_79.0.3945.16");
            //driver = new ChromeDriver("C:/ProgramData/Chrome_driver_79.0.3945.16/chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.apple.com/covid19/");
            driver.FindElement(By.XPath("//ui-button[contains(text(),'Start')]")).Click();
        }


        static void ClickButton(string ButtonText)
        {
            string xpath = string.Format("//ui-button[contains(text(),'{0}')]", ButtonText);
            driver.FindElement(By.XPath(xpath)).Click();
            Thread.Sleep(1000);
        }

        static void SelectSecondFlow()
        {
            var objs = driver.FindElements(By.XPath("//button[@role='radio']"));
            Console.WriteLine(objs.Count);
            objs[1].Click();
            Console.WriteLine(objs[1].Text);
            ClickButton("Next");
        }

        static int GetRadioCount()
        {
            return driver.FindElements(By.XPath("//button[@role='radio']")).Count;
        }

        static void ClickRadioButton(int index)
        {
             driver.FindElements(By.XPath("//button[@role='radio']"))[index].Click();
            Thread.Sleep(1000);
        }

        static void CompleteFlow()
        {
            //How old are they
            int flowcount = 0;
            int radioCnt = GetRadioCount();
            for(int i = 1; i < radioCnt; i++)
            {
                //select age
                ClickRadioButton(i);
                ClickButton("Next");
                Thread.Sleep(1000);
                //select symptons 
                for (int j = 0; j < GetRadioCount(); j++)
                {
                    ClickRadioButton(j);
                    ClickButton("Next");
                   
                    //select disease
                    for (int k = 0; k < GetRadioCount(); k++)
                    {
                        ClickRadioButton(k);
                        ClickButton("Next");
                        
                        //In the last 14 days, have they traveled internationally?
                        for (int l = 0; l < GetRadioCount(); l++)
                        {
                            ClickRadioButton(l);
                            ClickButton("Next");

                            //In the last 14 days, have they been in an area where COVID-19 is widespread?
                            for (int m = 0; m < GetRadioCount(); m++)
                            {
                                ClickRadioButton(m);
                                ClickButton("Next");

                                //In the last 14 days, what is their exposure to others who are known to have COVID-19?
                                for (int n = 0; n < GetRadioCount(); n++)
                                {
                                    ClickRadioButton(n);
                                    ClickButton("Next");

                                    //Do they live or work in a care facility?
                                    for (int o = 0; o < GetRadioCount(); o++)
                                    {
                                        ClickRadioButton(o);
                                        ClickButton("Next");


                                        //Print the data or save 
                                        Console.WriteLine(++flowcount);
                                        ClickButton("Back");

                                    }
                                    ClickButton("Back");
                                }
                                ClickButton("Back");
                            }
                            ClickButton("Back");
                        }
                        ClickButton("Back");
                        
                    }
                    ClickButton("Back");
                    
                }
                ClickButton("Back");
            }

               
        }
    }
}
